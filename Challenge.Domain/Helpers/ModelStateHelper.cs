using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Challenge.Domain.Helpers
{
    public static class ModelStateHelper
    {
        public static BadRequestObjectResult RetornarMensagemValidacao(ModelStateDictionary ModelState)
        {
            var listaErro = string.Join(',', ModelState.Where(a => a.Value.ValidationState == ModelValidationState.Invalid).Select(a => " " + a.Value.Errors[0].ErrorMessage).ToList());

            var erro = new
            {                
                alerta = listaErro
            };

            return new BadRequestObjectResult(erro);
        }
    }
}

