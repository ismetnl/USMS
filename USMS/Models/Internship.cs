using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace USMS.Models
{
    public class Internship
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Programming Language")]
        public string PL { get; set; } // Programming Language


        [Required]
        [StringLength(50)]
        [Display(Name = "Subject")]
        public string subject { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public Student Student { get; set; }
    }
}
