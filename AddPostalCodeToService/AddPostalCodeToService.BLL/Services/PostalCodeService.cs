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
            List<PostalCode> dbPostalCodes = await _unitOfWork.PostalCodeRepository.GetPosCodeByServiceId(id);

            postCode = postCode.Where(t => dbPostalCodes.All(p => p.Code != t)).ToList();
            
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
                _unitOfWork.PostalCodeRepository.Add(postalCode);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}