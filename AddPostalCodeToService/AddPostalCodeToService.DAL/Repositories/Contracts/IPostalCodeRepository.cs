using System;
using AddPostalCodeToService.DAL.Entities;

namespace AddPostalCodeToService.DAL.Repositories.Contracts
{
    public interface IPostalCodeRepository : IGenericRepository<int, PostalCode>
    {
        
    }
}