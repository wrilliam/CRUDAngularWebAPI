using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        #region Atributos

        private readonly Contexto _contexto;

        #endregion

        #region Construtor

        public PessoasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> SelectAsync()
        {
            return await _contexto.Pessoas.ToListAsync();
        }

        [HttpGet("{idPessoa}")]
        public async Task<ActionResult<Pessoa>> SelectByIdAsync(int idPessoa)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(idPessoa);

            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> InsertAsync(Pessoa pessoa)
        {
            await _contexto.Pessoas.AddAsync(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Pessoa pessoa)
        {
            _contexto.Pessoas.Update(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idPessoa}")]
        public async Task<ActionResult> DeleteAsync(int idPessoa)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(idPessoa);

            if (pessoa == null)
                return NotFound();

            _contexto.Pessoas.Remove(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
