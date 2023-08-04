using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Alta
    {
        public int Id { get; set; }
        public DateTime? FechaDeSalida { get; set; }
        public int? IdIngreso { get; set; }
        public double? Pago { get; set; }

        public virtual Ingreso? IdIngresoNavigation { get; set; }
    }
}
