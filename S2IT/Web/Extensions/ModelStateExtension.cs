using System;
using System.Linq;
using System.Web.Mvc;

namespace Web.Extensions
{
    public static class ModelStateExtension
    {
        public static string TodosErros(this ModelStateDictionary modelState)
        {
            var erros = from ms in modelState
                        where ms.Value.Errors.Any()
                        let fieldKey = ms.Key
                        let errors = ms.Value.Errors
                        from error in errors
                        select new Tuple<string, string>(fieldKey, error.ErrorMessage);

            var resultado = erros.Aggregate("<ul>", (current, erro) => current + ("<li>" + erro + "</li>"));
            resultado += "</ul>";
            return resultado;
        }
    }
}