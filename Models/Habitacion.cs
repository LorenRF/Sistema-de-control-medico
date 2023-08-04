using Sistema_de_control_medico.Interfaces;
using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Habitacion : IModelo
    {
        public Habitacion()
        {
            Alta = new HashSet<Alta>();
            Ingresos = new HashSet<Ingreso>();
        }

        public int Id { get; set; }
        public int? Numero { get; set; }
        public string? Tipo { get; set; }
        public double? Precio { get; set; }

        public virtual ICollection<Alta> Alta { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
