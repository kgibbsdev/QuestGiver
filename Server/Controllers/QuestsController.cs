using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using QuestGiver.Shared;
using System.Text.Json;
using System.IO;
using System.Reflection;
using QuestGiver.Server.Utilities;
using System;

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
            return QuestUtils.GetQuests();
        }

        // GET: api/<QuestsController/random>
        [HttpGet("random")]
        public Quest GetRandom()
        {
            return QuestUtils.GetRandomQuest();
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
