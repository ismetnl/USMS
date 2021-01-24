using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USMS.Models
{
    public class LessonAssigment
    {
        public int LessonID { get; set; }
        public int InstructorID { get; set; }

        public Lesson Lesson { get; set; }
        public Instructor Instructor { get; set; }
    }
}
