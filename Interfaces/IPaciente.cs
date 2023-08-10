using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IPaciente : IService
    {
        List<GetPacientes> getPatient(int? id);
        SpResult setPatient(PacientesManagerDTO model);
        SpResult updatePatient(PacientesManagerDTO model);
        SpResult DeletePatient(PacientesManagerDTO model);
    }
}
