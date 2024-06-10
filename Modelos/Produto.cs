namespace ApiGestao.Modelos
{
    public class Produto
    {
        public Produto(Guid id, string nome, int quantidade)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
