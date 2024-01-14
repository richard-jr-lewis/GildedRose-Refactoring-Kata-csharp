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
        [Produces("text/plain")]
        public string Get() => Scenario.Run(null);

        // GET api/<GildedRoseController>/5
        [HttpGet("{daysOverride}")]
        [Produces("text/plain")]
        public string Get(int daysOverride) => Scenario.Run(daysOverride);
    }
}
