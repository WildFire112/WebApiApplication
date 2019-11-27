using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/students
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Students);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return db.Students.SingleOrDefault(x => x.Id == id);
        }

        // POST: api/students
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            db.Students.Find(id).Name = name;
            db.SaveChanges();
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = db.Students.SingleOrDefault(x => x.Id == id);
            if (true)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}
