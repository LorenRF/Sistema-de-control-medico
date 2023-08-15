using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Controllers
{
   
    public class PacienteController : ControllerBase
    {
        IPaciente paciente { set; get; }

        public PacienteController(IPaciente paciente)
        {
            this.paciente = paciente;
        }


        [HttpGet("obtener-pacientes")]
        public ActionResult getPatient(int? id)
        {
            var elpaciente = paciente.getPatient(id);
            return Ok(elpaciente);
        }

        [HttpPost("agregar-paciente")]
        public ActionResult setPatient(PacientesManagerDTO model)
        {
            return Ok(paciente.setPatient(model));
        }
        [HttpPut("editar-paciente")]
        public ActionResult updatePatient(PacientesManagerDTO model)
        {
            return Ok(paciente.updatePatient(model));
        }

        [HttpDelete("eliminar-paciente")]
        public ActionResult deleteUser(PacientesManagerDTO model)
        {
            return Ok(paciente.DeletePatient(model));
        }
    }
}
