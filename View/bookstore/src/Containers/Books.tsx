import * as React from "react";
import BookList from "../Model/BookList";
import BookService from "../Services/BookService";
import BookEditor from "./BookEditor";

interface IState {
  bookEditId: string;
  books: BookList[];
  openBookEditor: boolean;
}

class Books extends React.Component<any, IState> {

  constructor(props: any) {
    super(props);
    this.state = {
      bookEditId: '',
      books: [],
      openBookEditor: false,
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
              <th>Title</th>
              <th>Author</th>
              <th>Commands</th>
            </tr>
          </thead>
          <tbody>
            {this.state.books.map(x => {
              return (
                <tr key={x.id}>
                  <td>{x.title}</td>
                  <td>{x.authorName}</td>
                  <td>
                    <button onClick={() => this.editBookClick(x.id)} name="editBook">Edit</button>
                    <button onClick={() => this.deleteBookClick(x.id)} name="deleteBook">Delete</button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <button onClick={() => this.newBookClick()} name="newBook">
          New Book
        </button>

        {this.state.openBookEditor && (
          <BookEditor
            bookId={this.state.bookEditId}
            handleSaved={() => this.handleSavedNewBook()}
            handleCloseClick={() => this.handleCloseClickNewBook()}
          />
        )}
      </div>
    );
  }

  private handleCloseClickNewBook() {
    this.setState({ openBookEditor: false });
  }

  private async handleSavedNewBook() {
    this.setState({ openBookEditor: false });
    await this.RefreshBooks();
  }

  private async deleteBookClick(id: string) {
    await BookService.Delete(id);
    this.RefreshBooks(); 
  }

  private editBookClick(id: string) {
    this.setState({ openBookEditor: true, bookEditId: id });
  }

  private newBookClick() {
    this.setState({ openBookEditor: true, bookEditId: '' });
  }

  private async RefreshBooks() {
    this.setState({ books: await BookService.GetAll() });
  }
}

export default Books;
