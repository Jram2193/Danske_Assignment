using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.DAL.Models
{
    //rule entity 
    public class Rule
    {
        public int RuleId { get; set; }
        public int RuleSetId { get; set; }
        public string Schedule { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Tax { get; set; }
        public virtual RuleSet RuleSet { get; set; }
    }
}
