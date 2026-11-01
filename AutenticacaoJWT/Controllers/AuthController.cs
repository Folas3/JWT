
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutenticacaoJWT.Models;

namespace AutenticacaoJWT.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Usuário e senha fixos
            string usuarioCorreto = "admin";
            string senhaCorreta = "123456";

            // Verifica as credenciais
            if (login.Usuario != usuarioCorreto ||
                login.Senha != senhaCorreta)
            {
                return Unauthorized("Usuário ou senha incorretos.");
            }

            // Obtém a chave JWT
            var chave = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(chave!));

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            // Cria as informações do usuário
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Usuario)
            };

            // Cria o token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            // Converte o token para texto
            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(token);

            // Retorna o token
            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                token = tokenString
            });
        }
    }
}
