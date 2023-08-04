using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CPacienteService : IPaciente
    {
        private readonly DBControl_medicoContext context;

        public CPacienteService(DBControl_medicoContext context)
        {
            this.context = context;
        }
        public string DeletePatient(int id)
        {
            Paciente paciente = context.Pacientes.FirstOrDefault(u => u.Id == id);

            string? result;

            try
            {
                if (paciente != null)
                {
                    context.Pacientes.Remove(paciente);
                    context.SaveChanges();
                    result = "Paciente eliminado correctamente";
                }
                else
                {
                    result = "Paciente Nulo";
                }

            }
            catch (Exception ex)
            {
                result = "Hubo un error al eliminar el Paciente" + ex;
            }
            return result;

        }

        public Paciente getPatient(int id)
        {
            List<Paciente> pacientes = getPatients();

            foreach (var paciente in pacientes)
            {
                if (paciente.Id == id)
                {
                    return paciente;
                }
            }

            return null;
        }

        public List<Paciente> getPatients()
        {
            return context.Pacientes.ToList();
        }

        public string setPatient(string cedula, string nombre, string apellido, string asegurado)
        {
            Paciente pat = new Paciente
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                Asegurado = asegurado

            };

            string? result;
            try
            {
                context.Pacientes.Add(pat);
                context.SaveChanges();
                result = "Paciente agregado correctamente";
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el Paciente" + ex;
            }
            return result;
        }

        public string updatePatient(int id, string cedula, string nombre, string apellido, string asegurado)
        {
            Paciente pat = context.Pacientes.FirstOrDefault(u => u.Id == id);
            string? result;
            try
            {
                if (pat != null)
                {
                    // Actualizar los campos del medico según los parámetros recibidos
                    if (nombre != null)
                    {
                        pat.Nombre = nombre;
                    }
                    if (apellido != null)
                    {
                        pat.Apellido = apellido;
                    }

                    if (!string.IsNullOrEmpty(asegurado))
                    {
                        pat.Asegurado = asegurado;
                    }

                    context.Pacientes.Update(pat);
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
