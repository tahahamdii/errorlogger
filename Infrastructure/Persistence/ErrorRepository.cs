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
    public class ErrorRepository : IErrorRepository
    {
        private readonly AppDbContext _context;

        public ErrorRepository(AppDbContext context)
        {
            _context = context;
        }

        public void LogError(Error error)
        {
            _context.Errors.Add(error);
            _context.SaveChanges();
        }

        public List<Error> GetErrors(DateTime startDate, DateTime endDate, string severity, string category)
        {
            return _context.Errors
                .Where(e => e.Timestamp >= startDate && e.Timestamp <= endDate
                            && e.Severity == severity
                            && e.Category == category)
                .ToList();
        }

        //public void LogError(Error error)
        //{
        //    throw new NotImplementedException();
        //}

        List<Error> IErrorRepository.GetErrors(DateTime startDate, DateTime endDate, string severity, string category)
        {
            throw new NotImplementedException();
        }

        public async Task AddErrorAsync(Error error)
        {
            await _context.Errors.AddAsync(error);
            await _context.SaveChangesAsync();
        }

        public async Task<Error> GetErrorByIdAsync(int id)
        {
            return await _context.Errors.Include(e => e.AssignedEmployee).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Error>> GetErrorsAsync(DateTime? startDate, DateTime? endDate, string severity)
        {
            return await _context.Errors
                .Where(e => (startDate == null || e.Timestamp >= startDate) &&
                            (endDate == null || e.Timestamp <= endDate) &&
                            (string.IsNullOrEmpty(severity) || e.Severity == severity))
                .ToListAsync();
        }

        public Task UpdateErrorAsync(Error error)
        {
            throw new NotImplementedException();
        }
    }
}
