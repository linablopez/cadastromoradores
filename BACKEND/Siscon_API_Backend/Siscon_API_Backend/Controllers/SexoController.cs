using Siscon_API_Backend.Data;
using Siscon_API_Backend.Models;
using Siscon_API_Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Siscon_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : ControllerBase
    {
        [HttpGet("v1/sexos")]
        public async Task<IActionResult> GetAll([FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var sexos = await Dbcontext.Sexos.AsNoTracking().ToListAsync();

                return Ok(new ReturnViewModel<List<Sexo>>(sexos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class SexoController {this.GetType().Name} Code 01 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpGet("v1/usuario/{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var sexo = await Dbcontext.Sexos.FirstOrDefaultAsync(x => x.Id == id);

                if (sexo == null)
                    return NotFound(new ReturnViewModel<Usuario>($"Sexo ID: {id} não encontrado."));

                return Ok(new ReturnViewModel<Sexo>(sexo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class SexoController {this.GetType().Name} Code 02 - {ex.Message + ex.StackTrace}"));
            }
        }
    }
}
