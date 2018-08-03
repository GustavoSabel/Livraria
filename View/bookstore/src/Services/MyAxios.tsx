import Axios, { AxiosResponse } from "axios";

const ROOT_URL = `http://localhost:5000/api`;

const MyAxios = {
  async get<T = any>(metodo: string) : Promise<AxiosResponse<T>> {
    const result = await Axios.get<T>(this._url(metodo));
    this._logResponse('get', metodo, result);
    return result;
  },

  async post<T = any>(metodo: string, data: any) : Promise<AxiosResponse<T>> {
    this._log('post saída', metodo, data);
    const result = await Axios.post<T>(this._url(metodo), data);
    this._logResponse('post retorno', metodo, result);
    return result;
  },

  async put<T = any>(metodo: string, data: any) : Promise<AxiosResponse<T>> {
    this._log('put saída', metodo, data);
    const result = await Axios.put<T>(this._url(metodo), data);
    this._logResponse('put retorno', metodo, result);
    return result;
  },

  async delete(metodo: string) : Promise<AxiosResponse<any>> {
    const result = await Axios.delete(this._url(metodo));
    this._logResponse('delete', metodo, result);
    return result;
  },

  _logResponse(acao: string, metodo: string, response: AxiosResponse<any>) {
    console.log(acao + ': ' + metodo);
    if(response.status !== 200)
      console.log('Status= ' + response.status + ': ' + response.statusText);
    console.log(response);
  },

  _log(acao: string, metodo: string, data: any) {
    console.log(acao + ': ' + metodo);
    console.log(data);
  },

  _url(metodo: string) {
    return `${ROOT_URL}/${metodo}`;
  },
};

export default MyAxios;