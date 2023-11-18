using Microsoft.AspNetCore.Mvc;

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        [HttpGet]
        public Question Get()
        {
            DBHandler dBHandler = new DBHandler();
            Question question = dBHandler.GetQuestion();

            if (question == null)
            {
                throw new NullReferenceException("Question value is null");
            }
            return question;
        }
    }
}
