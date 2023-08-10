using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;

namespace Sistema_de_control_medico.Controllers
{
    public class CitasController : ControllerBase
    {
        ICita cita { set; get; }

        public CitasController(ICita cita)
        {
            this.cita = cita;
        }

        [HttpGet("obtener-cita")]
        public ActionResult getAppointment(int? id)
        {
            var doc = cita.getAppointment(id);
            return Ok(doc);
        }

        [HttpPost("agregar-cita")]
        public ActionResult addAppoiment(CitaManagerDTO model)
        {
            return Ok(cita.setAppointment(model));
        }
        [HttpPut("editar-cita")]
        public ActionResult editAppointment(CitaManagerDTO model)
        {
            return Ok(cita.updateAppointment(model));
        }

        [HttpDelete("eliminar-cita")]
        public ActionResult deleteAppointment(CitaManagerDTO model)
        {
            return Ok(cita.DeleteAppointment(model));
        }
    }
}
