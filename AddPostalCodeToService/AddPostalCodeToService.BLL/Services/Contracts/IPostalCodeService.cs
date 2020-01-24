using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddPostalCodeToService.BLL.DTOs.PostalCodeDto;

namespace AddPostalCodeToService.BLL.Services.Contracts
{
    public interface IPostalCodeService
    {
        Task AddPostalCodeToServiceAsync(Guid id, List<string> postCode);
    }
}