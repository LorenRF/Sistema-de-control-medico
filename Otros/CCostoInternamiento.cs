//using Sistema_de_control_medico.Context;
//using Sistema_de_control_medico.Controllers;
//using Sistema_de_control_medico.Interfaces;
//using Sistema_de_control_medico.Models;
//using Sistema_de_control_medico.Servicios;

//namespace Sistema_de_control_medico.Otros
//{

//    public class CCostoInternamiento
//    {    
//        public float total { get; set; }
//        IHabitacion habitacion { get; set; }
//        IIngreso iingreso { get; set; }


//        public CCostoInternamiento ()
//        {
//        }
//        public float CalcularCosto(int idHabitacion, int dias)
//        {   
//            GetHabitacion room = new GetHabitacion(); 
//           List<GetHabitacion> habitaciones = habitacion.getRoom(idHabitacion);

//            foreach (var habitacion in habitaciones) {

//                if (habitacion.ID_Habitacion == idHabitacion)
//                {
//                    room = habitacion;
//                }

//            }

//            float precioHabitacion = (float)room.Precio;

//            total = dias * precioHabitacion;
//            return total;
//        }

//        public int diasTranscurridos(DateTime ingreso, DateTime salida)
//        {

//            int dias = salida.Day - ingreso.Day;

//            return dias;
//        }

//        public DateTime? getIngreso(int ingresoID)

//        {

//            List<GetIngresos> ingreso = iingreso.getInternment(ingresoID);

//            DateTime? fechaIngreso = ingreso[0].Ingresado;

//            return fechaIngreso;


//        }
//    }
//}
