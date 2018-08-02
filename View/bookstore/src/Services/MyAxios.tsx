import axios, { AxiosResponse, AxiosPromise } from "axios";

const ROOT_URL = `http://localhost:5000/api`;

export const MyAxios = {
  async get(metodo: string) : any {
    let result = await axios.get(this._url(metodo));
    this._logResponse('get', metodo, result);
    return result;
  },

  async post(metodo: string, data: any) {
    this._log('post saída', metodo, data);
    let result = await axios.post(this._url(metodo), data);
    this._logResponse('post retorno', metodo, result);
    return result;
  },

  async put(metodo: string, data: any) {
    this._log('put saída', metodo, data);
    let result = await axios.put(this._url(metodo), data);
    this._logResponse('put retorno', metodo, result);
    return result;
  },

  async delete(metodo: string) {
    let result = await axios.delete(this._url(metodo));
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
