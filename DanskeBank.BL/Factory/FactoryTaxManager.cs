using DanskeBank.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.BL.Factory
{
    public class FactoryTaxManager
    {
        //this factory class is deside which subclass object need to create
        public ITaxRule CreateTaxCalculator(TaxRule taxRule)
        {
            ITaxRule tax = null;
            if(taxRule==TaxRule.Rule1)
            {
                //create object for rule 1 
                tax = new TaxRule1Factory();
            }
            else if(taxRule==TaxRule.Rule2)
            {
                //create object for rule 2
                tax = new TaxRule2Factory();
            }
            return tax;
        }
    }
}
