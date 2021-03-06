// <auto-generated />
using System;
using DanskeBank.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DanskeBank.DAL.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DanskeBank.DAL.Models.Rule", b =>
                {
                    b.Property<int>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RuleSetId")
                        .HasColumnType("int");

                    b.Property<string>("Schedule")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("Tax")
                        .HasPrecision(18, 1)
                        .HasColumnType("decimal(18,1)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RuleId");

                    b.HasIndex("RuleSetId");

                    b.HasIndex("Schedule");

                    b.ToTable("Rules");

                    b.HasData(
                        new
                        {
                            RuleId = 1,
                            FromDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RuleSetId = 1,
                            Schedule = "Year",
                            Tax = 0.3m,
                            ToDate = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RuleId = 2,
                            FromDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RuleSetId = 1,
                            Schedule = "Month",
                            Tax = 0.2m,
                            ToDate = new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RuleId = 3,
                            FromDate = new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RuleSetId = 1,
                            Schedule = "Week",
                            Tax = 0.1m,
                            ToDate = new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RuleId = 4,
                            FromDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RuleSetId = 2,
                            Schedule = "Year",
                            Tax = 0.2m,
                            ToDate = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RuleId = 5,
                            FromDate = new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RuleSetId = 2,
                            Schedule = "Month",
                            Tax = 0.4m,
                            ToDate = new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RuleId = 6,
                            FromDate = new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RuleSetId = 2,
                            Schedule = "Day",
                            Tax = 0.1m,
                            ToDate = new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RuleId = 7,
                            FromDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RuleSetId = 2,
                            Schedule = "Day",
                            Tax = 0.1m,
                            ToDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DanskeBank.DAL.Models.RuleSet", b =>
                {
                    b.Property<int>("RuleSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Municipality")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TaxRule")
                        .HasColumnType("int");

                    b.HasKey("RuleSetId");

                    b.HasIndex("Municipality");

                    b.HasIndex("Municipality", "TaxRule")
                        .IsUnique()
                        .HasFilter("[Municipality] IS NOT NULL");

                    b.ToTable("RuleSets");

                    b.HasData(
                        new
                        {
                            RuleSetId = 1,
                            Municipality = "Kaunas",
                            TaxRule = 1
                        },
                        new
                        {
                            RuleSetId = 2,
                            Municipality = "Vilnius",
                            TaxRule = 2
                        });
                });

            modelBuilder.Entity("DanskeBank.DAL.Models.Rule", b =>
                {
                    b.HasOne("DanskeBank.DAL.Models.RuleSet", "RuleSet")
                        .WithMany("Rules")
                        .HasForeignKey("RuleSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RuleSet");
                });

            modelBuilder.Entity("DanskeBank.DAL.Models.RuleSet", b =>
                {
                    b.Navigation("Rules");
                });
#pragma warning restore 612, 618
        }
    }
}
