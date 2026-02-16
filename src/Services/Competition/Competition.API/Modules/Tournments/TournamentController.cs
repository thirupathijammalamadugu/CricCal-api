using Carter;
using AutoMapper;
using Competition.API.Modules.Tournments;
using System.Security.Claims;

namespace Competition.API.Modules.Tournments
{
    public class TournamentController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/v1/tournaments")
                .WithTags("Tournaments");

            group.MapPost("/", CreateTournament)
                .WithName("CreateTournament")
                .Produces<Tournament>(StatusCodes.Status201Created)
                .RequireAuthorization("WritePolicy");

            group.MapGet("/", GetAllTournaments)
                .WithName("GetAllTournaments")
                .Produces<IEnumerable<Tournament>>(StatusCodes.Status200OK)
                .RequireAuthorization("ReadPolicy");

            group.MapGet("/{id}", GetTournamentById)
                .WithName("GetTournamentById")
                .Produces<Tournament>(StatusCodes.Status200OK)
                .RequireAuthorization("ReadPolicy");
        }

        private static async Task<IResult> CreateTournament(TournamentCreateRequest request, ITournamentService tournamentService)
        {
            var tournamentId = await tournamentService.CreateTournamentAsync(request);
            return Results.Created($"/api/v1/tournaments/{tournamentId}", new { Id = tournamentId });
        }

        private static async Task<IResult> GetAllTournaments(ITournamentService tournamentService, ClaimsPrincipal user)
        {
            var tournaments = await tournamentService.GetAllTournamentsAsync(user);
            return Results.Ok(tournaments);
        }

        private static async Task<IResult> GetTournamentById(Guid id, ITournamentService tournamentService)
        {
            var tournament = await tournamentService.GetTournamentByIdAsync(id);
            if (tournament == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(tournament);
        }
    }
}