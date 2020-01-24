using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddPostalCodeToService.DAL.Entities;

namespace AddPostalCodeToService.DAL.Repositories.Contracts
{
    public interface IPostalCodeRepository : IGenericRepository<int, PostalCode>
    {
        Task<List<PostalCode>> GetPosCodeByServiceId(Guid id);
    }
}