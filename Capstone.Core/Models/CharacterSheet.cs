using Ardalis.SmartEnum;
using Capstone.Core.Enums;
using Capstone.Core.Models;
using Capstone.Core.Models.Value_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Capstone.Core.Models
{
    public class CharacterSheet : Commentable
    {
        [Required]
        public string Name { get; set; }

        public DndClass Class { get; set; }

        public GenderEnum Gender { get; set; }

        public RaceEnum Race { get; set; }

        public SubraceEnum Subrace { get; set; }

        public uint Level { get; set; }

        public uint Experience { get; set; }

        [Display(Name="Experience to Next Level")]
        public uint ExperienceToNextLevel { get; set; }

        public string Background { get; set; }

        public string Languages { get; set; }

        public uint Age { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string Eyes { get; set; }

        public string Hair { get; set; }

        public string Proficiency { get; set; }

        public string Inspiration { get; set; }

        public string Alignment { get; set; }

        public string Religion { get; set; }

        public Stat Strength { get; set; }

        public Stat Dexterity { get; set; }

        public Stat Constitution { get; set; }

        public Stat Intelligence { get; set; }

        public Stat Wisdom { get; set; }

        public Stat Charisma { get; set; }

        [Display(Name = "Passive Wisdom/Perception")]
        public int PassiveWisdom { get; set; }

        [Display(Name = "Weight Carried")]
        public double WeightCarried { get; set; }

        [Display(Name = "Encumbered")]
        public bool IsEncumbered
        {
            get
            {
                return WeightCarried > 5 * Strength.Value;
            }
        }

        [Display(Name = "Heavily Encumbered")]
        public bool IsHeavilyEncumbered
        {
            get
            {
                return WeightCarried > 10 * Strength.Value;
            }
        }

        [Display(Name = "Push/Pull Weight")]
        public int MoveWeight {
            get
            {
                return Strength.Value * 30;
            }
        }

        [Display(Name = "Armor Class")]
        public string ArmorClass { get; set; }

        [Display(Name = "Dexterity Armor Modifier")]
        public int DexArmorModifier { get; set; }

        public int Armor { get; set; }

        public int Shield { get; set; }

        [Display(Name = "Miscelaneous Armor Modifiers")]
        public int MiscArmorModifier { get; set; }

        [Display(Name = "Initiative Modifier")]
        public int InitiativeModifier { get; set; }

        [Display(Name = "Max Speed")]
        public double MaxSpeed { get; set; }

        [Display(Name = "Current Speed")]
        public double CurrentSpeed { get; set; }

        [Display(Name = "Death Saving Throw Successes")]
        public byte DeathSavingThrowSuccesses { get; set; }

        [Display(Name = "Death Saving Throw Failures")]
        public byte DeathSavingThrowFailures { get; set; }

        public byte Exhaustion { get; set; }

        [Display(Name = "Total Hit Dice")]
        public byte TotalHitDice { get; set; }

        [Display(Name = "Current Hit Dice")]
        public byte CurrentHitDice { get; set; }

        [Display(Name = "Spell Casting")]
        public int SpellCasting { get; set; }

        [Display(Name = "Spell Save")]
        public int SpellSave { get; set; }

        [Display(Name = "Spell Attack Bonus")]
        public int SpellAttackBonus { get; set; }

        public virtual ICollection<Weapon> Weapons { get; set; }

        public string Equipment { get; set; }

        [Display(Name = "Copper Pieces")]
        public ulong CopperPiece {
            get
            {
                return CopperPiece;
            }
            set
            {
                CopperPiece = value % 10;
                SilverPiece = SilverPiece + value / 10;
            }
        }

        [Display(Name = "Silver Pieces")]
        public ulong SilverPiece
        {
            get
            {
                return SilverPiece;
            }
            set
            {
                SilverPiece = value % 5;
                ElectrumPiece = ElectrumPiece + value / 5;
            }
        }

        [Display(Name = "Electrum Pieces")]
        public ulong ElectrumPiece {
            get
            {
                return ElectrumPiece;
            }
            set
            {
                ElectrumPiece = value % 2;
                GoldPiece = GoldPiece + value / 2;
            }
        }

        [Display(Name = "Gold Pieces")]
        public ulong GoldPiece
        {
            get
            {
                return GoldPiece;
            }
            set
            {
                GoldPiece = value % 10;
                PlatinumPiece = PlatinumPiece + value / 10;
            }
        }

        [Display(Name = "Platinum Pieces")]
        public ulong PlatinumPiece { get; set; }

        [Display(Name = "Weapon and Armor Proficiencies")]
        public virtual ICollection<CombatProficiencies> WeaponAndArmorProficiencies { get; set; }

        public string Traits { get; set; }
    }
}