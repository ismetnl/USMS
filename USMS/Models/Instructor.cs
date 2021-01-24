using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USMS.Models
{
    public class Instructor
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentID { get; set; }


        public Department Department { get; set; }
        public ICollection<LessonAssigment> LessonAssigments { get; set; }

    }
}
