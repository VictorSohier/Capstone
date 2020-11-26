using Capstone.Core.Interfaces;
using Capstone.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Infrastructure.Models
{
    public class CapstoneUser : IdentityUser<string>, IBaseEntity
    {
        public new string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset CreationTime { get; set; } = DateTimeOffset.UtcNow;

        public virtual Author AuthoredItems { get; set; }
    }
}