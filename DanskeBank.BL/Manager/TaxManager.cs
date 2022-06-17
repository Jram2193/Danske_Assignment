using DanskeBank.BL.Factory;
using DanskeBank.BL.Utility;
using DanskeBank.DAL.ModelsDto;
using DanskeBank.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank.BL.Manager
{
    public class TaxManager:ITaxManager
    {
        private readonly IRepository _repository;
        public TaxManager(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddRuleSet(RuleSetDto ruleSetDto)
        {
            try
            {
                //validate the rulse set
                var validations = await Validation.RuleSetValidation(ruleSetDto);
                if(validations != null && validations.Count>0)
                {
                    throw new Exception(string.Join("|", validations));
                }
                //send the data to repository for store
                var result = await _repository.AddRuleSet(ruleSetDto);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TaxResult> GetTax(string Municipality,DateTime dateTime)
        {
            try
            {
                // Get the data from repository
                var ruleSet = await _repository.GetRuleSet(Municipality);
                if(ruleSet != null && ruleSet.Rules != null && ruleSet.Rules.Count>0)
                {
                    //chpse the which ruleset class object need to create
                    ITaxRule tax= new FactoryTaxManager().CreateTaxCalculator(ruleSet.TaxRule);
                    var taxResult = new TaxResult
                    {
                        Municipality = Municipality,
                        Date = dateTime,
                        TaxRule = (int)ruleSet.TaxRule,
                        //get tax based on Municipality and date
                        Result = tax.CalculateTax(ruleSet, dateTime)
                    };
                    return taxResult;
                }
                else
                {
                    throw new Exception("No data found");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
