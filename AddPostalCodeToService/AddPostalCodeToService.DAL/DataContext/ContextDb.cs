using AddPostalCodeToService.DAL.Entities;
using AddPostalCodeToService.DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AddPostalCodeToService.DAL.DataContext
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<PostalCode> PostalCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildPostalCodeModel();
        }
    }
}