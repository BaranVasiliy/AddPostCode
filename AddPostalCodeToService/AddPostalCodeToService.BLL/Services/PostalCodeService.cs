using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AddPostalCodeToService.BLL.DTOs.PostalCodeDto;
using AddPostalCodeToService.BLL.Services.Contracts;
using AddPostalCodeToService.DAL.Entities;
using AddPostalCodeToService.DAL.UnitOfWork.Contracts;
using AutoMapper;

namespace AddPostalCodeToService.BLL.Services
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly IUnitOFWork _unitOfWork;

        private readonly DateTime _time = DateTime.UtcNow;

        public PostalCodeService(IUnitOFWork unitOfWork)
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

                _unitOfWork.PostalCodeRepository.Add(postalCode);
            }
            await _unitOfWork.SaveAsync();
        }
    }
    
}
