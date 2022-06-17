using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.DAL.Models
{
    //ruleset entity
    public class RuleSet
    {
        public int RuleSetId { get; set; }
        public string Municipality { get; set; }
        public TaxRule TaxRule { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }
    }
}
