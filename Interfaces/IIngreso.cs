using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IIngreso : IService
    {
        List<Ingreso> getInternments();
        Ingreso getInternment(int id);
        string setInternment(DateTime fechaHoraIngreso, int habitacion, int paciente);
        string updateInternment(int id, DateTime fechaHoraIngreso, int habitacion, int paciente);
        string DeleteInternment(int id);
    }
}
