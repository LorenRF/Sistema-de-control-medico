using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CIngresoService : IIngreso
    {

        private readonly DBControl_medicoContext context;

        public CIngresoService(DBControl_medicoContext context)
        {
            this.context = context;
        }

        public string DeleteInternment(int id)
        {
            Ingreso ing = context.Ingresos.FirstOrDefault(u => u.Id == id);

            string? result;
            try
            {
                if (ing != null)
                {
                    context.Ingresos.Remove(ing);
                    context.SaveChanges();
                    result = "ingreso eliminado correctamente";
                }
                else
                {
                    result = "ingreso Nulo";
                }

            }
            catch (Exception ex)
            {
                result = "Hubo un error al eliminar el ingreso" + ex;
            }
            return result;

        }

        public Ingreso getInternment(int id)
        {
            List<Ingreso> ingresos = getInternments();

            foreach (var ing in ingresos)
            {
                if (ing.Id == id)
                {
                    return ing;
                }
            }

            return null;
        }

        public List<Ingreso> getInternments()
        {
            return context.Ingresos.ToList();
        }

        public string setInternment(DateTime fechaHoraIngreso, int habitacion, int paciente)
        {
            Ingreso ingreso = new Ingreso
            {
                FechaDeIngreso = fechaHoraIngreso,
                IdHabitacion = habitacion,
                IdPaciente = paciente

            };

            string? result;
            try
            {
                context.Ingresos.Add(ingreso);
                context.SaveChanges();
                result = "ingreso agregado correctamente";
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el ingreso" + ex;
            }
            return result;
        }

        public string updateInternment(int id, DateTime fechaHoraIngreso, int habitacion, int paciente)
        {

            Ingreso ingreso = context.Ingresos.FirstOrDefault(u => u.Id == id);
            string? result;
            try
            {
                if (ingreso != null)
                {
                    Actualizar los campos del ingreso según los parámetros recibidos
                    if (fechaHoraIngreso != null)
                    {
                        ingreso.FechaDeIngreso = fechaHoraIngreso;
                    }
                    if (habitacion != null)
                    {
                        ingreso.IdHabitacion = habitacion;
                    }
                    if (paciente != null)
                    {
                        ingreso.IdPaciente = paciente;
                    }



                    context.Ingresos.Update(ingreso);
                    context.SaveChanges();
                    result = "medico actualizado correctamente";
                }
                else
                {
                    result = "ingreso nulo";

                }
            }
            catch (Exception ex)
            {
                result = "Hubo un error al insertar el ingreso" + ex;
            }
            return result;
        }
    }
}
