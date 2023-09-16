using Siscon_API_Backend.Data;
using Siscon_API_Backend.Extensions;
using Siscon_API_Backend.Models;
using Siscon_API_Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siscon_API_Backend.ViewModels.Register;
using Siscon_API_Backend.ViewModels.Editor;

namespace Siscon_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorApartamentoController : ControllerBase
    {
        [HttpGet("v1/moradoresApartamentos")]
        public async Task<IActionResult> GetAll([FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var moradoresApartamentos = await Dbcontext.MoradoresApartamentos.AsNoTracking()
                                                                                 .Include(x => x.Morador)
                                                                                  .ThenInclude(t => t.TipoDocumento)
                                                                                 .Include(x => x.Morador)
                                                                                  .ThenInclude(s => s.Sexo)
                                                                                 .Include(x => x.Apartamento)
                                                                                  .ThenInclude(p => p.Predio)
                                                                                 .ToListAsync();

                return Ok(new ReturnViewModel<List<MoradorApartamento>>(moradoresApartamentos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorApartamentoController {this.GetType().Name} Code 01 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpGet("v1/moradorApartamento/{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var moradorApartamento = await Dbcontext.MoradoresApartamentos.AsNoTracking()
                                                                              .Include(x => x.Morador)
                                                                               .ThenInclude(t => t.TipoDocumento)
                                                                              .Include(x => x.Morador)
                                                                               .ThenInclude(s => s.Sexo)
                                                                              .Include(x => x.Apartamento)
                                                                               .ThenInclude(p => p.Predio)
                                                                              .FirstOrDefaultAsync(x => x.Id == id);

                if (moradorApartamento == null)
                    return NotFound(new ReturnViewModel<MoradorApartamento>($"Morador Apartamento ID: {id} não foi encontrado."));

                return Ok(new ReturnViewModel<MoradorApartamento>(moradorApartamento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorApartamentoController {this.GetType().Name} Code 02 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPost("v1/moradorApartamento/")]
        public async Task<IActionResult> Post([FromBody] RegisterMoradorApartamentoViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ReturnViewModel<string>(ModelState.GetErrors()));

                var moradorApartamentoValidandoBancoDeDados = await Dbcontext.MoradoresApartamentos.AsNoTracking()
                                                                      .Where(x => x.MoradorId == model.MoradorId
                                                                          && x.ApartamentoId == model.ApartamentoId)
                                                                      .ToListAsync();

                if (moradorApartamentoValidandoBancoDeDados.Any())
                    return NotFound(new ReturnViewModel<Apartamento>($"O morador Id: {model.MoradorId} já está cadastrado no Apartamento Id {model.ApartamentoId}."));

                var MoradorApartamento = new MoradorApartamento
                {
                    MoradorId = model.MoradorId,
                    ApartamentoId = model.ApartamentoId
                };

                await Dbcontext.MoradoresApartamentos.AddAsync(MoradorApartamento);
                await Dbcontext.SaveChangesAsync();

                return Created("", new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Morador foi cadastrado com sucesso no Apartamento.",
                    MoradorId = model.MoradorId,
                    ApartamentoId = model.ApartamentoId
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorApartamentoController {this.GetType().Name} Code 03 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpDelete("v1/moradorApartamento/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var moradorApartamento = await Dbcontext.MoradoresApartamentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (moradorApartamento == null)
                    return NotFound(new ReturnViewModel<Apartamento>($"Morador Apartamento ID: {id} não encontrado."));

                Dbcontext.MoradoresApartamentos.Remove(moradorApartamento);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Morador foi removido do cadastro do Apartamento com sucesso.",
                    MoradorId = moradorApartamento.MoradorId,
                    ApartamentoId = moradorApartamento.ApartamentoId
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorApartamentoController {this.GetType().Name} Code 04 - {ex.Message + ex.StackTrace}"));
            }
        }
    }
}
