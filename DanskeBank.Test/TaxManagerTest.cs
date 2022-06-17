using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DanskeBank.DAL.Context;
using DanskeBank.DAL.Repository;
using AutoMapper;
using DanskeBank.DAL.Models;
using System.Linq;
using DanskeBank.DAL.Utlity;
using DanskeBank.DAL.ModelsDto;
using DanskeBank.BL.Manager;

namespace DanskeBank.Test
{
    public class TaxManagerTest
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;
        public TaxManagerTest()
        {

            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseSqlServer("Data Source=DHANABAL\\MSSQL2016;Initial Catalog=DanskeBank;User ID=sa; Password=Jram@2193");
            _context = new DataBaseContext(optionsBuilder.Options);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            _repository = new Repository(_context, _mapper);
        }

        [Fact]
        public async Task AddRuleSet()
        {
            var ruleset = _context.RuleSets.Include(i => i.Rules).Where(i => i.Municipality == "KaunasUnitTest").FirstOrDefault();
            if (ruleset != null)
            {
                if (ruleset.Rules != null)
                {
                    _context.RemoveRange(ruleset.Rules);
                }
                _context.Remove(ruleset);
                _context.SaveChanges();
            }
            RuleSetDto ruleSetDto = new RuleSetDto
            {
                Municipality = "KaunasUnitTest",
                TaxRule = TaxRule.Rule1,
                Rules = new List<RuleDto>
                {
                    new RuleDto
                {
                    Schedule = Schedule.Year,
                    FromDate = new DateTime(2020, 01, 01),
                    ToDate = new DateTime(2020, 12, 31),
                    Tax=0.3M

                },
                new RuleDto
                {
                    Schedule = Schedule.Month,
                    FromDate = new DateTime(2020, 01, 01),
                    ToDate = new DateTime(2020, 01, 31),
                    Tax = 0.2M

                },
                new RuleDto
                {
                    Schedule = Schedule.Week,
                    FromDate = new DateTime(2020, 01, 06),
                    ToDate = new DateTime(2020, 01, 12),
                    Tax = 0.1M

                }
                }
            };

            TaxManager taxManager = new TaxManager(_repository);
            int result = await taxManager.AddRuleSet(ruleSetDto);
            Assert.True(result > 0);
        }
        [Fact]
        public async Task AddRuleSetException()
        {
            try
            {
                RuleSetDto ruleSetDto = new RuleSetDto
                {
                    Municipality = "KaunasUnitTest",
                    TaxRule = TaxRule.Rule1,
                    Rules = new List<RuleDto>
                {
                    new RuleDto
                {
                    Schedule = Schedule.Year,
                    FromDate = new DateTime(2020, 01, 01),
                    ToDate = new DateTime(2020, 12, 31),
                    Tax=0.3M

                },
                new RuleDto
                {
                    Schedule = Schedule.Month,
                    FromDate = new DateTime(2020, 01, 01),
                    ToDate = new DateTime(2020, 01, 31),
                    Tax = 0.2M

                },
                new RuleDto
                {
                    Schedule = Schedule.Week,
                    FromDate = new DateTime(2020, 01, 06),
                    ToDate = new DateTime(2020, 01, 12),
                    Tax = 0.1M

                }
                }
                };
                TaxManager taxManager = new TaxManager(_repository);
                int result = await taxManager.AddRuleSet(ruleSetDto);
            }
            catch (Exception ex)
            {
                Assert.True(ex != null);
            }
        }
        [Theory]
        [InlineData("Kaunas", "2020-01-01")]
        public async Task GetTaxRule1(string Municipality, string Date)
        {
            TaxManager taxManager = new TaxManager(_repository);
            var result = await taxManager.GetTax(Municipality, Convert.ToDateTime(Date));
            Assert.True(result.TaxRule == 1 && result.Result == 0.5M);
        }
        [Theory]
        [InlineData("Vilnius", "2020-01-01")]
        public async Task GetTaxRule2(string Municipality, string Date)
        {
            TaxManager taxManager = new TaxManager(_repository);
            var result = await taxManager.GetTax(Municipality, Convert.ToDateTime(Date));
            Assert.True(result.TaxRule == 2 && result.Result == 0.1M);
        }
        [Theory]
        [InlineData("Vilnius1", "2020-01-01")]
        public async Task GetTaxRuleNoDataFound(string Municipality, string Date)
        {
            try
            {
                TaxManager taxManager = new TaxManager(_repository);
                var result = await taxManager.GetTax(Municipality, Convert.ToDateTime(Date));
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message == "No data found");
            }

        }
    }
}
