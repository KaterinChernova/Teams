using Teams.Data;
using Teams.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamsDbContext _teamsDbContext;

        public TeamService(TeamsDbContext teamsDbContext)
        {
            _teamsDbContext = teamsDbContext ?? throw new ArgumentNullException(nameof(teamsDbContext));
        }

        public async Task<TeamDto> Get(int id)
        {
            var team = await _teamsDbContext.Teams
                .Where(x => x.Id == id)
                .Select(x => new TeamDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SportId = x.SportId
                })
                .FirstOrDefaultAsync();

            return team;
        }

        public async Task<TeamDto[]> GetTeamsBySport(int sportId)
        {
            var teams = await _teamsDbContext.Teams
                .Where(x => x.SportId == sportId)
                .Select(x => new TeamDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SportId = x.SportId
                })
                .ToArrayAsync();

            return teams;
        }

        public async Task<int> Create(TeamDto teamDto)
        {
            Team team = new Team();

            AplyDtoToEntity(team, teamDto);

            _teamsDbContext.Teams.Add(team);
            await _teamsDbContext.SaveChangesAsync();

            return team.Id;
        }

        public async Task<int> Update(TeamDto teamDto)
        {
            Team team = _teamsDbContext.Teams.Find(teamDto.Id);

            AplyDtoToEntity(team, teamDto);

            await _teamsDbContext.SaveChangesAsync();

            return team.Id;
        }

        public async Task Delete(int id)
        {
            Team team = _teamsDbContext.Teams.Find(id);

            _teamsDbContext.Teams.Remove(team);
            await _teamsDbContext.SaveChangesAsync();
        }

        private void AplyDtoToEntity(Team team, TeamDto teamDto)
        {
            team.Name = teamDto.Name;
            team.SportId = teamDto.SportId;
        }
    }
}
