namespace tourney.api.Helpers;

public class ApiResponse<T>
{
    public bool Success { get; set; } = true;
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;

    public Dictionary<string, List<string?>> Errors { get; set; }

    public ApiResponse(bool success, T? data, string message, Dictionary<string, List<string?>> errors)
    {
        Success = success;
        Data = data;
        Message = message;
        Errors = errors;
    }
}
public class ApiResponseHelper
{
   public static ApiResponse<T> Success<T>(T? data, string message) 
   {
       return new ApiResponse<T>(true, data, message, []);
   }

   public static ApiResponse<string> Success(string message)
   {
       return new ApiResponse<string>(true, null, message, []);
   }

   public static ApiResponse<T> Error<T>(string message, Dictionary<string, List<string?>> errors)
   {
       return new ApiResponse<T>(false, default, message, errors);
   }

   public static ApiResponse<string> Error(string message)
   {
       return new ApiResponse<string>(false, null, message, []);
   }
}