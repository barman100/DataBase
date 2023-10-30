using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        // GET api/<TimeController>/5
        [HttpGet("{id}")]
        public int GetTime(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerTime(id);
        }
        // POST api/<TimeController>
        [HttpPost]
        public void Post([FromForm] int time, [FromForm]int id)
        {
            DBHandler dBHandler = new DBHandler();
            dBHandler.UpdateTime(time, id);
        }
    }
}
