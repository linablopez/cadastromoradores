using Siscon_API_Backend.Data;
using Siscon_API_Backend.Models;
using Siscon_API_Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Siscon_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        [HttpGet("v1/tipoDocumentos")]
        public async Task<IActionResult> GetAll([FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var tipoDocumentos = await Dbcontext.TipoDocumentos.AsNoTracking().ToListAsync();

                return Ok(new ReturnViewModel<List<TipoDocumento>>(tipoDocumentos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class TipoDocumentoController {this.GetType().Name} Code 01 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpGet("v1/usuario/{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var tipoDocumento = await Dbcontext.TipoDocumentos.FirstOrDefaultAsync(x => x.Id == id);

                if (tipoDocumento == null)
                    return NotFound(new ReturnViewModel<TipoDocumento>($"Tipo Documento ID: {id} não encontrado."));

                return Ok(new ReturnViewModel<TipoDocumento>(tipoDocumento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class TipoDocumentoController {this.GetType().Name} Code 02 - {ex.Message + ex.StackTrace}"));
            }
        }
    }
}
