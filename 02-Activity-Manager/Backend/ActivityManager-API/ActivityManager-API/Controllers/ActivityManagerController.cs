using ActivityManager_API.Data;
using ActivityManager_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActivityManager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityManagerController : ControllerBase
    {
        readonly IActivityManagerRepository _repo;

        public ActivityManagerController(IActivityManagerRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ActivityManagerController>
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return this._repo.Read();
        }

        // GET api/<ActivityManagerController>/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return this._repo.ReadById(id);
        }

        // POST api/<ActivityManagerController>
        [HttpPost]
        public void Post([FromBody] Activity activity)
        {
            this._repo.Create(activity);
        }

        // PUT api/<ActivityManagerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Activity activity)
        {
            this._repo.Update(activity);
        }

        // DELETE api/<ActivityManagerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._repo.Delete(id);
        }

        [HttpGet("sum-duration")]
        public int SumHours()
        {
            return this._repo.SumHours();
        }
    }
}
