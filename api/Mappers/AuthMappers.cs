using api.Dtos.Auth;
using tourney.Models;

namespace api.Mappers
{
    public static class AuthMappers
    {
        public static AuthDto AsPartialResponse(this User userModel)
        {
            return new AuthDto
            {
                Id = userModel.Id,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
        }
    }
}