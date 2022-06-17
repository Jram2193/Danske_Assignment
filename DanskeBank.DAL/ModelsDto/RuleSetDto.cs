using DanskeBank.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace DanskeBank.DAL.ModelsDto
{
    //input object model
    public class RuleSetDto
    {
        public int RuleSetId { get; set; }
        [Required(ErrorMessage = "Municipality is required")]
        public string Municipality { get; set; }
        [Required(ErrorMessage = "TaxRule is required")]
        [EnumDataType(typeof(TaxRule))]
        [JsonConverter(typeof(StringEnumConverter))]
        public TaxRule TaxRule { get; set; }
        [Required(ErrorMessage ="Rules is required")]
        public List<RuleDto> Rules { get; set; }
    }
}
