﻿using Capstone.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Infrastructure.Models
{
    public class CapstoneRole : IdentityRole<string>, IBaseEntity
    {
        public CapstoneRole(string s) : base(s)
        {

        }

        public CapstoneRole() : base()
        {

        }

        public override string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset CreationTime { get; set; } = DateTimeOffset.UtcNow;
    }
}
