using System;
using System.Collections.Generic;

namespace Model.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Jogo> MeusJogos { get; set; }
        public ICollection<Jogo> JogosEmprestados { get; set; }
    }
}