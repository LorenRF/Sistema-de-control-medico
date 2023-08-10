using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface ICita : IService
    {
        List<GetCitas> getAppointment(int? id);
        SpResult setAppointment(CitaManagerDTO model);
        SpResult updateAppointment(CitaManagerDTO model);
        SpResult DeleteAppointment(CitaManagerDTO model);
    }
}
