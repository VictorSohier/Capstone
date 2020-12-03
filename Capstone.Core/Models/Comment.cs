using Capstone.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Models
{
    public class Comment : Commentable
    {
        public ICommentable Parent { get; set; }

        [Required]
        public string Substance { get; set; }
    }
}