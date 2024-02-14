using System;
using System.Collections.Generic;

namespace CallidryasTours.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public int? ReservaId { get; set; }
        public decimal? Monto { get; set; }
        public DateOnly? FechaPago { get; set; }

        public virtual Reserva? Reserva { get; set; }
    }
}
