using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {

        // GET api/<ScoreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ScoreController>
        [HttpPost]
        public void Post([FromForm] string score)
        {
            DBHandler dBHandler = new DBHandler();
            dBHandler.UpdateScore(score);
        }

        // DELETE api/<ScoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
