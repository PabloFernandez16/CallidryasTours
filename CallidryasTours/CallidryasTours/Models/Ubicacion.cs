using System;
using System.Collections.Generic;

namespace CallidryasTours.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
