using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.Repositories;
using AddPostalCodeToService.DAL.Repositories.Contracts;
using AddPostalCodeToService.DAL.UnitOfWork.Contracts;

namespace AddPostalCodeToService.DAL.UnitOfWork
{
    public class EfUnitOfWork : IUnitOFWork
    {
        private readonly ContextDb _context;

        private IPostalCodeRepository _userRepository;

        public EfUnitOfWork(ContextDb context)
        {
            _context = context;
        }

        public IPostalCodeRepository PostalCodeRepository => _userRepository ?? (_userRepository = new PostalCodeRepository(_context));

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
