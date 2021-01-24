using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USMS.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Location { get; set; }


        public ICollection<Instructor> Instructors { get; set; }

    }
}
