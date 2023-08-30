using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return new List<Student> { 
                new Student
              {
                Id = 1,
                StudentName = "Student 1",
                Email = "studentemail@gmail",
                Address = "Lagos, Nigeria"
              },
              new Student
                {
                Id = 2,
                StudentName = "Student 2",
                Email = "studentemail@gmail",
                Address = "Lagos, Nigeria"
              }
            };
        }
    }
}