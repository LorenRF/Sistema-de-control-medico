using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CCitaService : ICita
    {
        private readonly DBControl_medicoContext context;

        public CCitaService(DBControl_medicoContext context)
        {
            this.context = context;
        }
        public string DeleteAppointment(int id)
        {
            Cita cita = context.Citas.FirstOrDefault(u => u.Id == id);

            string? result;
            try
            {
                if (cita != null)
                {
                    context.Citas.Remove(cita);
                    context.SaveChanges();
                    result = "cita eliminado correctamente";
                }
                else
                {
                    result = "cita Nulo";
                }

            }
            catch (Exception ex)
            {
                result = "Hubo un error al eliminar la cita" + ex;
            }
            return result;

        }

        public Cita getAppointment(int id)
        {
            List<Cita> citas = getAppointments();

            foreach (var cita in citas)
            {
                if (cita.Id == id)
                {
                    return cita;
                }
            }

            return null;
        }

        public List<Cita> getAppointments()
        {
            return context.Citas.ToList();
        }

        public string setAppointment(DateTime fechaHora, int medico, int paciente)
        {
            Cita cita = new Cita
            {
                Fecha = fechaHora,
                IdMedico = medico,
                IdPaciente = paciente,

            };

            string? result;
            try
            {
                context.Citas.Add(cita);
                context.SaveChanges();
                result = "cita agregado correctamente";
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el cita" + ex;
            }
            return result;
        }

        public string updateAppointment(int id, DateTime fechaHora, int medico, int paciente)
        {

            Cita cita = context.Citas.FirstOrDefault(u => u.Id == id);
            string? result;
            try
            {
                if (cita != null)
                {
                    // Actualizar los campos del cita según los parámetros recibidos
                    if (fechaHora != null)
                    {
                        cita.Fecha = fechaHora;
                    }
                    if (medico != null)
                    {
                        cita.IdMedico = medico;
                    }
                    if (paciente != null)
                    {
                        cita.IdPaciente = paciente;
                    }


                    context.Citas.Update(cita);
                    context.SaveChanges();
                    result = "cita actualizado correctamente";
                }
                else
                {
                    result = "cita nulo";

                }
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el cita" + ex;
            }
            return result;
        }
    }
}
