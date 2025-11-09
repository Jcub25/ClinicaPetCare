using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaPetCare.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una especie.")]
        public string Especie { get; set; } 

        [Required(ErrorMessage = "La raza es obligatoria.")]
        public string Raza { get; set; }

        [Range(0, 25, ErrorMessage = "La edad debe estar entre 0 y 25 años.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El nombre del dueño es obligatorio.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre del dueño debe tener al menos 3 caracteres.")]
        public string NombreDueno { get; set; }

        [Required(ErrorMessage = "El telefono del dueño es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El telefono debe tener exactamente 8 digitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        [DataType(DataType.Date)]
        [FechaNoFutura(ErrorMessage = "La fecha de ingreso no puede ser futura.")]
        public DateTime FechaIngreso { get; set; }
    }

    // 🔹 Validación personalizada para que la fecha no sea futura
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