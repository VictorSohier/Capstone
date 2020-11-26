using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Capstone.Core;
using Capstone.Core.Enums;
using Capstone.Core.Models.Value_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Capstone.Core.CharacterSheet;

namespace Capstone.Web.Models.View_Models
{
    public class VMCharacterSheet
    {
        [Required]
        public string Name { get; set; }

        public int Class { get; set; }

        public int Gender { get; set; }

        public int Race { get; set; }

        public int Subrace { get; set; }

        public uint Level { get; set; }

        public uint Experience { get; set; }

        [Display(Name = "Experience to Next Level")]
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

        [Display(Name = "Religion/God/Deity")]
        public string Religion { get; set; }

        public int Strength { get; set; }

        [Display(Name = "Strength Saving Throw")]
        public int StrengthSavingThrow { get; set; }

        [Display(Name = "Strength Secondary Stat Names")]
        public List<string> StrengthDerivativeKeys { get; set; }

        [Display(Name = "Strength Secondary Stats")]
        public List<int> StrengthDerivativeValues { get; set; }

        public int Dexterity { get; set; }

        [Display(Name = "Dexterity Saving Throw")]
        public int DexteritySavingThrow { get; set; }

        [Display(Name = "Dexterity Secondary Stat Names")]
        public List<string> DexterityDerivativeKeys { get; set; }

        [Display(Name = "Dexterity Secondary Stats")]
        public List<int> DexterityDerivativeValues { get; set; }

        public int Constitution { get; set; }

        [Display(Name = "Constitution Saving Throw")]
        public int ConstitutionSavingThrow { get; set; }

        [Display(Name = "Constitution Secondary Stat Names")]
        public List<string> ConstitutionDerivativeKeys { get; set; }

        [Display(Name = "Constitution Secondary Stats")]
        public List<int> ConstitutionDerivativeValues { get; set; }

        public int Intelligence { get; set; }

        [Display(Name = "Intelligence Saving Throw")]
        public int IntelligenceSavingThrow { get; set; }

        [Display(Name = "Intelligence Secondary Stat Names")]
        public List<string> IntelligenceDerivativeKeys { get; set; }

        [Display(Name = "Intelligence Secondary Stats")]
        public List<int> IntelligenceDerivativeValues { get; set; }

        public int Wisdom { get; set; }

        [Display(Name = "Wisdom Saving Throw")]
        public int WisdomSavingThrow { get; set; }

        [Display(Name = "Wisdom Secondary Stat Names")]
        public List<string> WisdomDerivativeKeys { get; set; }

        [Display(Name = "Wisdom Secondary Stats")]
        public List<int> WisdomDerivativeValues { get; set; }

        public int Charisma { get; set; }

        [Display(Name = "Charisma Saving Throw")]
        public int CharismaSavingThrow { get; set; }

        [Display(Name = "Charisma Secondary Stat Names")]
        public List<string> CharismaDerivativeKeys { get; set; }

        [Display(Name = "Charisma Secondary Stats")]
        public List<int> CharismaDerivativeValues { get; set; }

        [Display(Name = "Passive Wisdom")]
        public int PassiveWisdom { get; set; }

        [Display(Name = "Weight Carried")]
        public double WeightCarried { get; set; }

        [Display(Name = "Armor Class")]
        public string ArmorClass { get; set; }

        [Display(Name = "Dexterity Armor Modifier")]
        public int DexArmorModifier { get; set; }

        public int Armor { get; set; }

        public int Shield { get; set; }

        [Display(Name = "Miscelaneous Armor Modifier")]
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

        public List<Weapon> Weapons { get; set; }

        public string Equipment { get; set; }

        [Display(Name = "Copper Piece")]
        public ulong CopperPiece { get; set; }

        [Display(Name = "Silver Piece")]
        public ulong SilverPiece { get; set; }

        [Display(Name = "Electrum Piece")]
        public ulong ElectrumPiece { get; set; }

        [Display(Name = "Gold Piece")]
        public ulong GoldPiece { get; set; }

        [Display(Name="Platinum Piece")]
        public ulong PlatinumPiece { get; set; }

        [Display(Name= "Weapon and Armor Proficiencies")]
        public int WeaponAndArmorProficiencies { get; set; }

