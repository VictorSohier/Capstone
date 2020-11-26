using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<CharacterSheet> CharacterSheets { get; set; } = new List<CharacterSheet>();
    }
}