using Carter;
using System.Security.Claims;

namespace Competition.API.Modules.Squads
{
    public class SquadsController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/v1/squads")
                .WithTags("Squads");

            group.MapPost("/", CreateSquad)
                .WithName("CreateSquad")
                .Produces<Squad>(StatusCodes.Status201Created)
                .RequireAuthorization("WritePolicy");

            group.MapGet("/team/{teamId}", GetSquadByTeamId)
                .WithName("GetSquadByTeamId")
                .Produces<IEnumerable<Squad>>(StatusCodes.Status200OK)
                .RequireAuthorization("ReadPolicy");

            group.MapGet("/{id}", GetSquadById)
                .WithName("GetSquadById")
                .Produces<Squad>(StatusCodes.Status200OK)
                .RequireAuthorization("ReadPolicy");
        }

        private static async Task<IResult> CreateSquad(SquadCreateRequest request, ISquadService squadService)
        {
            var squadId = await squadService.CreateSquadAsync(request);
            return Results.Created($"/api/v1/squads/{squadId}", new { Id = squadId });
        }

        private static async Task<IResult> GetSquadByTeamId(Guid teamId, ISquadService squadService)
        {
            var squads = await squadService.GetSquadByTeamIdAsync(teamId);
            return Results.Ok(squads);
        }

        private static async Task<IResult> GetSquadById(Guid id, ISquadService squadService)
        {
            var squad = await squadService.GetSquadByIdAsync(id);
            return Results.Ok(squad);
        }
    }
}
