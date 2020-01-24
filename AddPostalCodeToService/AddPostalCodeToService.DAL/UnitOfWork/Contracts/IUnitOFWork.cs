using System;
using System.Threading.Tasks;
using AddPostalCodeToService.DAL.Repositories.Contracts;

namespace AddPostalCodeToService.DAL.UnitOfWork.Contracts
{
    public interface IUnitOFWork : IDisposable
    {
        IPostalCodeRepository PostalCodeRepository { get; }

        Task SaveAsync();
    }
}