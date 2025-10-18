using System.Collections.Generic;

namespace peliculasweb.Models
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Region { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Proyeccion> Proyecciones { get; set; }
    }
}