using System.ComponentModel.DataAnnotations;

namespace PeliculaAP_I.Models
{
    public class Categoria
    {
        //modelo de base de datos
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
