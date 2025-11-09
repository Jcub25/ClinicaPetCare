using ClinicaPetCare.Models;

namespace ClinicaPetCare.Data
{
    public class PetRepo
    {
        // Creo la lista temporal para guardar los datos ingresados
        private static readonly List<Pet> _pets = new();

        // Devolvemos todas las mascotas registradas
        public static IReadOnlyList<Pet> ObtenerTodos() => _pets.AsReadOnly();

        // Agrega una nueva mascota
        public static void Agregar(Pet mascota)
        {
            _pets.Add(mascota);
        }
    }
}