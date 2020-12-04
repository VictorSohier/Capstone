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
        public CapstoneUser() : base()
        {
            Id = Guid.NewGuid().ToString();
        }

        public CapstoneUser(string s) : base(s)
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset CreationTime { get; set; } = DateTimeOffset.UtcNow;

        public virtual Author AuthoredItems { get; set; }
    }
}