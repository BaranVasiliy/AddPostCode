using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.Entities;
using AddPostalCodeToService.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AddPostalCodeToService.DAL.Repositories
{
    class PostalCodeRepository : GenericRepository<int, PostalCode>, IPostalCodeRepository
    {
        public PostalCodeRepository(ContextDb context) : base(context)
        {

        }

        public async Task<List<PostalCode>> GetPosCodeByServiceId(Guid id)
        {
            return await Context.PostalCodes.Where(p => p.ServiceId == id).ToListAsync();
        }
    }
}