using APILivro.Model;
using APILivro.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APILivro.Infra.Persistencia
{
    public class LivroRepository : ILivroRepository
    {
        public readonly DataContext _dataContext;

        public LivroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Adicionar(Livro livro)
        {
            _dataContext.Livros.Add(livro);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Atualizar(Livro livro)
        {
            _dataContext.Livros.Update(livro);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Deletar(Livro livro)
        {
            _dataContext.Livros.Remove(livro);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Livro> BuscarPorId(int id)
        {
            return await _dataContext.Livros.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Livro>> BuscarTodos()
        {
            return await _dataContext.Livros.AsNoTracking().ToListAsync();
        }
    }
}
