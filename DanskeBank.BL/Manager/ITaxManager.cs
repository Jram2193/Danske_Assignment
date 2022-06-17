using DanskeBank.DAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank.BL.Manager
{
    
    public interface ITaxManager
    {
        Task<int> AddRuleSet(RuleSetDto ruleSetDto);
        Task<TaxResult> GetTax(string Municipality, DateTime dateTime);
    }
}
