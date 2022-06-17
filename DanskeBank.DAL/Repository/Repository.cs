using DanskeBank.DAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DanskeBank.DAL.Context;
using DanskeBank.DAL.Models;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DanskeBank.DAL.Repository
{
    public class Repository : IRepository
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public Repository(DataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddRuleSet(RuleSetDto ruleSet)
        {
            try
            {
                RuleSet set = _mapper.Map<RuleSetDto, RuleSet>(ruleSet);
                _context.RuleSets.Add(set);
                await _context.SaveChangesAsync();
                return set.RuleSetId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RuleSetDto> GetRuleSet(string Municipality)
        {
            try
            {
                RuleSetDto ruleSetDto = new RuleSetDto();
                var ruleset = await _context.RuleSets
                    .Include(i => i.Rules)
                    .Where(i => i.Municipality == Municipality)
                    .FirstOrDefaultAsync();
                if (ruleset != null)
                    ruleSetDto = _mapper.Map<RuleSet, RuleSetDto>(ruleset);
                return ruleSetDto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
