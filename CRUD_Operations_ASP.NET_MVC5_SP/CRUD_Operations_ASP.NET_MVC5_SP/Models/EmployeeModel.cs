using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Id Empleado")]
        public int IdEmployee { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El usuario es requerido")]
        [StringLength(20)]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(20)]
        [Display(Name = "Contraseña")]
        public string UserPassword { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20)]
        [Display(Name = "Nombre")]
        public string EmployeeName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(20)]
        [Display(Name = "Apellidos")]
        public string EmployeeFamilyName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese solo números")]
        [Required(ErrorMessage = "La edad es requerida")]
        [Range(18, 60, ErrorMessage = "La edad debe estar entre los 18 y 60 años")]
        [Display(Name = "Edad")]
        public int Age { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "El correo electrónico no tiene el formato correcto")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [StringLength(80)]
        [Display(Name = "Correo electrónico")]
        public string EmailAddress { get; set; }
    }
}