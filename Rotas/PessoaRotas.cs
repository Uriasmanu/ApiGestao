using ApiGestao.Modelos;

namespace ApiGestao.Rotas
{
    public static class PessoaRotas
    {
        public static List<Pessoa> Pessoas = new List<Pessoa>()
        {
            new Pessoa(Guid.NewGuid(), "Neymar"),
            new Pessoa(Guid.NewGuid(), "Messi"),
            
        };

        public static void MapPessoaRotas (this WebApplication app)
        {
            app.MapGet("/pessoa", () => Pessoas);

            app.MapGet("/pessoa/{nome}", (string nome) => Pessoas.Find(x => x.Nome == nome));

        }
    }
}
