using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Core.Models.Value_Models
{
    public class Weapon
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public byte Cost { get; set; }

        public byte Damage { get; set; }

        public byte CritMultiplier { get; set; }

        public byte Range { get; set; }

        //Half-pound increments because efficiency
        public byte Weight { get; set; }

        public enum WeaponType
        {
            BLUDGEONING,
            PIERCING,
            SLASHING,
            PIERCING_SLASHING,
            BLUDGEONING_PIERCING,
            OTHER
        }
    }
}