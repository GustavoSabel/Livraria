# Livraria
- Contém uma API em .net Core 2.1 usando EF Core
- Contém uma aplicação em React com TypeScript para consumir essa API.

## Instruções de Uso
- A Api está usando um banco de dados Sql Server LocalDb. A String de conexão está fixa na classe Startup.
- Os Testes da Api estão usando o EF Core InMemmory
- O Projeto React está configurado para acessar a API pela porta 5000. Se precisar alterar a URL, ela está fixa em `src/Services/MyAxios.tsx`
