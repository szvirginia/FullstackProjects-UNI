using ExamGradeAnalyzer_API.Data;
using ExamGradeAnalyzer_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamGradeAnalyzer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeAnalyzerController : ControllerBase
    {
        readonly IGradeAnalyzerRepository _repo;
        public GradeAnalyzerController(IGradeAnalyzerRepository _repo)
        {
            this._repo = _repo;
        }

        // GET: api/<GradeAnalyzerController>
        [HttpGet]
        public IEnumerable<Grade> Get()
        {
            return this._repo.Read();
        }

        // GET api/<GradeAnalyzerController>/5
        [HttpGet("{id}")]
        public Grade Get(int id)
        {
            return this._repo.ReadById(id);
        }

        // POST api/<GradeAnalyzerController>
        [HttpPost]
        public void Post([FromBody] Grade grade)
        {
            this._repo.Create(grade);
        }

        // PUT api/<GradeAnalyzerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Grade grade)
        {
            this._repo.Update(grade);
        }

        // DELETE api/<GradeAnalyzerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._repo.Delete(id);
        }

        [HttpGet("get-average")]
        public decimal GetAverage()
        {
            return (decimal)this._repo.GetAverage();
        }
    }
}
