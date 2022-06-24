using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required, Display(Name = "Last Name"), 
            StringLength(50), 
            RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Required, 
            Display(Name = "First & Middle Name"), 
            StringLength(60), 
            RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Column("FirstName")]
        public string FirstMidName { get; set; }

        [Display(Name = "Enrollment Date"), 
            DataType(DataType.Date), 
            DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        // Will not be generated in the database
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
