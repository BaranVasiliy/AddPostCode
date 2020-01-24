using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddPostalCodeToService.BLL.Services.Contracts
{
    public interface IPostalCodeService
    {
        Task AddPostalCodeToServiceAsync(Guid id, List<string> postCode);
    }
}