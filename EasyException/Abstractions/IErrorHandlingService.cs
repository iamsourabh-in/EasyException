using EasyException.Models;
using System;
using System.Threading.Tasks;

namespace EasyException.Abstractions
{
    public interface IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception context);
    }
}
