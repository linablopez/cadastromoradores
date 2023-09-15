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
    public class ApartamentoController : ControllerBase
    {
        [HttpGet("v1/apartamentos")]
        public async Task<IActionResult> GetAll([FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var apartamentos = await Dbcontext.Apartamentos.AsNoTracking().Include(x => x.Predio).ToListAsync();

                return Ok(new ReturnViewModel<List<Apartamento>>(apartamentos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class ApartamentoController {this.GetType().Name} Code 01 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpGet("v1/apartamento/{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var apartamento = await Dbcontext.Apartamentos.Include(x => x.Predio).FirstOrDefaultAsync(x => x.Id == id);

                if (apartamento == null)
                    return NotFound(new ReturnViewModel<Apartamento>($"Apartamento ID: {id} não foi encontrado."));

                return Ok(new ReturnViewModel<Apartamento>(apartamento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class ApartamentoController {this.GetType().Name} Code 02 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPost("v1/apartamento/")]
        public async Task<IActionResult> Post([FromBody] RegisterApartamentoViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ReturnViewModel<string>(ModelState.GetErrors()));

                var apartamentoValidandoBancoDeDados = await Dbcontext.Apartamentos.AsNoTracking()
                                                                      .Where(x => x.NumeroApto == model.NumeroApto
                                                                          && x.Andar == model.Andar
                                                                          && x.PredioId == model.PredioId).ToListAsync();

                if (apartamentoValidandoBancoDeDados.Any())
                    return NotFound(new ReturnViewModel<Apartamento>($"O Apartamento de número: {model.NumeroApto} já existe no cadastro no Prédio de ID {model.PredioId}."));

                var Apartamento = new Apartamento
                {
                    NumeroApto = model.NumeroApto,
                    Andar = model.Andar,
                    PredioId = model.PredioId
                };

                await Dbcontext.Apartamentos.AddAsync(Apartamento);
                await Dbcontext.SaveChangesAsync();

                return Created("", new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Apartamento cadastrado com sucesso.",
                    NumeroApartamento = model.NumeroApto,
                    PredioId = model.PredioId
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class ApartamentoController {this.GetType().Name} Code 03 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPut("v1/apartamento/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EditorApartamentoViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var apartamento = await Dbcontext.Apartamentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (apartamento == null)
                    return NotFound(new ReturnViewModel<Apartamento>($"Apartamento ID: {id} não encontrado."));


                if (model.NumeroApto != null)
                {
                    apartamento.NumeroApto = model.NumeroApto;
                }

                if (model.Andar != null)
                {
                    apartamento.Andar = model.Andar;
                }

                if (model.PredioId != null)
                {
                    apartamento.PredioId = model.PredioId;
                }

                Dbcontext.Apartamentos.Update(apartamento);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Apartamento atualizado com sucesso.",
                    NumeroApartamento = apartamento.NumeroApto,
                    PredioId = apartamento.PredioId
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class ApartamentoController {this.GetType().Name} Code 04 - {ex.Message + ex.StackTrace}"));
            }
        }

        [HttpDelete("v1/apartamento/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var apartamento = await Dbcontext.Apartamentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (apartamento == null)
                    return NotFound(new ReturnViewModel<Apartamento>($"Apartamento ID: {id} não encontrado."));

                Dbcontext.Apartamentos.Remove(apartamento);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Apartamento removido com sucesso.",
                    NumeroApartamento = apartamento.NumeroApto,
                    PredioId = apartamento.PredioId
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class ApartamentoController {this.GetType().Name} Code 05 - {ex.Message + ex.StackTrace}"));
            }
        }
    }
}
