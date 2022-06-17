using DanskeBank.DAL.Models;
using DanskeBank.DAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanskeBank.BL.Factory
{
    //Rule 1 factory class
    public class TaxRule1Factory : ITaxRule
    {
        public decimal CalculateTax(RuleSetDto ruleSet, DateTime dateTime)
        {
            decimal tax = 0;
            try
            {
                //Rule 1 get the sum of tax for all the gateory againt the given date
                var schedules = new List<Schedule>() { Schedule.Year, Schedule.Month, Schedule.Week, Schedule.Day };
                schedules.ForEach(s =>
                {
                    tax += ruleSet.Rules.Where(r => r.Schedule == s && r.FromDate <= dateTime && r.ToDate >= dateTime)
                            .Select(i => i.Tax).Sum();
                });
                return tax;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
