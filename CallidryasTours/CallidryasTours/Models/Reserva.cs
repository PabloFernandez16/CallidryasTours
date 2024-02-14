using System;
using System.Collections.Generic;

namespace CallidryasTours.Models
{
    public partial class Reserva
    {
        public Reserva()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? TourId { get; set; }
        public DateOnly? FechaReserva { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual Tour? Tour { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
