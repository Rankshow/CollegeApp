namespace CollegeApp.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>(){
            new Student
              {
                Id = 1,
                StudentName = "chioma",
                Email = "Chiomail1@gmail.com",
                Address = "Lagos, Nigeria"
              },
              new Student
                {
                Id = 2,
                StudentName = "philip",
                Email = "philipryrl2@gmail.com",
                Address = "Abia, Nigeria"
              } 
        };
    }
}