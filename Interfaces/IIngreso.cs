using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IIngreso : IService
    {
        List<GetIngresos> getInternment(int? id);
        SpResult setInternment(IngresosManagerDTO model);
        SpResult updateInternment(IngresosManagerDTO model);
        SpResult DeleteInternment(IngresosManagerDTO model);
    }
}
