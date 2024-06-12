using ApiGestao.Banco;
using Microsoft.EntityFrameworkCore;

namespace ApiGestao.Rotas
{
    public static class LoginRotas
    {
        public static void MapLoginRotas(this WebApplication app)
        {
            app.MapGet("/login", async (Context db) =>
            {
               var adm = await db.Login.Select(a => new { a.MeuLogin, a.Senha }).ToListAsync();
                return adm;
            });

        }
    }
}
