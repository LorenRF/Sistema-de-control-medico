using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Ingreso
    {
        public Ingreso()
        {
            Alta = new HashSet<Alta>();
        }

        public int Id { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public int? IdHabitacion { get; set; }
        public int? IdPaciente { get; set; }

        public virtual Habitacione? IdHabitacionNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
        public virtual ICollection<Alta> Alta { get; set; }
    }
}
