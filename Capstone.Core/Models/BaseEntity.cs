using Capstone.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Models
{
    public class BaseEntity : IBaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset CreationTime { get; set; } = DateTimeOffset.UtcNow;
    }
}
