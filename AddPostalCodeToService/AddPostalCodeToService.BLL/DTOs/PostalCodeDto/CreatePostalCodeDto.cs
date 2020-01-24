using System;
using System.Collections.Generic;
using System.Text;

namespace AddPostalCodeToService.BLL.DTOs.PostalCodeDto
{
    public class CreatePostalCodeDto
    {
        public long Id { get; set; }

        public Guid ServiceId { get; set; }

        public string Code { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
