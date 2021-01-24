﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace USMS.Models
{
    public class Student
    {
        
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public string FullName 
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        
        }


        public Internship Internship { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }


    }
}
