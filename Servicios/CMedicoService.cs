using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CMedicoService: IMedico
    {
        private readonly DBControl_medicoContext context;

        public CMedicoService(DBControl_medicoContext context)
        {
            this.context = context;
        }
        public List<Medico> getMedics()
        {
            return context.Medicos.ToList();
        }

        public Medico getMedic(int id)
        {
            List<Medico> docs = getMedics();

            foreach (var doc in docs)
            {
                if (doc.Id == id)
                {
                    return doc;
                }
            }

            return null;
        }
        public string setMedic(string nombre, string apellido, int Exequatur, string especialidad)
    {
        Medico doc = new Medico
        {
                Nombre = nombre,
                Apellido = apellido, 
                Exequatur = Exequatur,
                Especialidad = especialidad

            };

            string? result;
            try
            {
                context.Medicos.Add(doc);
                context.SaveChanges();
                result = "Usuario agregado correctamente";
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el medico" + ex;
            }
            return result;
        }

        public string updateMedic(int id, string nombre, string apellido, int Exequatur, string especialidad)
        {
        Medico doc = context.Medicos.FirstOrDefault(u => u.Id == id);
            string? result;
            try
            {
                if (doc != null)
                {
                // Actualizar los campos del medico según los parámetros recibidos
                    if (Exequatur != null)
                    {
                        doc.Exequatur = Exequatur;
                    }
                    if (nombre != null)
                    {
                    doc.Nombre = nombre;
                    }

                    if (!string.IsNullOrEmpty(apellido))
                    {
                    doc.Apellido = apellido;
                    }
                    if (!string.IsNullOrEmpty(especialidad))
                    {
                        doc.Especialidad = especialidad;
                    }

                context.Medicos.Update(doc);
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

        public string DeleteMedic(int id)
        {
        Medico doc = context.Medicos.FirstOrDefault(u => u.Id == id);

            string? result;
            try
            {
                if (doc != null)
                {
                    context.Medicos.Remove(doc);
                    context.SaveChanges();
                    result = "medico eliminado correctamente";
                }
                else
                {
                    result = "medico Nulo";
                }

            }
            catch (Exception ex)
            {
                result = "Hubo un error al eliminar el medico" + ex;
            }
            return result;


        }
    }
    
}
