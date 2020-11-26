using Ardalis.SmartEnum;
using System.Collections.Generic;

namespace Capstone.Core.Enums
{
    public sealed class CombatProficiencies : SmartEnum<CombatProficiencies>
    {
        private CombatProficiencies(string name, int value) : base(name, value)
        {

        }

        private CombatProficiencies() : base("", 0)
        {

        }

        public static readonly CombatProficiencies SIMPLE = new CombatProficiencies("simple", 1);
        public static readonly CombatProficiencies AXES = new CombatProficiencies("axes", 2);
        public static readonly CombatProficiencies BOWS = new CombatProficiencies("bows", 4);
        public static readonly CombatProficiencies CROSSBOWS = new CombatProficiencies("crossbows", 8);
        public static readonly CombatProficiencies FLAILS = new CombatProficiencies("flails", 16);
        public static readonly CombatProficiencies LANCES = new CombatProficiencies("lances", 32);
        public static readonly CombatProficiencies MACES_HAMMERS = new CombatProficiencies("maces & hammers", 64);
        public static readonly CombatProficiencies POLEARMS = new CombatProficiencies("polearms", 128);
        public static readonly CombatProficiencies SWORDS = new CombatProficiencies("swords", 256);
        public static readonly CombatProficiencies THROWN = new CombatProficiencies("thrown", 512);
        public static readonly CombatProficiencies EXOTIC = new CombatProficiencies("exotic", 1024);
        public static readonly CombatProficiencies ARMOR_LIGHT = new CombatProficiencies("light armor", 2048);
        public static readonly CombatProficiencies ARMOR_MEDIUM = new CombatProficiencies("medium armor", 4096);
        public static readonly CombatProficiencies ARMOR_HEAVY = new CombatProficiencies("heavy armor", 8192);
        public static readonly CombatProficiencies ARMOR_SHIELDS = new CombatProficiencies("shields", 16384);
        public static readonly CombatProficiencies ARMOR_TOWER_SHIELDS = new CombatProficiencies("tower shields", 32768);

        public static List<CombatProficiencies> IntToFlagList(int flags)
        {
            List<CombatProficiencies> ans = new List<CombatProficiencies>();
            int bit = 1;
            while (flags > 0)
            {
                if ((flags & bit) > 0)
                {
                    ans.Add(FromValue(bit));
                    flags -= bit;
                }
                bit *= 2;
            }
            return ans;
        }

        public static int FlagListToInt(List<CombatProficiencies> flags)
        {
            int ans = 0;
            flags.ForEach(e => ans += e.Value);
            return ans;
        }
    }
}
