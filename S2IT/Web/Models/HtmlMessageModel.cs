using System;

namespace Web.Models
{
    [Serializable]
    public class HtmlMessageModel
    {
        #region === Propriedades ===
        public string Type { get; set; }
        public string Message { get; set; }
        #endregion

        #region === Variáveis ===
        internal const string Success = "success";
        internal const string Info = "info";
        internal const string Warning = "warning";
        internal const string Error = "danger";
        #endregion

        /// <summary>
        /// Método que devolve o modelo de mensagem de informação
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static HtmlMessageModel InfoMessage(string message)
        {
            return new HtmlMessageModel { Message = message, Type = Info };
        }

        /// <summary>
        /// Método que devolve o modelo de mensagem de sucesso
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static HtmlMessageModel SuccessMessage(string message)
        {
            return new HtmlMessageModel { Message = message, Type = Success };
        }

        /// <summary>
        /// Método que devolve o modelo de mensagem de aviso
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static HtmlMessageModel WarningMessage(string message)
        {
            return new HtmlMessageModel { Message = message, Type = Warning };
        }

        /// <summary>
        /// Método que devolve o modelo de mensagem de erro
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static HtmlMessageModel ErrorMessage(string message)
        {
            return new HtmlMessageModel { Message = message, Type = Error };
        }
    }
}