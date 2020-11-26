using Ardalis.SmartEnum;

namespace Capstone.Core.Enums
{
    public sealed class DndClass : SmartEnum<DndClass>
    {
        private DndClass(string name, int value) : base(name, value)
        {

        }

        private DndClass() : base("", 0)
        {

        }

        public static readonly DndClass BARBARIAN = new DndClass("barbarian", 1);
        public static readonly DndClass BARD = new DndClass("bard", 2);
        public static readonly DndClass CLERIC = new DndClass("cleric", 3);
        public static readonly DndClass DRUID = new DndClass("druid", 4);
        public static readonly DndClass FIGHTER = new DndClass("fighter", 5);
        public static readonly DndClass MONK = new DndClass("monk", 6);
        public static readonly DndClass PALADIN = new DndClass("paladin", 7);
        public static readonly DndClass RANGER = new DndClass("ranger", 8);
        public static readonly DndClass ROGUE = new DndClass("rogue", 9);
        public static readonly DndClass SORCERER = new DndClass("sorcerer", 10);
        public static readonly DndClass WARLOCK = new DndClass("warlock", 11);
        public static readonly DndClass WIZARD = new DndClass("wizard", 12);
        public static readonly DndClass ARTIFICER = new DndClass("artificer", 13);
    }
}
