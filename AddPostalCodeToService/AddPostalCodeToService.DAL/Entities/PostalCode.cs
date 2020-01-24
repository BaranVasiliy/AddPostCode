using System;
using System.Data;

namespace AddPostalCodeToService.DAL.Entities
{
    public class PostalCode
    {
        public long Id { get; set; }

        public Guid ServiceId { get; set; }

        public string Code { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}