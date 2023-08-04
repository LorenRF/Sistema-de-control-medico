using Sistema_de_control_medico.Interfaces;
using System;
using System.Collections.Generic;

namespace Sistema_de_control_medico.Models
{
    public partial class Medico : IModelo
    {
        public Medico()
        {
            Cita = new HashSet<Cita>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Exequatur { get; set; }
        public string? Especialidad { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
