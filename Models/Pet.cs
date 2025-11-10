using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaPetCare.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la Mascota")]
        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
        public string NombreMascota { get; set; }

        [Display(Name = "Seleccione la especie del animal")]
        [Required(ErrorMessage = "Debe seleccionar una especie.")]
        public string Especie { get; set; }

        [Display(Name = "Escriba la raza del aninaml")]
        [Required(ErrorMessage = "La raza es obligatoria.")]
        public string Raza { get; set; }

        [Display(Name = "Digite la edad del animal, utilice numeros enteros")]
        [Range(0, 25, ErrorMessage = "La edad debe estar entre 0 y 25 años.")]
        public int Edad { get; set; }

        [Display(Name = "Escriba el nombre del dueño")]
        [Required(ErrorMessage = "El nombre del dueño es obligatorio.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre del dueño debe tener al menos 3 caracteres.")]
        public string NombreDueno { get; set; }

        [Display(Name = "Digite el numero de telefono")]
        [Required(ErrorMessage = "El telefono del dueño es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El telefono debe tener exactamente 8 digitos.")]
        public string TelefonoDueno { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        [DataType(DataType.Date)]
        [FechaNoFutura(ErrorMessage = "La fecha de ingreso no puede ser futura.")]
        public DateTime FechaIngreso { get; set; }
    }

    //  Para validar que no ingresen una fecha futura
    public class FechaNoFuturaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime fecha)
            {
                return fecha <= DateTime.Today;
            }
            return true;
        }
    }
}