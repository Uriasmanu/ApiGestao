using ApiGestao.Banco;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGestao.Rotas
{
    public static class LoginRotas
    {
        public static void MapLoginRotas(this WebApplication app)
        {
            // Rota GET para obter todos os logins
            app.MapGet("/login", async (Context db) =>
            {
                var adm = await db.Login.Select(a => new { a.MeuLogin, a.Senha }).ToListAsync();
                return adm;
            });

            // Rota POST para autenticação de login
            app.MapPost("/login", async (Context db, [FromBody] LoginRequest loginRequest) =>
            {
                var adm = await db.Login
                                  .FirstOrDefaultAsync(a => a.MeuLogin == loginRequest.Email && a.Senha == loginRequest.Password);

                if (adm == null)
                {
                    return Results.Unauthorized();
                }

                return Results.Ok(new { Message = "Login bem-sucedido" });
            });
        }
    }
}
