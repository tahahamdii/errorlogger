using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
namespace Application.UseCases
{
    public class GetFilteredErrors
    {

        private readonly IErrorRepository _errorRepository;

        public GetFilteredErrors(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        public async Task<PagedResult<Error>> ExecuteAsync(
            DateTime startDate,
            DateTime endDate,
            string severity,
            int? assignedEmployeeId,
            int page,
            int pageSize
            )
        {
            return await _errorRepository.GetErrorsAsyncc(
                startDate,
                endDate,
                severity,
                assignedEmployeeId,
                page,
                pageSize
                );
        }
    }
}
