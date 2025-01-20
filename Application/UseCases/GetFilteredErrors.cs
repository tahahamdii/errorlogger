using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
namespace Application.UseCases
{
    public class GetFilteredErrors
    {

        private readonly IError _errorRepository;

        public GetFilteredErrors(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }
    }
}
