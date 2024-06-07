namespace ApiGestao.Modelos
{
    public class Pessoa
    {
        public Pessoa(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
