using System;
using System.Collections.Generic;

namespace CallidryasTours.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Edad { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
