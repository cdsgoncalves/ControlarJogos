using Model.Entidades;
using System.Collections.Generic;

namespace Web.Models
{
    public class DashboardViewModel
    {
        public List<Jogo> MeusJogos { get; set; }
        public List<Jogo> JogosEmprestados { get; set; }

        public bool MostrarMaisFuncionarios { get; set; }
        public bool MostrarMaisLinks { get; set; }
    }
}