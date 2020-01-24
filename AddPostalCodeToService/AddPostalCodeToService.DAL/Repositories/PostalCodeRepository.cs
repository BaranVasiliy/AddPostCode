using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.Entities;
using AddPostalCodeToService.DAL.Repositories.Contracts;

namespace AddPostalCodeToService.DAL.Repositories
{
    class PostalCodeRepository : GenericRepository<int, PostalCode>, IPostalCodeRepository
    {
        public PostalCodeRepository(ContextDb context) : base(context)
        {

        }

        public Task<List<PostalCode>> GetPosCodeByServiceId(Guid id)
        {
           
        }
    }
}