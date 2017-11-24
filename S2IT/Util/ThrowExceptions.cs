using Util.Exceptions;

namespace Util
{
    /// <summary>
    ///     Classe com métodos úteis no sistema
    /// </summary>
    public static class ThrowExceptions
    {
        /// <summary>
        ///     Método genérico que lança exceção em caso de nada for deletado
        /// </summary>
        /// <param name="condition">condição de sucesso ou erro</param>
        /// <param name="message">mensagem a ser exibida</param>
        public static void IfTrue(bool condition, string message)
        {
            if (condition)
                throw new S2ItException(message);
        }
    }
}