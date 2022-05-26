using APILivro.Model;
using APILivro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APILivro.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Livro>> BuscarTodosLivros()
        {
            return await _livroRepository.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> BuscarPorId(int id)
        {
            return await _livroRepository.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> Adicionar([FromBody] Livro livro)
        {
            await _livroRepository.Adicionar(livro);

            return livro;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var livro = _livroRepository.BuscarPorId(id);

            if(livro == null)
                await _livroRepository.Deletar(livro.Id);

            return null;
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Livro livro)
        {
            if (id == livro.Id)
                await _livroRepository.Atualizar(livro);

            return null;
        }
    }
}
