using EasyException.Models;
using System;
using System.Threading.Tasks;

namespace EasyException.Abstractions
{
    public interface IErrorHandlingService
    {
        /// <summary>
        /// When and Exception is Raised this HandleException is invoked
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        Task<ErrorResponse> HandleException(Exception exception);
    }
}
