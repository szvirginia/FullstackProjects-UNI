using CheckPaymentSystem_API.Data;
using CheckPaymentSystem_API.Models;
using Microsoft.AspNetCore.Mvc;


namespace CheckPaymentSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckPaymentController : ControllerBase
    {
        readonly ICheckPaymentRepository _repository;

        public CheckPaymentController(ICheckPaymentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CheckPaymentController>
        [HttpGet]
        public IEnumerable<CheckEntity> Get()
        {
            return this._repository.Read();
        }

        // GET api/<CheckPaymentController>/5
        [HttpGet("{id}")]
        public CheckEntity Get(int id)
        {
            return this._repository.ReadById(id);
        }

        // POST api/<CheckPaymentController>
        [HttpPost]
        public void Post([FromBody] CheckEntity checkEntity)
        {
            this._repository.Create(checkEntity);
        }

        // PUT api/<CheckPaymentController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] CheckEntity checkEntity)
        {
            this._repository.Update(checkEntity);
        }

        // DELETE api/<CheckPaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        [HttpGet("sum-all-payment")]
        public int SumAllPayment()
        {
            return this._repository.SumAllPayment();
        }
    }
}
