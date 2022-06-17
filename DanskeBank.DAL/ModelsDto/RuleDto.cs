using DanskeBank.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DanskeBank.DAL.ModelsDto
{
    //input object model
    public class RuleDto
    {
        public int RuleId { get; set; }
        public int RuleSetId { get; set; }
        [Required(ErrorMessage = "Schedule is required")]
        [EnumDataType(typeof(Schedule))]
        [JsonConverter(typeof(StringEnumConverter))]
        public Schedule Schedule { get; set; }
        [Required(ErrorMessage = "From Date is required")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "To Date is required")]
        public DateTime ToDate { get; set; }
        [Required(ErrorMessage ="Tax is required")]
        public decimal Tax { get; set; }
    }
}
