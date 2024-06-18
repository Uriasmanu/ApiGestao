namespace ApiGestao.Modelos
{
    public class Cliente
    {
        public Cliente(Guid id, string nome, int telefone)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
    }
}
