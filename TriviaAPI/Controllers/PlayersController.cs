using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        
        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerName(id);
        }

        // POST api/<PlayersController>
        [HttpPost]
        public void Post([FromBody] string name)
        {
            DBHandler dBHandler = new DBHandler();
            dBHandler.AddPlayer(name);
        }

        

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
