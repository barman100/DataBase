using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerName(id);
        }
        [HttpGet]
        public string GetCount()
        {
            DBHandler dBHandler = new DBHandler();
            return dBHandler.GetPlayerCount();
        }
        
        [HttpPost]
        public void Post([FromForm] string name)
        {
            DBHandler dBHandler = new DBHandler();
            dBHandler.AddPlayer(name);
        }
        [HttpDelete]
        public void Delete()
        {
            DBHandler dBHandler = new DBHandler();
            dBHandler.DeletePlayer();
        }
    }
}
