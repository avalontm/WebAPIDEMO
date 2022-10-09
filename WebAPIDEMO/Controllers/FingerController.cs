using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPIDEMO.DataBase.Tables;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FingerController : ControllerBase
    {
        // GET: api/<FingerController>
        [HttpGet]
        public string Get()
        {
            return String.Empty;
        }

        // GET api/<FingerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Fingers finger = Fingers.Find(id);
            return finger.ToJson();
        }

        // POST api/<FingerController>
        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {

        }

        // PUT api/<FingerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JsonElement value)
        {

        }

        // DELETE api/<FingerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
