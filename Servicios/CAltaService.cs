using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;
using Sistema_de_control_medico.Otros;

namespace Sistema_de_control_medico.Servicios
{
    public class CAltaService : IAltas
    {
        private readonly DBControl_medicoContext context;

        public CAltaService(DBControl_medicoContext context)
        {
            this.context = context;
        }
        public string DeleteDischarge(int id)
        {

            Alta alta = context.Altas.FirstOrDefault(u => u.Id == id);

            string? result;
            try
            {
                if (alta != null)
                {
                    context.Altas.Remove(alta);
                    context.SaveChanges();
                    result = "alta eliminada correctamente";
                }
                else
                {
                    result = "alta Nulo";
                }

            }
            catch (Exception ex)
            {
                result = "Hubo un error al eliminar la alta" + ex;
            }
            return result;
        }

        public List<Alta> getDischarge()
        {
            return context.Altas.ToList();

        }

        public Alta getDischarge(int id)
        {
            List<Alta> altas = getDischarge();

            foreach (var alta in altas)
            {
                if (alta.Id == id)
                {
                    return alta;
                }
            }

            return null;
        }

        public string setDischarge(DateTime fechaHoraSalida, DateTime fechaHoraIngreso, int habitacion, int paciente)
        {
            CCostoInternamiento costo = new CCostoInternamiento();

            Alta alta = new Alta
            {
                FechaDeSalida = fechaHoraSalida,
                FechaDeIngreso = fechaHoraIngreso,
                IdHabitacion = habitacion,
                IdPaciente = paciente,
                Pago = costo.CalcularCosto(habitacion, costo.diasTranscurridos(fechaHoraIngreso, fechaHoraSalida))

            };

            string? result;
            try
            {
                context.Altas.Add(alta);
                context.SaveChanges();
                result = "alta agregado correctamente";
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el alta" + ex;
            }
            return result;
        }

        public string updateDischarge(int id, DateTime fechaHoraSalida, DateTime fechaHoraIngreso, int habitacion, int paciente, float pago)
        {

            Alta alta = context.Altas.FirstOrDefault(u => u.Id == id);
            string? result;
            try
            {
                if (alta != null)
                {
                    // Actualizar los campos del medico según los parámetros recibidos
                    if (fechaHoraSalida != null)
                    {
                        alta.FechaDeSalida = fechaHoraSalida;
                    }
                    if (fechaHoraIngreso != null)
                    {
                        alta.FechaDeIngreso = fechaHoraIngreso;
                    }
                    if (habitacion != null)
                    {
                        alta.IdHabitacion = habitacion;
                    }
                    if (paciente != null)
                    {
                        alta.IdPaciente = paciente;
                    }
                    if (pago != null)
                    {
                        alta.Pago = pago;
                    }

                    context.Altas.Update(alta);
                    context.SaveChanges();
                    result = "medico actualizado correctamente";
                }
                else
                {
                    result = "medico nulo";

                }
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el medico" + ex;
            }
            return result;
        }
    }
}
