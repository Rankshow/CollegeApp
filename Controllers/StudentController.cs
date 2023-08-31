using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("All", Name = "GetAllStudent")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            // Ok - 200 - success
            return Ok(CollegeRepository.Students);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            // BadRequest - 400 - BadRequest - Client Error
            if (id <= 0)
              return BadRequest();

              var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            //   NotFound - 404 - NotFound - Client error
                if (student == null)
                return NotFound($"The student with id {id} not found");
            // Ok - 200 - success
                return Ok(student);
        }
        [HttpGet]
        [Route("{name:alpha}", Name = "GetStudentByName")]
        public ActionResult<Student> GetStudentByName(string name)
        {
            // BadRequest - 400 - BadRequest - Client Error
            if (string.IsNullOrEmpty(name))
            return BadRequest();

            var student = CollegeRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();
            // BadRequest - 400 - BadRequest - Client Error
            if (student == null)
            return NotFound($"The student with name {name} not Found");

            // Ok - 200 - success
            return Ok(student);
        }
        [HttpDelete("{id}", Name = "DeleteStudentById")]
        public ActionResult<bool> DeleteStudent(int id)
        {
            // BadRequest - 400 - BadRequest - Client error
            if (id <= 0)
            return BadRequest();

            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            // BadRequest - 400 - BadRequest - Client error
            if (student == null)
            return BadRequest($"The student with id {id} not found");

            CollegeRepository.Students.Remove(student);

            // Ok - 200 - success 
            return Ok();
        }
       
    }
}