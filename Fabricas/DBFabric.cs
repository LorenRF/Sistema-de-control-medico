//using Sistema_de_control_medico.Interfaces;
//using Sistema_de_control_medico.Models;

//namespace Sistema_de_control_medico.Fabricas
//{
//    public class DBFabric
//    {
//        IModelo modelo { get; set; }

//        public IModelo getModelo(string tipoModelo)
//        {
//            if (tipoModelo == "alta")
//            {
//                modelo = new Alta();
//            }
//            else if (tipoModelo == "cita")
//            {
//                modelo = new Cita();
//            }
//            else if (tipoModelo == "habitacion")
//            {
//                modelo = new Habitacion();
//            }
//            else if (tipoModelo == "ingreso")
//            {
//                modelo = new Ingreso();
//            }
//            else if (tipoModelo == "medico")
//            {
//                modelo = new Medico();
//            }
//            else if (tipoModelo == "paciente")
//            {
//                modelo = new Paciente();
//            }
//            return null;
//        }
//    }
//}
