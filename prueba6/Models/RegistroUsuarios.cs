using System.ComponentModel.DataAnnotations;

namespace prueba6.Models
{
    public class RegistroUsuarios
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Edad { get; set; }
    }
}
