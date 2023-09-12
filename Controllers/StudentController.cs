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
       
        [HttpPost]
        [Route("Create")] 
        //api/student/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
        {
            
            // if (!ModelState.IsValid)
            //  return BadRequest(ModelState);

            if (model == null)
            return BadRequest();

            // if (model.AdmissionDate < DateTime.Now)
            // {
            //     ModelState.AddModelError("AdmissionDate Error", "Admission data must be greater than or eqaaul to today date");
            //     return BadRequest(ModelState);
            // }
 
            int newId = CollegeRepository.Students.LastOrDefault().Id + 1;
            Student student = new Student
            {
                Id = newId, 
                StudentName = model.StudentName,
                Address = model.Address,
                Email = model.Email
            };
            CollegeRepository.Students.Add(student);
            
            model.Id = student.Id;
            // status - 201
            // http://localhost:5210/api/Student/4 - the created Url
            // New student details
            return CreatedAtRoute("GetStudentById", new { id = model.Id }, model);
        }
       
        //  * This will update the record
        [HttpPut]
        [Route("Update")] 
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateStudent([FromBody] StudentDTO model)   
        {
            if (model == null || model.Id <= 0)
             return BadRequest();

            var existingStudent = CollegeRepository.Students.Where(s => s.Id == model.Id).FirstOrDefault(); 

            if (existingStudent == null)
            return NotFound();

            existingStudent.StudentName =  model.StudentName;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;
            
            return NoContent();
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