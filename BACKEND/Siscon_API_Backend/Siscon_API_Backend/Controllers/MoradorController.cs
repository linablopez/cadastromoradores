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
    public class MoradorController : ControllerBase
    {
        [HttpGet("v1/moradores")]
        public async Task<IActionResult> GetAll([FromQuery] string? nomeMorador, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var morador = Dbcontext.Moradores.Include(x => x.Sexo).Include(x => x.TipoDocumento).AsQueryable().AsNoTracking();

                if (!string.IsNullOrEmpty(nomeMorador))
                {
                    morador = morador.Where(x => x.Nome.StartsWith(nomeMorador));
                }

                var moradores = await morador.OrderBy(x => x.Id).ToListAsync();


                return Ok(new ReturnViewModel<List<Morador>>(moradores));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorController {this.GetType().Name} Code 01 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpGet("v1/morador/{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var morador = await Dbcontext.Moradores.Include(x => x.Sexo).Include(x => x.TipoDocumento).FirstOrDefaultAsync(x => x.Id == id);

                if (morador == null)
                    return NotFound(new ReturnViewModel<Morador>($"Morador ID: {id} não foi encontrado."));

                return Ok(new ReturnViewModel<Morador>(morador));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorController {this.GetType().Name} Code 02 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPost("v1/morador/")]
        public async Task<IActionResult> Post([FromBody] RegisterMoradorViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ReturnViewModel<string>(ModelState.GetErrors()));

                var moradorValidandoBancoDeDados = await Dbcontext.Moradores.AsNoTracking()
                                                                      .Where(x => x.NumeroDocumento == model.NumeroDocumento
                                                                          && x.TipoDocumentoId == model.TipoDocumentoId)
                                                                      .ToListAsync();

                if (moradorValidandoBancoDeDados.Any())
                    return NotFound(new ReturnViewModel<Apartamento>($"Já existe um morador cadastrado com o Tipo de Documento ID: {model.TipoDocumentoId} com o número de documento {model.NumeroDocumento}."));

                var Morador = new Morador
                {
                    NumeroDocumento = model.NumeroDocumento,
                    TipoDocumentoId = model.TipoDocumentoId,
                    Nome = model.Nome,
                    DataNascimento = model.DataNascimento,
                    Idade = model.Idade,
                    SexoId = model.SexoId,
                    Telefone = model.Telefone,
                    Email = model.Email
                };

                await Dbcontext.Moradores.AddAsync(Morador);
                await Dbcontext.SaveChangesAsync();

                return Created("", new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Morador cadastrado com sucesso.",
                    NomeMorador = model.Nome
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorController {this.GetType().Name} Code 03 - {ex.Message + ex.StackTrace}"));
            }
        }

        [HttpPut("v1/morador/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EditorMoradorViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var morador = await Dbcontext.Moradores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (morador == null)
                    return NotFound(new ReturnViewModel<Apartamento>($"Morador ID: {id} não encontrado."));


                if (model.NumeroDocumento != null)
                {
                    morador.NumeroDocumento = model.NumeroDocumento;
                }

                if (model.TipoDocumentoId != null)
                {
                    morador.TipoDocumentoId = model.TipoDocumentoId;
                }

                if (model.Nome != null)
                {
                    morador.Nome = model.Nome;
                }

                if (model.DataNascimento != null)
                {
                    morador.DataNascimento = model.DataNascimento;
                }

                if (model.Idade != null)
                {
                    morador.Idade = model.Idade;
                }

                if (model.SexoId != null)
                {
                    morador.SexoId = model.SexoId;
                }

                if (model.Telefone != null)
                {
                    morador.Telefone = model.Telefone;
                }

                if (model.Email != null)
                {
                    morador.Email = model.Email;
                }


                Dbcontext.Moradores.Update(morador);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Morador atualizado com sucesso.",
                    NomeMorador = model.Nome
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorController {this.GetType().Name} Code 04 - {ex.Message + ex.StackTrace}"));
            }
        }

        [HttpDelete("v1/morador/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var morador = await Dbcontext.Moradores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (morador == null)
                    return NotFound(new ReturnViewModel<Apartamento>($"Morador ID: {id} não encontrado."));

                Dbcontext.Moradores.Remove(morador);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Morador removido com sucesso.",
                    NomeMorador = morador.Nome
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class MoradorController {this.GetType().Name} Code 05 - {ex.Message + ex.StackTrace}"));
            }
        }
    }
}
