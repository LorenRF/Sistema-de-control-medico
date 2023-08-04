using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IHabitacion : IService
    {
        List<Habitacion> getRooms();
        Habitacion getRoom(int id);

    }
}
