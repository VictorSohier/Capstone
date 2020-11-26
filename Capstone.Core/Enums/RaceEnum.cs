using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Enums
{
    public sealed class RaceEnum : SmartEnum<RaceEnum>
    {
        private RaceEnum(string name, int value) : base(name, value)
        {

        }

        private RaceEnum() : base("", 0)
        {

        }

        public static readonly RaceEnum DRAGONBORN = new RaceEnum("dragonborn", 1);
        public static readonly RaceEnum DWARF = new RaceEnum("dwarf", 2);
        public static readonly RaceEnum ELF = new RaceEnum("elf", 3);
        public static readonly RaceEnum GNOME = new RaceEnum("gnome", 4);
        public static readonly RaceEnum HALF_ELF = new RaceEnum("half elf", 5);
        public static readonly RaceEnum HALFLING = new RaceEnum("halfling", 6);
        public static readonly RaceEnum HALF_ORC = new RaceEnum("half orc", 7);
        public static readonly RaceEnum HUMAN = new RaceEnum("human", 8);
        public static readonly RaceEnum TIEFLING = new RaceEnum("tiefling", 9);
    }
}