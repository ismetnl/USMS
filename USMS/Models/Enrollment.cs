using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USMS.Models
{
    public class Enrollment
    {
        
        public int EnrollmentID { get; set; }
        
        public int? midterm { get; set; }
        public int? final { get; set; }
        public string grade { get; set; }

        public int StudentID { get; set; }
        public int LessonID { get; set; }


        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
