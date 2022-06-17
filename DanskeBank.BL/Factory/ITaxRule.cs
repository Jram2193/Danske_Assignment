using DanskeBank.DAL.ModelsDto;
using System;


namespace DanskeBank.BL.Factory
{
    //Factory interface
    public interface ITaxRule
    {
        decimal CalculateTax(RuleSetDto ruleSet, DateTime dateTime);
    }
}
