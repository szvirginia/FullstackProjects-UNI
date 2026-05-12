using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teszt_torolheto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        public static List<string> data = new List<string>()
        {
            "alma", "körte", "barack"
        };
        // GET: api/<DataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return data;
        }


        // POST api/<DataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            data.Add(value);
        }


        // DELETE api/<DataController>/5
        [HttpDelete("{deleteData}")]
        public void Delete(string deleteData)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i]==deleteData)
                {
                    data.Remove(deleteData);
                }
            }
        }
    }
}
