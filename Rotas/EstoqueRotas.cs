using ApiGestao.Banco;
using ApiGestao.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiGestao.Rotas
{
    public static class EstoqueRotas
    {
        public static void MapEstoqueRotas(this WebApplication app)
        {
            // Lista os Produtos
            app.MapGet("/estoque", async (Context db) =>
            {
                var produtos = await db.Produtos.Select(p => new { p.Id, p.Nome, p.Quantidade }).ToListAsync();
                    return produtos;
            });

            // Busca pelo nome
            app.MapGet("/estoque/{nome}", async (string nome, Context db) =>
            {
                var produto = await db.Produtos.FirstOrDefaultAsync(x => x.Nome == nome);
                return produto is not null ? Results.Ok(produto) : Results.NotFound();
            });

            // Adiciona um novo produto à lista
            app.MapPost("/estoque", async (Produto produto, Context db) =>
            {
                db.Produtos.Add(produto);
                await db.SaveChangesAsync();
                return Results.Created($"/estoque/{produto.Id}", produto);
            });

            // Atualiza um produto existente
            app.MapPut("/estoque/{id:Guid}", async (Guid id, Produto produto, Context db) =>
            {
                var encontrado = await db.Produtos.FindAsync(id);
                if (encontrado is null)
                    return Results.NotFound();

                encontrado.Nome = produto.Nome;
                encontrado.Quantidade = produto.Quantidade;
                // Atualize outros campos conforme necessário

                await db.SaveChangesAsync();
                return Results.Ok(encontrado);
            });

            // Deleta um produto
            app.MapDelete("/estoque/{id:Guid}", async (Guid id, Context db) =>
            {
                var encontrado = await db.Produtos.FindAsync(id);
                if (encontrado is null)
                    return Results.NotFound();

                db.Produtos.Remove(encontrado);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
