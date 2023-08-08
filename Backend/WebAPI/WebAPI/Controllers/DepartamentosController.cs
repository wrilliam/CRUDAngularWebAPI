using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IEnumerable<Departamento>>> SelectAsync()
        {
            return await _contexto.Departamentos.ToListAsync();
        }

        [HttpGet("{idDepartamento}")]
        public async Task<ActionResult<Departamento>> SelectByIdAsync(int idDepartamento)
        {
            Departamento departamento = await _contexto.Departamentos.FindAsync(idDepartamento);

            if (departamento == null)
                return NotFound();

            return Ok(departamento);
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> InsertAsync(Departamento departamento)
        {
            await _contexto.Departamentos.AddAsync(departamento);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Departamento departamento)
        {
            _contexto.Departamentos.Update(departamento);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idDepartamento}")]
        public async Task<ActionResult> DeleteAsync(int idDepartamento)
        {
            Departamento departamento = await _contexto.Departamentos.FindAsync(idDepartamento);

            if (departamento == null)
                return NotFound();

            _contexto.Departamentos.Remove(departamento);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
