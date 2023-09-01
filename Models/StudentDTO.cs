namespace CollegeApp.Models
{
    public class StudentDTO
    {
       public int Id { get; set; }
        public required string StudentName { get; set; } 
        public required string Email { get; set; }   
        public required string Address { get; set; } 
    }
}