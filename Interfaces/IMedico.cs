using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IMedico : IService
    {
        List<GetMedicos> getMedic(int? id);
        SpResult setMedic(MedicosManagerDTO model);
        SpResult updateMedic(MedicosManagerDTO model);
        SpResult DeleteMedic(MedicosManagerDTO model);
    }
}
