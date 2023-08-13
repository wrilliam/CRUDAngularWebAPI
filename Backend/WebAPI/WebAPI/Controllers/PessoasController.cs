using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Config;
using WebAPI.Entities;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Pessoa>))]
        public async Task<ActionResult<IEnumerable<Pessoa>>> SelectAsync()
        {
            return await _contexto.Pessoas.ToListAsync();
        }

        [HttpGet("{idPessoa}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pessoa))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<Pessoa>> SelectByIdAsync(int idPessoa)
        {
            Pessoa? pessoa = await _contexto.Pessoas.FirstOrDefaultAsync(p => p.IdPessoa == idPessoa);
            if (pessoa == null)
                return NotFound("Não foi encontrado registro algum com o identificador fornecido.");

            return Ok(pessoa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<Pessoa>> InsertAsync(PessoaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Preencha todos os campos obrigatórios.");

            Pessoa? pessoa = await _contexto.Pessoas.FirstOrDefaultAsync(p => p.Documento == model.Documento);
            if (pessoa != null)
                return BadRequest("Já existe uma pessoa registrada com o documento fornecido.");

            pessoa = new Pessoa {
                IdPessoa = model.IdPessoa,
                Nome = model.Nome,
                Apelido = (model.Apelido == null) ? "" : model.Apelido,
                Tipo = model.Tipo,
                Documento = model.Documento,
                Endereco = model.Endereco,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now,
            };

            await _contexto.Pessoas.AddAsync(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok("Registro criado com sucesso.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> UpdateAsync(PessoaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Preencha todos os campos obrigatórios.");

            Pessoa? pessoa = await _contexto.Pessoas.FirstOrDefaultAsync(p => p.IdPessoa == model.IdPessoa);
            if (pessoa == null)
                return NotFound("Não existe registro com o identificador fornecido. Você quer criar um novo?");

            pessoa.Nome = model.Nome;
            pessoa.Apelido = model.Apelido;
            pessoa.Tipo = model.Tipo;
            pessoa.Documento = model.Documento;
            pessoa.Endereco = model.Endereco;
            pessoa.DataAtualizacao = DateTime.Now;

            _contexto.Pessoas.Update(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok("Registro atualizado com sucesso.");
        }

        [HttpDelete("{idPessoa}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> DeleteAsync(int idPessoa)
        {
            Pessoa? pessoa = await _contexto.Pessoas.FirstOrDefaultAsync(p => p.IdPessoa == idPessoa);

            if (pessoa == null)
                return NotFound("Não existe registro algum com o identificador fornecido.");

            _contexto.Pessoas.Remove(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok("Registro removido com sucesso.");
        }

        #endregion
    }
}
