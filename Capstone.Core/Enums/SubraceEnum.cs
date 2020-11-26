using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Core.Enums
{
    public class SubraceEnum : SmartEnum<SubraceEnum>
    {
        protected SubraceEnum(string name, int value) : base(name, value)
        {

        }

        protected SubraceEnum() : base("", 0)
        {

        }

        public static readonly SubraceEnum HILL_DWARF = new SubraceEnum("hill dwarf", 1);
        public static readonly SubraceEnum MOUNTAIN_DWARF = new SubraceEnum("mountain dwarf", 2);
        public static readonly SubraceEnum HIGH_ELF = new SubraceEnum("high elf", 3);
        public static readonly SubraceEnum WOOD_ELF = new SubraceEnum("wood elf", 4);
        public static readonly SubraceEnum DARK_ELF = new SubraceEnum("dark elf", 5);
        public static readonly SubraceEnum DEEP_GNOME = new SubraceEnum("deep gnome", 6);
        public static readonly SubraceEnum LIGHTFOOT = new SubraceEnum("lightfoot", 7);
        public static readonly SubraceEnum STOUT = new SubraceEnum("stout", 8);
    }
}