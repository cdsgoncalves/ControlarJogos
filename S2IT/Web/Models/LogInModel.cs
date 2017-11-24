using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LogInModel
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "O campo email é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool Lembrar { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}