using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using QuestGiver.Shared;
using System.Text.Json;
using System.IO;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuestGiver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestsController : ControllerBase
    {
        // GET: api/<QuestsController>
        [HttpGet]
        public IEnumerable<Quest> Get()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var outputFile = Path.Combine(outputDirectory, "Data\\quests.json");

            string questsJsonString = System.IO.File.ReadAllText(outputFile);

            QuestResult qr = JsonSerializer.Deserialize<QuestResult>(questsJsonString);

            return qr.Quests;
        }

        // GET api/<QuestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
