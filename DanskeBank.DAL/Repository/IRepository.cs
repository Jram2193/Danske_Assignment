using DanskeBank.DAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank.DAL.Repository
{
    public interface IRepository
    {
        Task<RuleSetDto> GetRuleSet(string Municipality);
        Task<int> AddRuleSet(RuleSetDto ruleSet);
    }
}
