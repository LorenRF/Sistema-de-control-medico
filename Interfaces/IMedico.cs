using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IMedico : IService
    {
        List<Medico> getMedics();
        Medico getMedic(int id);
        string setMedic(string nombre, string apellido, int Exequatur, string especialidad);
        string updateMedic(int id, string nombre, string apellido, int Exequatur, string especialidad);
        string DeleteMedic(int id);
    }
}
