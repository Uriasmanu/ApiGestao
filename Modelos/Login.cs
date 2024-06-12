namespace ApiGestao.Modelos
{
    public class Login
    {
        public Login(string meuLogin, string senha)
        {
            MeuLogin = meuLogin;
            Senha = senha;
        }
        public int Id { get; set; }
        public string MeuLogin {  get; set; }
        public string Senha { get; set; }
    }
}