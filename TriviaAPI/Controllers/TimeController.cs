using Microsoft.AspNetCore.Mvc;

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet("{id}")]
        public float GetTime(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerTime(id);
        }
        [HttpPost]
        public void Post([FromBody] TimeData data)
        {
            float time = data.Time;
            int id = data.PlayerID;
            DBHandler dBHandler = new DBHandler();
            dBHandler.UpdateTime(time, id);
        }
    }
}
