using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.Interfaces;

namespace Sistema_de_control_medico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        IPaciente paciente { set; get; }

        public PacienteController (IPaciente paciente)
        {
            this.paciente = paciente;
        }



        [HttpGet("obtener-pacientes")]
        public ActionResult getPatients()
        {
            var pacientes = paciente.getPatients();
            return Ok(pacientes);
        }        
        
        [HttpGet("obtener-paciente")]
        public ActionResult getPatient(int id)
        {
            var elpaciente = paciente.getPatient(id);
            return Ok(paciente);
        }

        [HttpPost("agregar-paciente")]
        public ActionResult setPatient(string cedula, string nombre, string apellido, string asegurado)
        {
            return Ok(paciente.setPatient( cedula, nombre, apellido, asegurado));
        }
        [HttpPut("editar-paciente")]
        public ActionResult updatePatient(int id, string cedula, string nombre, string apellido, string asegurado)
        {
            return Ok(paciente.updatePatient( id, cedula, nombre, apellido, asegurado));
        }

        [HttpDelete("eliminar-paciente")]
        public ActionResult deleteUser(int id)
        {
            return Ok(paciente.DeletePatient(id));
        }
    }
}
