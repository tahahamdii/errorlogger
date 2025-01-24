using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeamRepository
    {
        Task AddTeamAsync(Team team);
        Task<Team> GetTeamByIdAsync(int teamId);
        Task AssignEmployeeToTeamAsync(int teamId, int employeeId);
    }
}
