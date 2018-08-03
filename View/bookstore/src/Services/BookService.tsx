import Book from '../Model/Book';
import BookList from '../Model/BookList';
import MyAxios from './MyAxios'
import { InsertBookCommand } from 'src/Commands/InsertBookCommand';
import { UpdateBookCommand } from 'src/Commands/UpdateBookCommand';

const BookService = {
    async GetAll() : Promise<BookList[]> {
        return (await MyAxios.get<BookList[]>(`book`)).data;
    },
    async Get(id: string) : Promise<Book> {
        return (await MyAxios.get<Book>(`book/${id}`)).data;
    },
    async Post(book: InsertBookCommand) : Promise<Book> {
        return (await MyAxios.post<Book>(`book`, book)).data;
    },
    async Put(book: UpdateBookCommand) : Promise<Book> {
        return (await MyAxios.put<Book>(`book`, book)).data;
    },
    async Delete(id: string) : Promise<Book> {
        return (await MyAxios.delete(`book/${id}`)).data;
    }
} 

export default BookService;