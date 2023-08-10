using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Servicios
{
    public class CPacienteService : IPaciente
    {
        private readonly Context.DBControl_medicoContext context;

        public CPacienteService(Context.DBControl_medicoContext context)
        {
            this.context = context;
        }
        public SpResult DeletePatient(PacientesManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"PacienteManager {model.ID_Paciente}, {model.Cedula}, {model.Nombre_Paciente}, {model.Apellido_Paciente}, {model.Asegurado}, {3}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al eliminar al paciente " + ex);
            }

            return result.FirstOrDefault();

        }

        public List<GetPacientes> getPatient(int? id)
        {
            var pacientes = new List<GetPacientes>();

            try
            {
                pacientes = context.Pacientes.FromSqlInterpolated($"GetPacientes {id}").ToList();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Hubo un error al obtener el paciente" + ex);
            }

            return pacientes;

        }

        public SpResult setPatient(PacientesManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"PacienteManager {model.ID_Paciente}, {model.Cedula}, {model.Nombre_Paciente}, {model.Apellido_Paciente}, {model.Asegurado}, {1}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al insertar al paciente " + ex);
            }

            return result.FirstOrDefault();
        }

        public SpResult updatePatient(PacientesManagerDTO model)
        {

            var result = new List<SpResult>();

            try
            {
                result = context.SpResult.FromSqlInterpolated($"PacienteManager {model.ID_Paciente}, {model.Cedula}, {model.Nombre_Paciente}, {model.Apellido_Paciente}, {model.Asegurado}, {2}").ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al actualizar alta medica" + ex);
            }

            return result.FirstOrDefault();
        }
    }
}
