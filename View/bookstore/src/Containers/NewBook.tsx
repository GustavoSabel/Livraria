import * as React from "react";
import AuthorList from "../Model/AuthorList";
import AuthorService from "../Services/AuthorService";
import BookService from "../Services/BookService";
import Book from "../Model/Book";
import Modal from "src/Components/Modal";

interface IState {
  title: string;
  synopsis: string;
  authorId: string;
  authors: AuthorList[];
}

interface IProps {
  handleSaved(book: Book): void;
  handleCloseClick(): void;
}

class NewBook extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      authorId: "",
      authors: [],
      synopsis: "",
      title: "",
    };
  }

  public async componentWillMount() {
    this.setState({ authors: await AuthorService.GetAll() });
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

        <select
          name="author"
          id="author"
          value={this.state.authorId || ""}
          onChange={e => this.setState({ authorId: e.target.value })}
        >
          {this.state.authors.map(x => (
            <option key={x.id} value={x.id}>{x.fullName}</option>
          ))}
        </select>
      </Modal>
    );
  }

  private async confirm(): Promise<void> {
    const result = await BookService.Post({
      authorId: this.state.authorId,
      synopsis: this.state.synopsis,
      title: this.state.title
    });
    this.props.handleSaved(result);
  }
}

export default NewBook;
