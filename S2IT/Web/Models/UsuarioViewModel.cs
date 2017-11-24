using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "O campo email é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public string CaminhoFoto { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
        public DateTime CadastradoEm { get; set; }
        public bool Ativo { get; set; }

        public string Foto => string.IsNullOrEmpty(CaminhoFoto)
            ? "/Content/img/default_user.png"
            : "/Arquivos/" + CaminhoFoto;
    }
}