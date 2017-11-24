using Web.Models;
using System.Web.Mvc;

namespace Web.Helpers
{
    public static class HtmlMessages
    {
        /// <summary>
        /// Recebe a mensagem e o nome do método e envia para ser tratado como TempData de sucesso
        /// </summary>
        /// <param name="actionResult">ação</param>
        /// <param name="message">mensage</param>
        /// <returns>ActionResult</returns>
        public static ActionResult Success(this ActionResult actionResult, string message)
        {
            return new TempDataActionResult(actionResult, HtmlMessageModel.SuccessMessage(message));
        }

        /// <summary>
        /// Recebe a mensagem e o nome do método e envia para ser tratado como TempData de aviso
        /// </summary>
        /// <param name="actionResult">ação</param>
        /// <param name="message">mensagem</param>
        /// <returns>ActionResult</returns>
        public static ActionResult Warning(this ActionResult actionResult, string message)
        {
            return new TempDataActionResult(actionResult, HtmlMessageModel.WarningMessage(message));
        }

        /// <summary>
        /// Recebe a mensagem e o nome do método e envia para ser tratado como TempData de erro
        /// </summary>
        /// <param name="actionResult">ação</param>
        /// <param name="message">mensagem</param>
        /// <returns>ActionResult</returns>
        public static ActionResult Error(this ActionResult actionResult, string message)
        {
            return new TempDataActionResult(actionResult, HtmlMessageModel.ErrorMessage(message));
        }

        /// <summary>
        /// Recebe a mensagem e o nome do método e envia para ser tratado como TempData de informação
        /// </summary>
        /// <param name="actionResult">ação</param>
        /// <param name="message">mensagem</param>
        /// <returns>ActionResult</returns>
        public static ActionResult Info(this ActionResult actionResult, string message)
        {
            return new TempDataActionResult(actionResult, HtmlMessageModel.InfoMessage(message));
        }
    }

    /// <summary>
    /// Classe que trata a mensagem e o método e devolve como TempData 
    /// </summary>
    public class TempDataActionResult : ActionResult
    {
        private readonly ActionResult _actionResult;
        private readonly HtmlMessageModel _message;

        /// <summary>
        ///  Construtor da Classe TempDataActionResult
        /// </summary>
        /// <param name="actionResult">ação</param>
        /// <param name="message">mensagem</param>
        public TempDataActionResult(ActionResult actionResult, HtmlMessageModel message)
        {
            _actionResult = actionResult;
            _message = message;
        }

        /// <summary>
        /// Insere a Mensagem em um TempData
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData["Message"] = _message;
            _actionResult.ExecuteResult(context);
        }
    }
}