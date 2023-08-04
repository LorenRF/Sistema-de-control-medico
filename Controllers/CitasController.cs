using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("obtener-citas")]
        public ActionResult getAppointmentList()
        {
            var doc = cita.getAppointments();
            return Ok(doc);
        }

        [HttpGet("obtener-cita")]
        public ActionResult getAppointment(int id)
        {
            var doc = cita.getAppointment(id);
            return Ok(doc);

        }


        [HttpPost("agregar-cita")]
        public ActionResult addAppoiment(DateTime fechaHora, int medico, int paciente)
        {
            return Ok(cita.setAppointment( fechaHora,  medico,  paciente));
        }
        [HttpPut("editar-cita")]
        public ActionResult editAppointment(int id, DateTime fechaHora, int medico, int paciente)
        {
            return Ok(cita.updateAppointment(id, fechaHora, medico, paciente));
        }

        [HttpDelete("eliminar-cita")]
        public ActionResult deleteAppointment(int id)
        {
            return Ok(cita.DeleteAppointment(id));
        }
    }
}
