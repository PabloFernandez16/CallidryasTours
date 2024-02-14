using System;
using System.Collections.Generic;

namespace CallidryasTours.Models
{
    public partial class Guium
    {
        public Guium()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
