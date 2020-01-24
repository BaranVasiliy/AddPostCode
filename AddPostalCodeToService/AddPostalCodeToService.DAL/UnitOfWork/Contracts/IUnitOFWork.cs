using AddPostalCodeToService.DAL.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace AddPostalCodeToService.DAL.UnitOfWork.Contracts
{
    public interface IUnitOFWork : IDisposable
    {
        IPostalCodeRepository PostalCodeRepository { get; }

        Task SaveAsync();
    }
}