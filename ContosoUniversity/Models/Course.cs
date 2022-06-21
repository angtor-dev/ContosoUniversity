using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        //especifica que la aplicación proporciona la clave principal, en lugar de generarla la base de datos.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Número")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Titulo debe tener entre 3 y 50 caracteres.")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Range(0, 5, ErrorMessage = "Debe ser un valor entre 0 y 5.")]
        [Display(Name = "Creditos")]
        public int Credits { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un departamanento.")]
        public int DepartmentID { get; set; }

        [Display(Name = "Departamento")]
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}