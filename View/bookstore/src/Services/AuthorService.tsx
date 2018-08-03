import AuthorList from '../Model/AuthorList';
import MyAxios from './MyAxios'

const AuthorService = {
    async GetAll() : Promise<AuthorList[]>  {
        return (await MyAxios.get<AuthorList[]>('author')).data;
    },
    
    async Get(id: string) : Promise<AuthorList>  {
        return (await MyAxios.get<AuthorList>(`author/${id}`)).data;
    }
}

export default AuthorService;