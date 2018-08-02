import { MyAxios } from './MyAxios'
import AuthorList from '../Model/AuthorList';

export const AuthorServico = {
    async GetAll() : Array<AuthorList>  {
        return await MyAxios.get('get');
    }
}