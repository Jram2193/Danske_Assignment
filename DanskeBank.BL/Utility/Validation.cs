using DanskeBank.DAL.Models;
using DanskeBank.DAL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace DanskeBank.BL.Utility
{
    public static class Validation
    {
        public async static Task<List<string>> RuleSetValidation(RuleSetDto ruleSetDto)
        {
            List<string> errors = new List<string>();
            try
            {
                await Task.Run(()=> {
                    DateTime dateTime;
                    if (ruleSetDto != null)
                    {
                        if (string.IsNullOrEmpty(ruleSetDto.Municipality))
                            errors.Add("Municipality is required");
                        if (string.IsNullOrEmpty(ruleSetDto.TaxRule.ToString()))
                            errors.Add("TaxRule is required");
                        if (!Enum.IsDefined(typeof(TaxRule), ruleSetDto.TaxRule.ToString()))
                            errors.Add($"TaxRule is not valid");
                        if (ruleSetDto.Rules == null || ruleSetDto.Rules.Count == 0)
                            errors.Add("Rules is required");
                        for (int i = 0; i <= ruleSetDto.Rules.Count - 1; i++)
                        {
                            if (string.IsNullOrEmpty(ruleSetDto.Rules[i].Schedule.ToString()))
                                errors.Add($"Rule[{i}] : Schedule is required");
                            if (!Enum.IsDefined(typeof(Schedule), ruleSetDto.Rules[i].Schedule.ToString()))
                                errors.Add($"Rule[{i}] : Schedule is not valid");
                            if (string.IsNullOrEmpty(ruleSetDto.Rules[i].FromDate.ToString()))
                                errors.Add($"Rule[{i}] : From Date is required");
                            if (string.IsNullOrEmpty(ruleSetDto.Rules[i].ToDate.ToString()))
                                errors.Add($"Rule[{i}] : To Date is required");
                            if (string.IsNullOrEmpty(ruleSetDto.Rules[i].Tax.ToString()))
                                errors.Add($"Rule[{i}] : Tax is required");

                            if (!string.IsNullOrEmpty(ruleSetDto.Rules[i].Schedule.ToString()))
                            {
                                if (ruleSetDto.Rules[i].Schedule == Schedule.Day)
                                {
                                    if (Convert.ToDateTime(ruleSetDto.Rules[i].FromDate).Date != Convert.ToDateTime(ruleSetDto.Rules[i].ToDate).Date)
                                        errors.Add($"Rule[{i}] : Schedule type Day date range should be one day");
                                }
                            }

                        }
                    }
                    else
                    {
                        errors.Add("RuleSet is required");
                    }
                    return errors;
                });
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return errors;
        }
    }
}
