using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class TeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task CreateTeamAsync(string name, List<int> employeeIds)
        {
            var team = new Team
            {
                Name = name,
                Employees = employeeIds.Select(id => new Employe { Id = id }).ToList()
            };

            await _teamRepository.AddTeamAsync(team);
        }

        public async Task AssignEmployeeAsync(int teamId, int employeeId)
        {
            await _teamRepository.AssignEmployeeToTeamAsync(teamId, employeeId);
        }
    }
}
