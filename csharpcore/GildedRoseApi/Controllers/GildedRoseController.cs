using GildedRoseKata;
using Microsoft.AspNetCore.Mvc;

namespace GildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GildedRoseController : ControllerBase
    {
        // GET: api/<GildedRoseController>
        [HttpGet]
        public string Get() => Scenario.Run(null);

        // GET api/<GildedRoseController>/5
        [HttpGet("{daysOverride}")]
        public string Get(int daysOverride) => Scenario.Run(daysOverride);
    }
}
