using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Infrastructure.Migrations
{
    public partial class fixedCharacterSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CombatProficiencies",
                columns: table => new
                {
                    Value = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatProficiencies", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Stat",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    SavingThrow = table.Column<int>(nullable: false),
                    DerivativeStatsXml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    AuthoredItemsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Authors_AuthoredItemsId",
                        column: x => x.AuthoredItemsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commentable",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    AuthorId1 = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Class = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Level = table.Column<long>(nullable: true),
                    Experience = table.Column<long>(nullable: true),
                    ExperienceToNextLevel = table.Column<long>(nullable: true),
                    Background = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    Age = table.Column<long>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Eyes = table.Column<string>(nullable: true),
                    Hair = table.Column<string>(nullable: true),
                    Proficiency = table.Column<string>(nullable: true),
                    Inspiration = table.Column<string>(nullable: true),
                    Alignment = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    StrengthId = table.Column<string>(nullable: true),
                    DexterityId = table.Column<string>(nullable: true),
                    ConstitutionId = table.Column<string>(nullable: true),
                    IntelligenceId = table.Column<string>(nullable: true),
                    WisdomId = table.Column<string>(nullable: true),
                    CharismaId = table.Column<string>(nullable: true),
                    PassiveWisdom = table.Column<int>(nullable: true),
                    WeightCarried = table.Column<double>(nullable: true),
                    ArmorClass = table.Column<string>(nullable: true),
                    DexArmorModifier = table.Column<int>(nullable: true),
                    Armor = table.Column<int>(nullable: true),
                    Shield = table.Column<int>(nullable: true),
                    MiscArmorModifier = table.Column<int>(nullable: true),
                    InitiativeModifier = table.Column<int>(nullable: true),
                    MaxSpeed = table.Column<double>(nullable: true),
                    CurrentSpeed = table.Column<double>(nullable: true),
                    DeathSavingThrowSuccesses = table.Column<byte>(nullable: true),
                    DeathSavingThrowFailures = table.Column<byte>(nullable: true),
                    Exhaustion = table.Column<byte>(nullable: true),
                    TotalHitDice = table.Column<byte>(nullable: true),
                    CurrentHitDice = table.Column<byte>(nullable: true),
                    SpellCasting = table.Column<int>(nullable: true),
                    SpellSave = table.Column<int>(nullable: true),
                    SpellAttackBonus = table.Column<int>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    CopperPiece = table.Column<byte>(nullable: true),
                    SilverPiece = table.Column<byte>(nullable: true),
                    ElectrumPiece = table.Column<byte>(nullable: true),
                    GoldPiece = table.Column<byte>(nullable: true),
                    PlatinumPiece = table.Column<long>(nullable: true),
                    WeaponAndArmorProficiencies = table.Column<int>(nullable: true),
                    Traits = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Substance = table.Column<string>(nullable: true),
                    Comment_AuthorId = table.Column<string>(nullable: true),
                    CommentableId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentable_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Stat_CharismaId",
                        column: x => x.CharismaId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Stat_ConstitutionId",
                        column: x => x.ConstitutionId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Stat_DexterityId",
                        column: x => x.DexterityId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Stat_IntelligenceId",
                        column: x => x.IntelligenceId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Stat_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Stat_WisdomId",
                        column: x => x.WisdomId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Authors_Comment_AuthorId",
                        column: x => x.Comment_AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentable_Commentable_CommentableId",
                        column: x => x.CommentableId,
                        principalTable: "Commentable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Commentable_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Commentable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentable_Authors_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<byte>(nullable: false),
                    Damage = table.Column<byte>(nullable: false),
                    CritMultiplier = table.Column<byte>(nullable: false),
                    Range = table.Column<byte>(nullable: false),
                    Weight = table.Column<byte>(nullable: false),
                    CharacterSheetId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapon_Commentable_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "Commentable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AuthoredItemsId",
                table: "AspNetUsers",
                column: "AuthoredItemsId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_AuthorId",
                table: "Commentable",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_CharismaId",
                table: "Commentable",
                column: "CharismaId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_ConstitutionId",
                table: "Commentable",
                column: "ConstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_DexterityId",
                table: "Commentable",
                column: "DexterityId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_IntelligenceId",
                table: "Commentable",
                column: "IntelligenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_StrengthId",
                table: "Commentable",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_WisdomId",
                table: "Commentable",
                column: "WisdomId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_Comment_AuthorId",
                table: "Commentable",
                column: "Comment_AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_CommentableId",
                table: "Commentable",
                column: "CommentableId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_ParentId",
                table: "Commentable",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentable_AuthorId1",
                table: "Commentable",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharacterSheetId",
                table: "Weapon",
                column: "CharacterSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CombatProficiencies");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Commentable");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Stat");
        }
    }
}
