using APILivro.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APILivro.Repositories
{
    public interface ILivroRepository
    {
        Task Adicionar(Livro livro);
        Task Atualizar(Livro livro);
        Task Deletar(Livro livro);
        Task<Livro> BuscarPorId(int id);
        Task<IEnumerable<Livro>> BuscarTodos();
    }
}
