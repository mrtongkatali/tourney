using AutoMapper;
using tourney.api.Dtos.Tournament;
using tourney.api.Models;

namespace tourney.api.Mappers;
public static class TournamentMapper
{
    public static TournamentDto AsResponse(this Tournament tournamentModel)
    {
        return new TournamentDto
        {
            Id = tournamentModel.Id,
            UserId = tournamentModel.UserId,
            Name = tournamentModel.Name,
            Description = tournamentModel.Description,
            StartDate = tournamentModel.StartDate,
            EndDate = tournamentModel.EndDate,
            PrizePool = tournamentModel.PrizePool,
            PrizePoolCurrency = tournamentModel.PrizePoolCurrency,
            ParticipantSize = tournamentModel.ParticipantSize,
            Status = tournamentModel.Status,
            TournamentType = tournamentModel.TournamentType,
            // Teams = tournamentModel.Teams.Select(t => t.AsResponse()).ToList(),
        };
    }
    public static TournamentDto AsPartialResponse(this Tournament tournamentModel)
    {
        return new TournamentDto
        {
            Id = tournamentModel.Id,
            UserId = tournamentModel.UserId,
            Name = tournamentModel.Name,
            Description = tournamentModel.Description,
            StartDate = tournamentModel.StartDate,
            EndDate = tournamentModel.EndDate,
            PrizePool = tournamentModel.PrizePool,
            PrizePoolCurrency = tournamentModel.PrizePoolCurrency,
            ParticipantSize = tournamentModel.ParticipantSize,
            Status = tournamentModel.Status,
            TournamentType = tournamentModel.TournamentType,
        };
    }
    public static Tournament ToModel(this CreateTournamentDto dto)
    {
        return new Tournament
        {
            Name = dto.Name ?? string.Empty, 
            Description = dto.Description ?? string.Empty,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            PrizePool = dto.PrizePool,
            PrizePoolCurrency = dto.PrizePoolCurrency ?? string.Empty,
            ParticipantSize = dto.ParticipantSize,
            TournamentType = dto.TournamentType,
        };
    }
}

public class TournamentProfile: Profile
{
    public TournamentProfile()
    {
        CreateMap<PatchTournamentDto, Tournament>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, context) =>
            {
                // Check if the source member is explicitly set (not null)
                return srcMember != null;
            })); 
    }
}