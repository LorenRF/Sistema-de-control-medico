using Sistema_de_control_medico.Interfaces;
using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Cita : IModelo
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }

        public virtual Medico? IdMedicoNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
