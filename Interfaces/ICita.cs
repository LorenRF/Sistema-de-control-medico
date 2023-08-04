using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface ICita : IService
    {
        List<Cita> getAppointments();
        Cita getAppointment(int id);
        string setAppointment(DateTime fechaHora, int medico, int paciente);
        string updateAppointment(int id, DateTime fechaHora, int medico, int paciente);
        string DeleteAppointment(int id);
    }
}
