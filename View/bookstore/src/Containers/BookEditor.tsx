import * as React from "react";
import AuthorList from "../Model/AuthorList";
import AuthorService from "../Services/AuthorService";
import BookService from "../Services/BookService";
import Book from "../Model/Book";
import Modal from "src/Components/Modal";

interface IState {
  authorId: string;
  authors: AuthorList[];
  title: string;
  synopsis: string;
}

interface IProps {
  bookId: string;
  handleSaved(book: Book): void;
  handleCloseClick(): void;
}

export default class BookEditor extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      authorId: "",
      authors: [],
      synopsis: "",
      title: ""
    };
  }

  public async componentWillMount() {
    let book : Book;
    if (this.props.bookId) {
      book = await BookService.Get(this.props.bookId);
    } else {
      book = new Book();
    }

    this.setState({
      authorId: book.authorId,
      authors: await AuthorService.GetAll(),
      synopsis: book.synopsis,
      title: book.title
    });
  }

  public render() {
    return (
      <Modal
        handleClose={() => this.props.handleCloseClick()}
        handleConfirm={() => this.confirm()}
      >
        <label htmlFor="title">Title</label>
        <input
          type="text"
          name="title"
          value={this.state.title || ""}
          onChange={e => this.setState({ title: e.target.value })}
        />

        <label htmlFor="title">Author</label>
        <select
          name="author"
          id="author"
          value={this.state.authorId || ""}
          onChange={e => this.setState({ authorId: e.target.value })}
        >
          <option value=""/>
          {this.state.authors.map(x => (

            <option key={x.id} value={x.id}>
              {x.fullName}
            </option>
          ))}
        </select>
      </Modal>
    );
  }

  private async confirm(): Promise<void> {
    let result: Book;
    if (this.props.bookId) {
      result = await BookService.Put({
        authorId: this.state.authorId,
        id: this.props.bookId,
        synopsis: this.state.synopsis,
        title: this.state.title
      });
    } else {
      result = await BookService.Post({
        authorId: this.state.authorId,
        synopsis: this.state.synopsis,
        title: this.state.title
      });
    }

    this.props.handleSaved(result);
  }
}
