//using System;
//using System.Collections.Generic;

//namespace Sistema_de_control_medico.Models
//{
//    public partial class Paciente
//    {
//        public Paciente()
//        {
//            Cita = new HashSet<Cita>();
//            Ingresos = new HashSet<Ingreso>();
//        }

//        public int Id { get; set; }
//        public string? Cedula { get; set; }
//        public string? Nombre { get; set; }
//        public string? Apellido { get; set; }
//        public bool? Asegurado { get; set; }

//        public virtual ICollection<Cita> Cita { get; set; }
//        public virtual ICollection<Ingreso> Ingresos { get; set; }
//    }
//}
