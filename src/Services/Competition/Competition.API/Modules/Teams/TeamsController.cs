using Carter;
using System.Security.Claims;

namespace Competition.API.Modules.Teams
{
    public class TeamsController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/v1/teams")
                .WithTags("Teams");

            group.MapPost("/", CreateTeam)
                .WithName("CreateTeam")
                .Produces<Team>(StatusCodes.Status201Created)
                .RequireAuthorization("WritePolicy");

            group.MapGet("/", GetAllTeams)
                .WithName("GetAllTeams")
                .Produces<IEnumerable<Team>>(StatusCodes.Status200OK)
                .RequireAuthorization("ReadPolicy");

            group.MapGet("/{id}", GetTeamById)
                .WithName("GetTeamById")
                .Produces<Team>(StatusCodes.Status200OK)
                .RequireAuthorization("ReadPolicy");
        }

        private static async Task<IResult> CreateTeam(TeamCreateRequest request, ITeamService teamService)
        {
            var teamId = await teamService.CreateTeamAsync(request);
            return Results.Created($"/api/v1/teams/{teamId}", new { Id = teamId });
        }

        private static async Task<IResult> GetAllTeams(Guid tournamentId, ITeamService teamService)
        {
            var teams = await teamService.GetAllTeamsAsync(tournamentId);
            return Results.Ok(teams);
        }

        private static async Task<IResult> GetTeamById(Guid id, ITeamService teamService)
        {
            var team = await teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(team);
        }
    }
}
