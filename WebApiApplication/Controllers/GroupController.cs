using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/groups
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Groups);
        }

        // GET: api/groups/301
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(db.Students.Where(st => st.Group_id == id));
        }

        // GET: api/groups/students
        [HttpGet]
        [Route("students")]
        public IActionResult GetWithStudents()
        {
            return Ok(
                db.Groups.Select(group => new { 
                        group_info = group, 
                        students = db.Students.Where(st => st.Group_id == group.Id).ToList() 
                    })
                );
        }

        // POST: api/groups
        [HttpPost]
        public void Post([FromBody] Group group)
        {
            db.Groups.Add(group);
            db.SaveChanges();
        }

        // PUT: api/Group/301
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            db.Groups.Find(id).Name = name;
            db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var group = db.Groups.SingleOrDefault(x => x.Id == id);
            if (true)
            {
                db.Groups.Remove(group);
                db.SaveChanges();
            }
        }
    }
}
