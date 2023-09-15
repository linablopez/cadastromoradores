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
    public class PredioController : ControllerBase
    {
        [HttpGet("v1/predios")]
        public async Task<IActionResult> GetAll([FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var predios = await Dbcontext.Predios.AsNoTracking().ToListAsync();

                return Ok(new ReturnViewModel<List<Predio>>(predios));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class PredioController {this.GetType().Name} Code 01 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpGet("v1/predio/{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var predio = await Dbcontext.Predios.FirstOrDefaultAsync(x => x.Id == id);

                if (predio == null)
                    return NotFound(new ReturnViewModel<Predio>($"O Predio ID: {id} não foi encontrado."));

                return Ok(new ReturnViewModel<Predio>(predio));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class PredioController {this.GetType().Name} Code 02 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPost("v1/predio/")]
        public async Task<IActionResult> Post([FromBody] RegisterPredioViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ReturnViewModel<string>(ModelState.GetErrors()));

                var predioValidandoBancoDeDados = await Dbcontext.Predios.AsNoTracking().Where(x => x.NomePredio == model.NomePredio).ToListAsync();

                if (predioValidandoBancoDeDados.Any())
                    return NotFound(new ReturnViewModel<Usuario>($"Prédio ID: {model.NomePredio} já existe no cadastro."));

                var Predio = new Predio
                {
                    NomePredio = model.NomePredio,
                    Rua = model.Rua,
                    Numero = model.Numero,
                    Bairro = model.Bairro,
                    Cidade = model.Cidade,
                    Estado = model.Estado,
                    Pais = model.Pais,
                    CEP = model.CEP,
                    DataConstrucao = model.DataConstrucao,
                    NumAndares = model.NumAndares
                };

                await Dbcontext.Predios.AddAsync(Predio);
                await Dbcontext.SaveChangesAsync();

                return Created("", new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Predio cadastrado com sucesso.",
                    Nome = model.NomePredio
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class PredioController {this.GetType().Name} Code 03 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPut("v1/predio/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EditorPredioViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var predio = await Dbcontext.Predios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (predio == null)
                    return NotFound(new ReturnViewModel<Usuario>($"Prédio ID: {id} não encontrado."));


                if (model.NomePredio != null)
                {
                    predio.NomePredio = model.NomePredio;
                }

                if (model.Rua != null)
                {
                    predio.Rua = model.Rua;
                }

                if (model.Numero != null)
                {
                    predio.Numero = model.Numero;
                }

                if (model.Bairro != null)
                {
                    predio.Bairro = model.Bairro;
                }

                if (model.Cidade != null)
                {
                    predio.Cidade = model.Cidade;
                }

                if (model.Estado != null)
                {
                    predio.Estado = model.Estado;
                }

                if (model.Pais != null)
                {
                    predio.Pais = model.Pais;
                }

                if (model.CEP != null)
                {
                    predio.CEP = model.CEP;
                }

                if (model.DataConstrucao != null)
                {
                    predio.DataConstrucao = model.DataConstrucao;
                }

                if (model.NumAndares != null)
                {
                    predio.NumAndares = model.NumAndares;
                }

                Dbcontext.Predios.Update(predio);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Prédio atualizado com sucesso.",
                    NomePredio = predio.NomePredio
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class PredioController {this.GetType().Name} Code 04 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpDelete("v1/predio/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var predio = await Dbcontext.Predios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (predio == null)
                    return NotFound(new ReturnViewModel<Usuario>($"Predio ID: {id} não encontrado."));

                Dbcontext.Predios.Remove(predio);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Prédio removido com sucesso.",
                    NomePredio = predio.NomePredio
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 07 - {ex.Message + ex.StackTrace}"));
            }
        }
    }
}
