using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IErrorRepository
    {
        void LogError(Error error);
        Task AddErrorAsync(Error error);

        List<Error> GetErrors(DateTime startDate, DateTime endDate, string severity, string category);
        Task<Error> GetErrorByIdAsync(int id);
        Task<IEnumerable<Error>> GetErrorsAsync(DateTime? startDate, DateTime? endDate, string severity);
        Task UpdateErrorAsync(Error error);
        Task<PagedResult<Error>> GetErrorsAsyncc(
           DateTime? startDate, DateTime? endDate, string severity, int? assignedEmployeeId, int page, int pageSize
           );
    }
}
