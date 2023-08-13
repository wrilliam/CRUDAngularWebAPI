using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Config;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        #region Atributos

        private readonly Contexto _contexto;

        #endregion

        #region Construtor

        public DepartamentosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Departamento>))]
        public async Task<ActionResult<IEnumerable<Departamento>>> SelectAsync()
        {
            return await _contexto.Departamentos.ToListAsync();
        }

        [HttpGet("{idDepartamento}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Departamento))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<Departamento>> SelectByIdAsync(int idDepartamento)
        {
            Departamento? departamento = await _contexto.Departamentos.FirstOrDefaultAsync(p => p.IdDepartamento == idDepartamento);
            if (departamento == null)
                return NotFound("Não foi encontrado registro algum com o identificador fornecido.");

            return Ok(departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<Departamento>> InsertAsync(DepartamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Preencha todos os campos obrigatórios.");

            Departamento? departamento = await _contexto.Departamentos.FirstOrDefaultAsync(p => p.Nome == model.Nome);
            if (departamento != null)
                return BadRequest("Já existe um departamento registrado com o nome fornecido.");

            Pessoa? pessoa = await _contexto.Pessoas.FirstOrDefaultAsync(p => p.IdPessoa == model.IdResponsavel);
            if (departamento == null)
                return NotFound("Não foi encontrado registro algum com o identificador fornecido para o responsável.");

            departamento = new Departamento {
                IdDepartamento = model.IdDepartamento,
                Nome = model.Nome,
                IdResponsavel = model.IdResponsavel,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now,
            };

            await _contexto.Departamentos.AddAsync(departamento);
            await _contexto.SaveChangesAsync();

            return Ok("Registro criado com sucesso.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> UpdateAsync(DepartamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Preencha todos os campos obrigatórios.");

            Departamento? departamento = await _contexto.Departamentos.FirstOrDefaultAsync(p => p.IdDepartamento == model.IdDepartamento);
            if (departamento == null)
                return NotFound("Não existe registro com o identificador fornecido. Você quer criar um novo?");

            departamento.Nome = model.Nome;
            departamento.IdResponsavel = model.IdResponsavel;
            departamento.DataAtualizacao = DateTime.Now;

            _contexto.Departamentos.Update(departamento);
            await _contexto.SaveChangesAsync();

            return Ok("Registro atualizado com sucesso.");
        }

        [HttpDelete("{idDepartamento}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> DeleteAsync(int idDepartamento)
        {
            Departamento? departamento = await _contexto.Departamentos.FirstOrDefaultAsync(p => p.IdDepartamento == idDepartamento);

            if (departamento == null)
                return NotFound("Não existe registro algum com o identificador fornecido.");

            _contexto.Departamentos.Remove(departamento);
            await _contexto.SaveChangesAsync();

            return Ok("Registro removido com sucesso.");
        }

        #endregion
    }
}
