using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Otros
{
    public class CCostoInternamiento
    {
        public float total { get; set; }
        IHabitacion habitacion { get; set; }
        public float CalcularCosto(int idHabitacion, int dias)
        {
            Habitacion room = habitacion.getRoom(idHabitacion);

            float precioHabitacion = (float)room.Precio;

            total = dias * precioHabitacion;
            return total;
        }

        public int diasTranscurridos(DateTime ingreso, DateTime salida)
        {

            int dias = salida.Day - ingreso.Day;

            return dias;
        }
    }
}
