using Sistema_de_control_medico.Interfaces;
using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Ingreso : IModelo
    {
        public int Id { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public int? IdHabitacion { get; set; }
        public int? IdPaciente { get; set; }

        public virtual Habitacion? IdHabitacionNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
