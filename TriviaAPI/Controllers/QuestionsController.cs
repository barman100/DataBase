using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        // GET api/<QuestionsController>/5
        [HttpGet]
        public Question Get()
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetQuestion();
        }
    }
}
