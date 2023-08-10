using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CAltaService : IAltas
    {
        private readonly Context.DBControl_medicoContext context;

        public CAltaService(Context.DBControl_medicoContext context)
        {
            this.context = context;
        }
        public SpResult DeleteDischarge(AltaManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"AltaManager {model.ID_Alta}, {model.Fecha_de_salida}, {model.ID_Ingreso}, {model.Pago}, {3}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al eliminar la alta medica " + ex);
            }

            return result.FirstOrDefault();
        }

        public List<GetAltas> getDischarge(int? id)
        {
            var ingresos = new List<GetAltas>();

            try
            {
                ingresos = context.getAltas.FromSqlInterpolated($"GetAltas {id}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("error al obtener las altas " + ex);
            }

            return ingresos;

        }


        public SpResult setDischarge(AltaManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"AltaManager {model.ID_Alta}, {model.Fecha_de_salida}, {model.ID_Ingreso}, {model.Pago}, {1}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al insertar la alta medica " + ex);
            }

            return result.FirstOrDefault();
        }

        public SpResult updateDischarge(AltaManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"AltaManager {model.ID_Alta}, {model.Fecha_de_salida}, {model.ID_Ingreso}, {model.Pago}, {2}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al actualizar alta medica" + ex);
            }

            return result.FirstOrDefault();
        }
    }
}
