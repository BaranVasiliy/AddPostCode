using AddPostalCodeToService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddPostalCodeToService.DAL.Extensions
{
    public static class PostalCodeExtension
    {
        public static void BuildPostalCodeModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(p => p.ServiceId);

                entity.Property(p => p.Code).HasMaxLength(20).IsRequired();

                entity.Property(i => i.Id).ValueGeneratedOnAdd();
            });
        }
    }
}