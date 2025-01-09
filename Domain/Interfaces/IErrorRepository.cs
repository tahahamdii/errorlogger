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
        List<Error> GetErrors(DateTime startDate, DateTime endDate, string severity, string category);
    }
}
