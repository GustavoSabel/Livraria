import * as React from "react";
import BookList from "../Model/BookList";
import BookService from "../Services/BookService";
import NewBook from "./NewBook";

interface IState {
  books: BookList[];
  newBook: boolean;
}

class Books extends React.Component<any, IState> {
  constructor(props: any) {
    super(props);
    this.state = {
      books: [],
      newBook: false
    };
  }
    
  public async componentWillMount() {
    await this.RefreshBooks();
  }

  public render() {
    return (
      <div>
        <table>
          <thead>
            <tr>
              <td>Title</td>
              <td>Author</td>
            </tr>
          </thead>
          <tbody>
            {this.state.books.map(x => {
              return (
                <tr key={x.id}>
                  <td>{x.title}</td>
                  <td>{x.authorName}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <button onClick={() => this.newBookClick()} name="newBook">
          New Book
        </button>

        {this.state.newBook && (
          <NewBook
            handleSaved={() => this.handleSavedNewBook()}
            handleCloseClick={() => this.handleCloseClickNewBook()}
          />
        )}
      </div>
    );
  }

  private handleCloseClickNewBook() {
    this.setState({ newBook: false });
  }

  private async handleSavedNewBook() {
    this.setState({ newBook: false });
    await this.RefreshBooks();
  }

  private newBookClick() {
    this.setState({ newBook: true });
  }

  private async RefreshBooks() {
    this.setState({ books: await BookService.GetAll() });
  }
}

export default Books;