        public string Traits { get; set; }

        public static implicit operator CharacterSheet(VMCharacterSheet s)
        {
            if (s == null)
                return null;

            Dictionary<string, int> strDerivativeStats = new Dictionary<string, int>();
            for (int i = 0; i < s.StrengthDerivativeKeys.Count; i++)
            {
                strDerivativeStats.Add(s.StrengthDerivativeKeys[i],
                    s.StrengthDerivativeValues.Count > i ? s.StrengthDerivativeValues[i] : 0);
            }
            Stat Strength = new Stat
            {
                Value = s.Strength,
                SavingThrow = s.StrengthSavingThrow,
                DerivativeStats = strDerivativeStats
            };

            Dictionary<string, int> dexDerivativeStats = new Dictionary<string, int>();
            for (int i = 0; i < s.DexterityDerivativeKeys.Count; i++)
            {
                strDerivativeStats.Add(s.DexterityDerivativeKeys[i],
                    s.DexterityDerivativeValues.Count > i ? s.DexterityDerivativeValues[i] : 0);
            }
            Stat Dexterity = new Stat
            {
                Value = s.Dexterity,
                SavingThrow = s.DexteritySavingThrow,
                DerivativeStats = dexDerivativeStats
            };

            Dictionary<string, int> conDerivativeStats = new Dictionary<string, int>();
            for (int i = 0; i < s.ConstitutionDerivativeKeys.Count; i++)
            {
                conDerivativeStats.Add(s.ConstitutionDerivativeKeys[i],
                    s.ConstitutionDerivativeValues.Count > i ? s.ConstitutionDerivativeValues[i] : 0);
            }
            Stat Constitution = new Stat
            {
                Value = s.Constitution,
                SavingThrow = s.ConstitutionSavingThrow,
                DerivativeStats = conDerivativeStats
            };

            Dictionary<string, int> intDerivativeStats = new Dictionary<string, int>();
            for (int i = 0; i < s.IntelligenceDerivativeKeys.Count; i++)
            {
                intDerivativeStats.Add(s.IntelligenceDerivativeKeys[i],
                    s.IntelligenceDerivativeValues.Count > i ? s.IntelligenceDerivativeValues[i] : 0);
            }
            Stat Intelligence = new Stat
            {
                Value = s.Intelligence,
                SavingThrow = s.IntelligenceSavingThrow,
                DerivativeStats = intDerivativeStats
            };

            Dictionary<string, int> wisDerivativeStats = new Dictionary<string, int>();
            for (int i = 0; i < s.WisdomDerivativeKeys.Count; i++)
            {
                wisDerivativeStats.Add(s.WisdomDerivativeKeys[i],
                    s.WisdomDerivativeValues.Count > i ? s.WisdomDerivativeValues[i] : 0);
            }
            Stat Wisdom = new Stat
            {
                Value = s.Wisdom,
                SavingThrow = s.WisdomSavingThrow,
                DerivativeStats = wisDerivativeStats
            };

            Dictionary<string, int> chrDerivativeStats = new Dictionary<string, int>();
            for (int i = 0; i < s.CharismaDerivativeKeys.Count; i++)
            {
                chrDerivativeStats.Add(s.CharismaDerivativeKeys[i],
                    s.CharismaDerivativeValues.Count > i ? s.CharismaDerivativeValues[i] : 0);
            }
            Stat Charisma = new Stat
            {
                Value = s.Charisma,
                SavingThrow = s.CharismaSavingThrow,
                DerivativeStats = chrDerivativeStats
            };

            CharacterSheet cs = new CharacterSheet {
                Name = s.Name,
                Class = DndClass.FromValue(s.Class),
                Gender = GenderEnum.FromValue(s.Gender),
                Race = RaceEnum.FromValue(s.Race),
                Subrace = SubraceEnum.FromValue(s.Subrace),
                Level = s.Level,
                Experience = s.Experience,
                ExperienceToNextLevel = s.ExperienceToNextLevel,
                Background = s.Background,
                Languages = s.Languages,
                Age = s.Age,
                Height = s.Height,
                Weight = s.Weight,
                Eyes = s.Eyes,
                Hair = s.Hair,
                Proficiency = s.Proficiency,
                Inspiration = s.Inspiration,
                Alignment = s.Alignment,
                Religion = s.Religion,
                Strength = Strength,
                Dexterity = Dexterity,
                Constitution = Constitution,
                Intelligence = Intelligence,
                Wisdom = Wisdom,
                Charisma = Charisma,
                PassiveWisdom = s.PassiveWisdom,
                WeightCarried = s.WeightCarried,
                ArmorClass = s.ArmorClass,
                DexArmorModifier = s.DexArmorModifier,
                Armor = s.Armor,
                Shield = s.Shield,
                MiscArmorModifier = s.MiscArmorModifier,
                InitiativeModifier = s.InitiativeModifier,
                MaxSpeed = s.MaxSpeed,
                DeathSavingThrowSuccesses = s.DeathSavingThrowSuccesses,
                DeathSavingThrowFailures = s.DeathSavingThrowFailures,
                Exhaustion = s.Exhaustion,
                TotalHitDice = s.TotalHitDice,
                CurrentHitDice = s.CurrentHitDice,
                SpellCasting = s.SpellCasting,
                SpellSave = s.SpellSave,
                SpellAttackBonus = s.SpellAttackBonus,
                Weapons = s.Weapons,
                Equipment = s.Equipment,
                PlatinumPiece = s.PlatinumPiece,
                GoldPiece = s.GoldPiece,
                ElectrumPiece = s.ElectrumPiece,
                SilverPiece = s.SilverPiece,
                CopperPiece = s.CopperPiece,
                WeaponAndArmorProficiencies = CombatProficiencies.IntToFlagList(s.WeaponAndArmorProficiencies),
                Traits = s.Traits
            };

            return cs;
        }

