using System;
using System.Collections.Generic;

namespace CallidryasTours.Models
{
    public partial class Tour
    {
        public Tour()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? UbicacionId { get; set; }
        public int? GuiaId { get; set; }

        public virtual Guium? Guia { get; set; }
        public virtual Ubicacion? Ubicacion { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
