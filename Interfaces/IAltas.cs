using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IAltas : IService
    {
        List<GetAltas> getDischarge(int? id);
        SpResult setDischarge(AltaManagerDTO model);
        SpResult updateDischarge(AltaManagerDTO model);
        SpResult DeleteDischarge(AltaManagerDTO model);
    }
}
