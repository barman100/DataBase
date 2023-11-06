using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        // GET api/<ScoreController>/5
        [HttpGet("{id}")]
        public int GetScore(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerScore(id);
        }
        // POST api/<ScoreController>
        [HttpPost]
        public void Post([FromBody] ScoreData data)
        {
            int score = data.Score;
            int id = data.PlayerID;
            DBHandler dBHandler = new DBHandler();
            dBHandler.UpdateScore(score, id);
        }
    }
}
