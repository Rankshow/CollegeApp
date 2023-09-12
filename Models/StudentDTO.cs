using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace CollegeApp.Models
{
    public class StudentDTO
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(10)]
        public string? StudentName { get; set; } 
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string? Email { get; set; }   
        [Required]
        public string? Address { get; set; } 
        [DateCheck]
        public DateTime AdmissionDate  { get;  set; }    
    }
}