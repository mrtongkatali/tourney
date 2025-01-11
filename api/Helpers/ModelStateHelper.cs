using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace api.Helpers
{
    public class ModelStateHelper
    {
        public static List<string> GetErrors(ModelStateDictionary modelState)
        {
            return modelState.Values
                .SelectMany(s => s.Errors)
                .Select(s => s.ErrorMessage)
                .ToList();
        }
    }
}