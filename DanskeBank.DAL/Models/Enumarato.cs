using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.DAL.Models
{
    //enum for tax type in ruleset
    public enum TaxRule
    {
        Rule1=1,
        Rule2=2
    }
    //enum for category in rule
    public enum Schedule
    {
        Year,
        Month,
        Week,
        Day
    }
}
