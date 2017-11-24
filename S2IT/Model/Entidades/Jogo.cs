namespace Model.Entidades
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdUsuarioOwner { get; set; }
        public int IdUsuarioAtual { get; set; }
        public bool Ativo { get; set; }

        public Usuario Owner { get; set; }
        public Usuario UsuarioAtual { get; set; }
    }
}