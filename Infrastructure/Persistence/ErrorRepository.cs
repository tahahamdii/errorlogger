using Domain.Entities;
using Domain.Interfaces;
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
    }
}
