using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CIngresoService : IIngreso
    {

        private readonly Context.DBControl_medicoContext context;

        public CIngresoService(Context.DBControl_medicoContext context)
        {
            this.context = context;
        }

        public SpResult DeleteInternment(IngresosManagerDTO model)
        {
            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"IngresosManager {model.ID_Ingreso}, {model.Fecha_de_ingreso}, {model.ID_Habitacion}, {model.ID_Paciente}, {3}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al eliminar el internamiento " + ex);
            }

            return result.FirstOrDefault();
        }


        public List<GetIngresos> getInternment(int? id)
        {
            var ingresos = new List<GetIngresos>();

            try
            {
                ingresos = context.getIngresos.FromSqlInterpolated($"GetIngresos {id}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("error al obtener los ingresos " + ex);
            }

            return ingresos;
        }

        public SpResult setInternment(IngresosManagerDTO model)
        {
            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"IngresosManager {model.ID_Ingreso}, {model.Fecha_de_ingreso}, {model.ID_Habitacion}, {model.ID_Paciente}, {1}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al insertar cita " + ex);
            }

            return result.FirstOrDefault();
        }

        public SpResult updateInternment(IngresosManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"IngresosManager {model.ID_Ingreso}, {model.Fecha_de_ingreso}, {model.ID_Habitacion}, {model.ID_Paciente}, {2}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al insertar cita " + ex);
            }

            return result.FirstOrDefault();
        }
    }
}
