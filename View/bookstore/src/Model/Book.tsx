import Author from "./Author";

export default class Book {
    public id: string;
    public title: string;
    public synopsis: string;
    public authorId: string;
    public author: Author;
}