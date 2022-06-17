using DanskeBank.DAL.Models;
using DanskeBank.DAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanskeBank.BL.Factory
{
    public class TaxRule2Factory : ITaxRule
    {
        //Rule 2 factory class
        public decimal CalculateTax(RuleSetDto ruleSet, DateTime dateTime)
        {
            decimal tax = 0;
            try
            {
                //Rule 2 get the tax for sortest preorid  againt the given date
                tax = ruleSet.Rules.Where(i => i.Schedule == Schedule.Day && i.FromDate == dateTime && i.ToDate == dateTime)
                    .Select(i => i.Tax).FirstOrDefault();

                if(tax==0)
                {
                    tax = ruleSet.Rules.Where(i => i.Schedule == Schedule.Week && i.FromDate <= dateTime && i.ToDate >= dateTime)
                    .Select(i => i.Tax).FirstOrDefault();
                }
                if (tax == 0)
                {
                    tax = ruleSet.Rules.Where(i => i.Schedule == Schedule.Month && i.FromDate <= dateTime && i.ToDate >= dateTime)
                    .Select(i => i.Tax).FirstOrDefault();
                }
                if (tax == 0)
                {
                    tax = ruleSet.Rules.Where(i => i.Schedule == Schedule.Year && i.FromDate <= dateTime && i.ToDate >= dateTime)
                    .Select(i => i.Tax).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return tax;
        }
    }
}
