using Siscon_API_Backend.Data;
using Siscon_API_Backend.Extensions;
using Siscon_API_Backend.Models;
using Siscon_API_Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siscon_API_Backend.ViewModels.Register;
using Siscon_API_Backend.Services;
using Siscon_API_Backend.ViewModels.Editor;
using Siscon_API_Backend.ViewModels.Validate;

namespace Siscon_API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("v1/usuarios")]
        public async Task<IActionResult> GetAll([FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var usuarios = await Dbcontext.Usuarios.AsNoTracking().ToListAsync();

                return Ok(new ReturnViewModel<List<Usuario>>(usuarios));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 01 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpGet("v1/usuario/{LoginNome}")]
        public async Task<IActionResult> GetLogin([FromRoute] string LoginNome, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var usuario = await Dbcontext.Usuarios.FirstOrDefaultAsync(x => x.LoginNome == LoginNome);

                if (usuario == null)
                    return NotFound(new ReturnViewModel<Usuario>($"LoginName: {LoginNome} não encontrado."));

                return Ok(new ReturnViewModel<Usuario>(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 02 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPost("v1/usuario/")]
        public async Task<IActionResult> Post([FromBody] RegisterUsuarioViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ReturnViewModel<string>(ModelState.GetErrors()));

                var usuarioValidandoBancoDeDados = await Dbcontext.Usuarios.AsNoTracking().Where(x => x.LoginNome == model.LoginNome).ToListAsync();

                if (usuarioValidandoBancoDeDados.Any())
                    return NotFound(new ReturnViewModel<Usuario>($"Login: {model.LoginNome} já existe no cadastro."));

                var Usuario = new Usuario
                {
                    LoginNome = model.LoginNome,
                    Senha = Criptografia.StringToBase64(model.Senha),
                    NomeUsuario = model.NomeUsuario,
                    DataCriacao = DateTime.Now,
                };

                await Dbcontext.Usuarios.AddAsync(Usuario);
                await Dbcontext.SaveChangesAsync();

                return Created("", new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Usuário cadastrado com sucesso.",
                    Login = model.LoginNome
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 03 - {ex.Message + ex.StackTrace}"));
            }
        }

        [HttpPost("v1/validaSenhaUsuario/")]
        public async Task<IActionResult> validaSenhaUsuario([FromBody] ValidateUsuarioViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ReturnViewModel<string>(ModelState.GetErrors()));

                var validaUsuarioAcesso = await Dbcontext.Usuarios.AsNoTracking()
                    .Where(x => x.LoginNome == model.LoginNome
                             && x.Senha == Criptografia.StringToBase64(model.Senha)).ToListAsync();

                if (validaUsuarioAcesso.Count == 0)
                {
                    return Ok(new ReturnViewModel<dynamic>(new
                    {
                        Usuario = model.LoginNome,
                        LoginValidado = false
                    }));
                }

               return Ok(new ReturnViewModel<dynamic>(new
                {
                    Usuario = model.LoginNome,
                    LoginValidado = true
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 04 - {ex.Message + ex.StackTrace}"));
            }
        }

        [HttpPut("v1/usuario/{LoginNome}")]
        public async Task<IActionResult> Put([FromRoute] string LoginNome, [FromBody] EditorUsuarioViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var usuario = await Dbcontext.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.LoginNome == LoginNome);

                if (usuario == null)
                    return NotFound(new ReturnViewModel<Usuario>($"Login: {LoginNome} não encontrado."));

                if (model.NomeUsuario != null)
                {
                    usuario.NomeUsuario = model.NomeUsuario;
                }

                Dbcontext.Usuarios.Update(usuario);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Usuário atualizado com sucesso.",
                    LoginNome = usuario.LoginNome
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 05 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpPut("v1/atualizaSenhaUsuario/{LoginNome}")]
        public async Task<IActionResult> atualizaSenhaUsuario([FromRoute] string LoginNome, [FromBody] EditorUsuarioSenhaViewModel model, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var usuario = await Dbcontext.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.LoginNome == LoginNome);

                if (usuario == null)
                    return NotFound(new ReturnViewModel<Usuario>($"Login: {LoginNome} não encontrado."));

                if (model.senha != null)
                {
                    usuario.Senha = Criptografia.StringToBase64(model.senha);
                }

                Dbcontext.Usuarios.Update(usuario);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Senha atualizada com sucesso.",
                    LoginNome = usuario.LoginNome
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 06 - {ex.Message + ex.StackTrace}"));
            }
        }
        [HttpDelete("v1/usuario/{LoginNome}")]
        public async Task<IActionResult> Delete([FromRoute] string LoginNome, [FromServices] SisconDataContext Dbcontext)
        {
            try
            {
                var usuario = await Dbcontext.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.LoginNome == LoginNome);

                if (usuario == null)
                    return NotFound(new ReturnViewModel<Usuario>($"LoginNome: {LoginNome} não encontrado."));

                Dbcontext.Usuarios.Remove(usuario);
                await Dbcontext.SaveChangesAsync();

                return Ok(new ReturnViewModel<dynamic>(new
                {
                    Mensagem = "Usuário removido com sucesso.",
                    LoginNome = usuario.LoginNome
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnViewModel<string>($"Siscon_API_Backend - Class UsuarioController {this.GetType().Name} Code 07 - {ex.Message + ex.StackTrace}"));
            }
        }
    }
}
