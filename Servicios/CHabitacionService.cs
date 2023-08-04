using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CHabitacionService : IHabitacion, IService
    {
        private readonly DBControl_medicoContext context;

        public CHabitacionService(DBControl_medicoContext context)
        {
            this.context = context;
        }

        public Habitacion getRoom(int id)
        {
            List<Habitacion> rooms = getRooms();

            foreach (var room in rooms)
            {
                if (room.Id == id)
                {
                    return room;
                }
            }

            return null;
        }

        public List<Habitacion> getRooms()
        {
            return context.Habitaciones.ToList();
        }



    }
}
