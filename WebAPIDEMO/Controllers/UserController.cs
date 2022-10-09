using Microsoft.AspNetCore.Mvc;
using PluginSQL;
using System.Text.Json;
using WebAPIDEMO.DataBase.Tables;
using WebAPIDEMO.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public string Get()
        {
            List<Users> users = Users.Get();

            return users.ToJson();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Users user = Users.Find(id);
            return user.ToJson();
        }

        // POST api/<UserController>
        [HttpPost("login")]
        public async Task<string> Login([FromBody] JsonElement value)
        {
            ResponseModel response = new ResponseModel();

            LoginModel login = value.FromJson<LoginModel>();

            if (login == null)
            {
                response.message = "error de login.";
                return response.ToJson();
            }

            Users user = Users.Get(login.email, login.password);

            if (user == null)
            {
                response.message = "error al iniciar sesion.";
                return response.ToJson();
            }

            response.status = true;
            response.message = "Login correcto.";
            response.data.Add(user);

            return response.ToJson();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JsonElement value)
        {

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            ResponseModel response = new ResponseModel();

            Users user = Users.Find(id);

            if (user == null)
            {
                response.message = "No se encontro el usuario";
                return response.ToJson();
            }

            if (!user.Delete())
            {
                response.message = "No se pudo eliminar el usuario";
                return response.ToJson();
            }

            response.status = true;
            response.message = "usaurio eliminado correctamente.";
            return response.ToJson();
        }
    }
}
