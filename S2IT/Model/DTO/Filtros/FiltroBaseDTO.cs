namespace Model.DTO.Filtros
{
    public abstract class FiltroBaseDTO
    {
        protected FiltroBaseDTO()
        {
            PaginaAtual = 1;
            TamanhoItensPagina = 50;
        }

        public int PaginaAtual { get; set; }
        public int TamanhoItensPagina { get; set; }
    }
}