using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace USMS.Models
{
    public class Lesson
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int LessonID { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string Title { get; set; }
        [Range(0,5)]
        public int Credit { get; set; }
        

        public ICollection<LessonAssigment> LessonAssigments { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
