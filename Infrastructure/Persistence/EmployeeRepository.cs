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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employe>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Include(e => e.AssignedErrors).ToListAsync();
        }

        public async Task<Employe> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.Include(e => e.AssignedErrors).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}