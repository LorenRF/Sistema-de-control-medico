using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Interfaces
{
    public interface IAltas : IService
    {
        List<Alta> getDischarge();
        Alta getDischarge(int id);
        string setDischarge(DateTime fechaHoraSalida, DateTime fechaHoraIngreso, int habitacion, int paciente);
        string updateDischarge(int id, DateTime fechaHoraSalida, DateTime fechaHoraIngreso, int habitacion, int paciente, float pago);
        string DeleteDischarge(int id);
    }
}
