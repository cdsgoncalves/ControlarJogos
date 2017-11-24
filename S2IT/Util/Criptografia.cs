using System;
using System.Text;
using System.Security.Cryptography;

namespace Util
{
    public static class Criptografia
    {
        private static readonly string Salt = Configuracao.SaltKey;

        /// <summary>
        /// Método para criptografar dados usando chave privada e SHA256Managed
        /// </summary>
        /// <param name="valor">valor a ser criptografado</param>
        /// <returns>string criptografada</returns>
        public static string Criptografar(string valor)
        {
            HashAlgorithm hash = new SHA256Managed();
            // computa o hash da password com o salt
            var plainTextBytes = Encoding.UTF8.GetBytes(Salt + valor);
            var hashBytes = hash.ComputeHash(plainTextBytes);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool ValorCorretamenteCriptografado(string valorOriginal, string chaveCriptografado)
        {
            return chaveCriptografado.Equals(Criptografar(valorOriginal));
        }
    }
}