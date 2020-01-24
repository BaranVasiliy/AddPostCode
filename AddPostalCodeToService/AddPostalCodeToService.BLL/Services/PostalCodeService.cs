using AddPostalCodeToService.BLL.Services.Contracts;
using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.Entities;
using AddPostalCodeToService.DAL.UnitOfWork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddPostalCodeToService.BLL.Services
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly IUnitOFWork _unitOfWork;

        private readonly DateTime _time = DateTime.UtcNow;

        public PostalCodeService(IUnitOFWork unitOfWork, ContextDb context) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddPostalCodeToServiceAsync(Guid id, List<string> postCode)
        {
            foreach (var code in postCode)
            {
                PostalCode postalCode = new PostalCode
                {
                    ServiceId = id,
                    Code = code,
                    CreatedAt = _time,
                    UpdatedAt = _time,
                    IsDeleted = false
                };
                if ( != code)
                {
                    _unitOfWork.PostalCodeRepository.Add(postalCode);
                }
            }

            List<PostalCode> codes = (await _unitOfWork.PostalCodeRepository.GetAllAsync()).ToList();

            await _unitOfWork.SaveAsync();
                
        }
    }
    
}