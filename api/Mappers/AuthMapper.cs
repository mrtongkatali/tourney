using tourney.api.Dtos.Auth;
using tourney.api.Models;

namespace tourney.api.Mappers
{
    public static class AuthMapper
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

        public static User ToModel(this RegisterUserRequestDto dto)
        {
            return new User
            {
                Email = dto.Email,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }
    }
}