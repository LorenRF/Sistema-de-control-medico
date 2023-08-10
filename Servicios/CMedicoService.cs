using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CMedicoService : IMedico
    {
        private readonly Context.DBControl_medicoContext context;

        public CMedicoService(Context.DBControl_medicoContext context)
        {
            this.context = context;
        }
        public List<GetMedicos> getMedic(int? id)
        {
            var medicos = new List<GetMedicos>();

            try
            {
                medicos = context.Medicos.FromSqlInterpolated($"GetMedicos {id}").ToList();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Hubo un error al obtener la habitacion" + ex);
            }

            return medicos;

        }

        public SpResult setMedic(MedicosManagerDTO model)
        {
            var result = new List<SpResult>();


            try
            {
                result = context.SpResult.FromSqlInterpolated($"MedicoManager {model.ID_Medico}, {model.Nombre_Medico}, {model.Apellido_Medico}, {model.Exequatur},{model.Especialidad}, {1}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al insertar el medico " + ex);
            }

            return result.FirstOrDefault();
        }

        public SpResult updateMedic(MedicosManagerDTO model)
        {
            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"MedicoManager {model.ID_Medico}, {model.Nombre_Medico}, {model.Apellido_Medico}, {model.Exequatur},{model.Especialidad}, {2}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al actualizar al medico" + ex);
            }

            return result.FirstOrDefault();
        }

        public SpResult DeleteMedic(MedicosManagerDTO model)
        {


            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"MedicoManager {model.ID_Medico}, {model.Nombre_Medico}, {model.Apellido_Medico}, {model.Exequatur},{model.Especialidad}, {3}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al eliminar la alta medica " + ex);
            }

            return result.FirstOrDefault();
        }
    }

}
