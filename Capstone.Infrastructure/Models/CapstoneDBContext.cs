using Capstone.Core.Enums;
using Capstone.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Infrastructure.Models
{
    public class CapstoneDBContext : IdentityDbContext<CapstoneUser, CapstoneRole, string>
    {
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<CharacterSheet> CharacterSheets { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public CapstoneDBContext(DbContextOptions<CapstoneDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL("Data Source=localhost\\SQLEXPRESS;Initial Catalog=capstone;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<CombatProficiencies>()
                .HasKey(e => e.Value);

            builder
                .Entity<CharacterSheet>()
                .Property(e => e.WeaponAndArmorProficiencies)
                .HasConversion(
                v => CombatProficiencies.FlagListToInt(v.ToList()),
                v => CombatProficiencies.IntToFlagList(v));

            builder
                .Entity<CharacterSheet>()
                .Property(e => e.Race)
                .HasConversion(
                v => v.Value,
                v => RaceEnum.FromValue(v));

            builder
                .Entity<CharacterSheet>()
                .Property(e => e.Subrace)
                .HasConversion(
                v => v.Value,
                v => SubraceEnum.FromValue(v));

            builder
                .Entity<CharacterSheet>()
                .Property(e => e.Class)
                .HasConversion(
                v => v.Value,
                v => DndClass.FromValue(v));

            builder
                .Entity<CharacterSheet>()
                .Property(e => e.Gender)
                .HasConversion(
                v => v.Value,
                v => GenderEnum.FromValue(v));

            builder
                .Entity<Comment>()
                .HasOne(e => e.Parent as Commentable)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Commentable>()
                .HasOne(e => e.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void VoidEventSaveChanges<T>(T obj, object sender)
        {
            SaveChanges();
        }

        public async Task VoidEventSaveChangesAsync<T>(T obj, object sender)
        {
            await SaveChangesAsync();
        }
    }
}
