using System.Security.Claims;

namespace tourney.api.Extensions
{
    public static class ClaimsPrincipalExtension
    {
       public static int GetClaimValue(this ClaimsPrincipal user, string claimType)
       {
            var userId = user.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;

            return int.TryParse(userId, out var userIdInt) ? userIdInt : 0;
       }
    }
}