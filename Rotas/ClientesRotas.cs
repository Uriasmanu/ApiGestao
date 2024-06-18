using ApiGestao.Banco;
using ApiGestao.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiGestao.Rotas
{
    public static class ClientesRotas
    {
        public static void MapClienteRotas(this WebApplication app)
        {
            // Lista os Clientes
            app.MapGet("/cliente", async (Context db) =>
            {
                var clientes = await db.Clientes.Select(p => new { p.Id, p.Nome, p.Telefone }).ToListAsync();
                    return clientes;
            });

            // Busca pelo nome
            app.MapGet("/cliente/{nome}", async (string nome, Context db) =>
            {
                var clente = await db.Clientes.FirstOrDefaultAsync(x => x.Nome == nome);
                return clente is not null ? Results.Ok(clente) : Results.NotFound();
            });

            // Adiciona um novo cliente à lista
            app.MapPost("/cliente", async (Cliente cliente, Context db) =>
            {
                db.Clientes.Add(cliente);
                await db.SaveChangesAsync();
                return Results.Created($"/cliente/{cliente.Id}", cliente);
            });

            // Atualiza um cliente existente
            app.MapPut("/cliente/{id:Guid}", async (Guid id, Cliente cliente, Context db) =>
            {
                var encontrado = await db.Clientes.FindAsync(id);
                if (encontrado is null)
                    return Results.NotFound();

                encontrado.Nome = cliente.Nome;
                encontrado.Telefone = cliente.Telefone;
                // Atualize outros campos conforme necessário

                await db.SaveChangesAsync();
                return Results.Ok(encontrado);
            });

            // Deleta um cliente
            app.MapDelete("/cliente/{id:Guid}", async (Guid id, Context db) =>
            {
                var encontrado = await db.Clientes.FindAsync(id);
                if (encontrado is null)
                    return Results.NotFound();

                db.Clientes.Remove(encontrado);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
