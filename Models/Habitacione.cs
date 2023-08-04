using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Habitacione
    {
        public Habitacione()
        {
            Ingresos = new HashSet<Ingreso>();
        }

        public int Id { get; set; }
        public int? Numero { get; set; }
        public string? Tipo { get; set; }
        public double? Precio { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
