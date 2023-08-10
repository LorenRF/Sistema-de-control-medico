using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CHabitacionService : IHabitacion
    {
        private readonly Context.DBControl_medicoContext context;

        public CHabitacionService(Context.DBControl_medicoContext context)
        {
            this.context = context;
        }

        public List<GetHabitacion> getRoom(int? id)
        {
            var habitaciones = new List<GetHabitacion>();

            try
            {
                habitaciones = context.Habitaciones.FromSqlInterpolated($"GetHabitacion {id}").ToList();
       
            }
            catch (Exception ex)
            {

                Console.WriteLine("Hubo un error al obtener la habitacion" + ex);
            }

            return habitaciones;

        }



    }
}
