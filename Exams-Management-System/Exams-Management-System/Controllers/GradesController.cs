using System.Collections.Generic;
using Domain.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exams_Management_System.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
       
        
        // GET api/grades
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public ActionResult Grades()
        {
            using (var db = new Grades())
            {
                
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
       
    }
}