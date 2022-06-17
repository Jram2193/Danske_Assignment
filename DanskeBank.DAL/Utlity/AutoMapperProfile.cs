using AutoMapper;
using DanskeBank.DAL.Models;
using DanskeBank.DAL.ModelsDto;

namespace DanskeBank.DAL.Utlity
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RuleSet, RuleSetDto>()
                .ReverseMap();
            CreateMap<Rule, RuleDto>()
                .ReverseMap();
        }
    }
}
