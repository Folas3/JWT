
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoJWT.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("perfil")]
        [Authorize]
        public IActionResult Perfil()
        {
            // Obtém o nome do usuário autenticado
            string usuario = User.Identity!.Name!;

            return Ok(new
            {
                mensagem = "Acesso autorizado!",
                usuario = usuario
            });
        }
    }
}
