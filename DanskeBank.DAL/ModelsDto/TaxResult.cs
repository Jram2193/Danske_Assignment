using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.DAL.ModelsDto
{
    //out put model
    public class TaxResult
    {
        public string Municipality { get; set; }
        public DateTime Date { get; set; }
        public int TaxRule { get; set; }
        public decimal Result { get; set; }
    }
}
