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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            // ! Commented DTO is another option
            // var students = new List<StudentDTO>();
            // foreach (var item in CollegeRepository.Students)
            // {
            //     StudentDTO obj = new StudentDTO()
            //     {
            //         Id = item.Id,
            //         StudentName = item.StudentName,
            //         Address = item.Address, 
            //         Email = item.Email,
            //     };
            //     students.Add(obj);
            // }
            //  * Using Link DTO is a better choice
            var students = CollegeRepository.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Address = s.Address,
                Email = s.Email
            });
            // ! Ok - 200 - success
            return Ok(students);
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            // BadRequest - 400 - BadRequest - Client Error
            if (id <= 0)
              return BadRequest();

              var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            //   NotFound - 404 - NotFound - Client error
                if (student == null)
                return NotFound($"The student with id {id} not found");

                var studentDTO = new StudentDTO
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    Email = student.Email,
                    Address = student.Address,
                };
            // Ok - 200 - success
                return Ok(studentDTO);
        }
        [HttpGet]
        [Route("{name:alpha}", Name = "GetStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            // BadRequest - 400 - BadRequest - Client Error
            if (string.IsNullOrEmpty(name))
            return BadRequest();

            var student = CollegeRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();
            // BadRequest - 400 - BadRequest - Client Error
            if (student == null)
            return NotFound($"The student with name {name} not Found");

            var studentDTO = new StudentDTO
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    Email = student.Email,
                    Address = student.Address,
                };
            // Ok - 200 - success
            return Ok(studentDTO);
        }
        [HttpDelete("{id}", Name = "DeleteStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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