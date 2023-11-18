using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCountController : ControllerBase
    {
        [HttpGet("{id}")]
        public int GetQuestionCount(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerQuestionCount(id);
        }
        [HttpPost]
        public void Post([FromBody] QuestionCountData data)
        {
            int count = data.Count;
            int id = data.PlayerID;
            DBHandler dBHandler = new DBHandler();
            dBHandler.UpdateQuestionCount(count, id);
        }
    }
}
