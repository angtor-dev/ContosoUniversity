using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres.")]
        [Column("FirstName")]
        [Display(Name = "Nombre")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Inscripción")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Nombre Completo")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        [Display(Name = "Inscripciones")]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}