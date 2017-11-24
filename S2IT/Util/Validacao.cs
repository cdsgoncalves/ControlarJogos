using System.IO;
using Util.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Util
{
    public static class Validacao
    {
        /// <summary>
        /// Método que retorna verdadeiro se o e-mail for válido e falso caso não.
        /// </summary>
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Expressão regular que vai validar os e-mails
            const string emailRegex = @"^(([^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+"
                                      + @"(\.[^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+)*)|(\"".+\""))@"
                                      + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|"
                                      + @"(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

            // Instância da classe Regex, passando como 
            // argumento sua Expressão Regular 
            var rx = new Regex(emailRegex);

            // Método IsMatch da classe Regex que retorna
            // verdadeiro caso o e-mail passado estiver
            // dentro das regras da sua regex.
            return rx.IsMatch(email);
        }

        public static void ExtensaoImagem(string nomeArquivo)
        {
            var extensoesValidas = new List<string> { ".jpg", ".jpeg", ".png" };

            if (!extensoesValidas.Contains(Path.GetExtension(nomeArquivo)))
                throw new S2ItException($"Extensão do arquivo {nomeArquivo} inválida. Extensões válidas {string.Join(", ", extensoesValidas)}");
        }
    }
}