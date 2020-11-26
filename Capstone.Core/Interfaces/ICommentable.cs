using Capstone.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Interfaces
{
    public interface ICommentable : IBaseEntity
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
