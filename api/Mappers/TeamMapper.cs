using tourney.api.Dtos.Team;
using tourney.api.Models;

namespace tourney.api.Mappers;
public static class TeamMapper 
{
   public static TeamDto AsPartialResponse(this Team teamModel)
   {
       return new TeamDto
       {
           Id = teamModel.Id,
           Name = teamModel.Name,
           Description = teamModel.Description,
           Status = teamModel.Status,
       };
   }
}