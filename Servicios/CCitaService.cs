using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CCitaService : ICita
    {
        private readonly Context.DBControl_medicoContext context;

        public CCitaService(Context.DBControl_medicoContext context)
        {
            this.context = context;
        }
        public SpResult DeleteAppointment(CitaManagerDTO model)
        {
            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"CitasManager {model.ID_Cita}, {model.Fecha_Cita}, {model.ID_Medico}, {model.ID_Paciente}, {3}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al eliminar la cita " + ex);
            }

            return result.FirstOrDefault();
        }


        public List<GetCitas> getAppointment(int? id)
        {
            var citas = new List<GetCitas>();

            try
            {
                citas = context.getCitas.FromSqlInterpolated($"GetCitas {id}").ToList();
            }
            catch (Exception ex)
            {

               Console.WriteLine( "Hubo un error al obtener la cita" + ex);
            }

            return citas;

        }

        public SpResult setAppointment(CitaManagerDTO model)
        {
            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"CitasManager {model.ID_Cita}, {model.Fecha_Cita}, {model.ID_Medico}, {model.ID_Paciente}, {1}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al insertar cita " + ex);
            }

            return result.FirstOrDefault();
        }

        public SpResult updateAppointment(CitaManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"CitasManager {model.ID_Cita}, {model.Fecha_Cita}, {model.ID_Medico}, {model.ID_Paciente}, {2}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al insertar cita " + ex);
            }

            return result.FirstOrDefault();
        }
    }
}
