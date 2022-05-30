using APILivro.Model;
using APILivro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APILivro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
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

            return CreatedAtAction(nameof(BuscarPorId), new {id = livro.Id}, livro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var livro = await _livroRepository.BuscarPorId(id);

            if(livro == null)
                return NotFound();

            await _livroRepository.Deletar(livro);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Livro livro)
        {
            var existe = await _livroRepository.BuscarPorId(id);

            if (existe.Equals(null) || id != livro.Id)
                return BadRequest();

            await _livroRepository.Atualizar(livro);

            return NoContent();
        }
    }
}
