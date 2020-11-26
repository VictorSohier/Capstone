using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Interfaces
{
    public interface IBaseEntity
    {
        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        public DateTimeOffset CreationTime { get; set; }
    }
}
