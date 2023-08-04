using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IPaciente : IService
    {
        List<Paciente> getPatients();
        Paciente getPatient(int id);
        string setPatient(string cedula, string nombre, string apellido, string asegurado);
        string updatePatient(int id, string cedula, string nombre, string apellido, string asegurado);
        string DeletePatient(int id);
    }
}
