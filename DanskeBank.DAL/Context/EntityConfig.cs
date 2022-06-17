using System;
using DanskeBank.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanskeBank.DAL.Context
{
    public class RuleSetEntityConfig : IEntityTypeConfiguration<RuleSet>
    {
        public void Configure(EntityTypeBuilder<RuleSet> builder)
        {
            // primary key
            builder.HasKey(i => i.RuleSetId);
            //column configuration
            builder.Property(i => i.RuleSetId).ValueGeneratedOnAdd();
            builder.Property(i => i.Municipality).HasMaxLength(50);

            //column index
            builder.HasIndex(i => i.Municipality);
            //unique index
            builder.HasIndex(i => new { i.Municipality, i.TaxRule }).IsUnique();

            //initial  data fro the entity
            builder.HasData(
                new RuleSet
                {
                    RuleSetId=1,
                    Municipality="Kaunas",
                    TaxRule=TaxRule.Rule1
                },
                new RuleSet
                {
                    RuleSetId = 2,
                    Municipality = "Vilnius",
                    TaxRule = TaxRule.Rule2
                }
                );
        }
    }
    public class RuleEntityConfig : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            //primary key
            builder.HasKey(i => i.RuleId);
            //column configuration
            builder.Property(i => i.RuleId).ValueGeneratedOnAdd();
            builder.Property(i => i.Tax).HasPrecision(18, 1);
            builder.Property(i => i.Schedule).HasMaxLength(25);
            //column index
            builder.HasIndex(i => i.Schedule);
            //foreign key relationship
            builder.HasOne(i => i.RuleSet).WithMany(i => i.Rules).HasForeignKey(i => i.RuleSetId);

            //initial data for entity
            builder.HasData(
                new Rule
                {
                    RuleId = 1,
                    RuleSetId = 1,
                    Schedule = Schedule.Year.ToString(),
                    FromDate=new DateTime(2020,1,1),
                    ToDate=new DateTime(2020,12,31),
                    Tax=0.3M
                },
                new Rule
                {
                    RuleId = 2,
                    RuleSetId = 1,
                    Schedule = Schedule.Month.ToString(),
                    FromDate = new DateTime(2020, 1, 1),
                    ToDate = new DateTime(2020, 1, 31),
                    Tax = 0.2M
                },
                new Rule
                {
                    RuleId = 3,
                    RuleSetId = 1,
                    Schedule = Schedule.Week.ToString(),
                    FromDate = new DateTime(2020, 1, 6),
                    ToDate = new DateTime(2020, 1, 12),
                    Tax = 0.1M
                },
                new Rule
                {
                    RuleId = 4,
                    RuleSetId = 2,
                    Schedule = Schedule.Year.ToString(),
                    FromDate = new DateTime(2020, 1, 1),
                    ToDate = new DateTime(2020, 12, 31),
                    Tax = 0.2M
                },
                new Rule
                {
                    RuleId = 5,
                    RuleSetId = 2,
                    Schedule = Schedule.Month.ToString(),
                    FromDate = new DateTime(2020, 5, 1),
                    ToDate = new DateTime(2020, 5, 31),
                    Tax = 0.4M
                },
                new Rule
                {
                    RuleId = 6,
                    RuleSetId = 2,
                    Schedule = Schedule.Day.ToString(),
                    FromDate = new DateTime(2020, 12, 25),
                    ToDate = new DateTime(2020, 12, 25),
                    Tax = 0.1M
                },
                new Rule
                {
                    RuleId = 7,
                    RuleSetId = 2,
                    Schedule = Schedule.Day.ToString(),
                    FromDate = new DateTime(2020, 1, 1),
                    ToDate = new DateTime(2020, 1, 1),
                    Tax = 0.1M
                }
                );
        }
    }
}
