using Microsoft.EntityFrameworkCore.Metadata;
using Sistema_de_control_medico.Interfaces;
using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Alta: IModelo
    {
        public int Id { get; set; }
        public DateTime? FechaDeSalida { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public int? IdHabitacion { get; set; }
        public int? IdPaciente { get; set; }
        public double? Pago { get; set; }

        public virtual Habitacion? IdHabitacionNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
