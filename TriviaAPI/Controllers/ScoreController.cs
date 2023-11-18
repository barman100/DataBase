using Microsoft.AspNetCore.Mvc;

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        [HttpGet("{id}")]
        public int GetScore(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerScore(id);
        }
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
