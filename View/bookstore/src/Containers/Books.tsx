import * as React from 'react';

class Book extends React.Component {
  constructor() {
    super({});
    
  }

  async componentWillMount() {
    //Carregar livros
  }

  public render() {
    return (
      <div>
        Libros
      </div>
    );
  }
}

export default Book;
