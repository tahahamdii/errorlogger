using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects
                .Include(p => p.Errors)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task AssignErrorToProjectAsync(int projectId, int errorId)
        {
            var project = await GetProjectByIdAsync(projectId);
            if (project != null)
            {
                var error = await _context.Errors.FindAsync(errorId);
                if (error != null && !project.Errors.Contains(error))
                {
                    project.Errors.Add(error);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
