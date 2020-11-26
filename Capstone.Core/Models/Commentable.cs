using Capstone.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Models
{
    public abstract class Commentable : BaseEntity, ICommentable
    {
        [Required]
        public virtual Author Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
