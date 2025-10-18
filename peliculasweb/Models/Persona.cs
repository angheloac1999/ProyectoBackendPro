using System;
using System.ComponentModel.DataAnnotations;

namespace peliculasweb.Models
{
    public abstract class Persona
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
    }
}