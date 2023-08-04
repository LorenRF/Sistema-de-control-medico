using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Cita
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }

        public virtual Medico? IdMedicoNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
