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

        public static Dictionary<string, List<string?>> GetFieldErrors(ModelStateDictionary modelState)
        {
            return modelState
                .Where(kvp => kvp.Value.Errors.Any()) // Only include fields with errors
                .ToDictionary(
                    kvp => kvp.Key, // Use the field name as the key
                    kvp => kvp.Value.Errors
                        .Select(e => !string.IsNullOrEmpty(e.ErrorMessage) ? e.ErrorMessage : e.Exception?.Message)
                        .Where(msg => !string.IsNullOrEmpty(msg)) // Filter out null or empty messages
                        .ToList() // Collect all error messages for the field
                );
        } 
    }
}