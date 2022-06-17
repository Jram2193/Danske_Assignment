using DanskeBank.BL.Manager;
using DanskeBank.DAL.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeBank.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        //Business Logic class object declaration
        private readonly ITaxManager _taxManager;
        //Business Logic class object declaration
        private readonly ILogger<TaxController> _logger;
        public TaxController(ITaxManager taxManager,ILogger<TaxController> logger)
        {
            //Initialize object
            _taxManager = taxManager;
            _logger = logger;
        }
        //get method to get the tax value for Municipality
        [HttpGet]
        public async Task<IActionResult> GetTax([FromQuery]string Municipality,DateTime DateTime)
        {
            try
            {
                var result = await _taxManager.GetTax(Municipality, DateTime);
                //logging the out put in console windoe
                _logger.LogInformation(JsonConvert.SerializeObject(result));
                return Ok(result);
            }
            catch(Exception ex)
            {
                //logging the out put in console windoe
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        //post method to add rule set value
        [HttpPost]
        public async Task<IActionResult> AddRuleSet(RuleSetDto ruleSet)
        {
            try
            {
                var result = await _taxManager.AddRuleSet(ruleSet);
                _logger.LogInformation(JsonConvert.SerializeObject(result));
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
