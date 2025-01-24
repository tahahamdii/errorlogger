using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task CreateProjectAsync(string name, DateTime startDate, DateTime endDate, int teamId)
        {
            var project = new Project
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Team = new Team { Id = teamId }
            };

            await _projectRepository.AddProjectAsync(project);
        }

        public async Task AssignErrorAsync(int projectId, int errorId)
        {
            await _projectRepository.AssignErrorToProjectAsync(projectId, errorId);
        }
    }
}