        public static explicit operator VMCharacterSheet(CharacterSheet s)
        {
            if (s == null)
                return null;

            VMCharacterSheet vmcs = new VMCharacterSheet
            {
                Name = s.Name,
                Class = s.Class.Value,
                Gender = s.Gender.Value,
                Race = s.Race.Value,
                Subrace = s.Subrace.Value,
                Level = s.Level,
                Experience = s.Experience,
                ExperienceToNextLevel = s.ExperienceToNextLevel,
                Background = s.Background,
                Languages = s.Languages,
                Age = s.Age,
                Height = s.Height,
                Weight = s.Weight,
                Eyes = s.Eyes,
                Hair = s.Hair,
                Proficiency = s.Proficiency,
                Inspiration = s.Inspiration,
                Alignment = s.Alignment,
                Religion = s.Religion,
                Strength = s.Strength.Value,
                Dexterity = s.Dexterity.Value,
                Constitution = s.Constitution.Value,
                Intelligence = s.Intelligence.Value,
                Wisdom = s.Wisdom.Value,
                Charisma = s.Charisma.Value,
                PassiveWisdom = s.PassiveWisdom,
                WeightCarried = s.WeightCarried,
                ArmorClass = s.ArmorClass,
                DexArmorModifier = s.DexArmorModifier,
                Armor = s.Armor,
                Shield = s.Shield,
                MiscArmorModifier = s.MiscArmorModifier,
                InitiativeModifier = s.InitiativeModifier,
                MaxSpeed = s.MaxSpeed,
                DeathSavingThrowSuccesses = s.DeathSavingThrowSuccesses,
                DeathSavingThrowFailures = s.DeathSavingThrowFailures,
                Exhaustion = s.Exhaustion,
                TotalHitDice = s.TotalHitDice,
                CurrentHitDice = s.CurrentHitDice,
                SpellCasting = s.SpellCasting,
                SpellSave = s.SpellSave,
                SpellAttackBonus = s.SpellAttackBonus,
                Weapons = s.Weapons.ToList(),
                Equipment = s.Equipment,
                PlatinumPiece = s.PlatinumPiece,
                GoldPiece = s.GoldPiece,
                ElectrumPiece = s.ElectrumPiece,
                SilverPiece = s.SilverPiece,
                CopperPiece = s.CopperPiece,
                WeaponAndArmorProficiencies = s.WeaponAndArmorProficiencies.Select(e => e.Value).Aggregate((a,e) => a + e),
                Traits = s.Traits
            };

            return vmcs;
        }
    }
}