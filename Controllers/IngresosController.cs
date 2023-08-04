using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.Interfaces;

namespace Sistema_de_control_medico.Controllers
{
    public class IngresosController : ControllerBase
    {
        IIngreso ingreso { set; get; }

        public IngresosController(IIngreso ingreso)
        {
            this.ingreso = ingreso;
        }

        [HttpGet("obtener-ingresos")]
        public ActionResult getInternmentList()
        {
            var doc = ingreso.getInternments();
            return Ok(doc);
        }

        [HttpGet("obtener-ingreso")]
        public ActionResult getInternment(int id)
        {
            var doc = ingreso.getInternment(id);
            return Ok(doc);

        }


        [HttpPost("agregar-ingreso")]
        public ActionResult addInternment(DateTime fechaHoraIngreso, int habitacion, int paciente)
        {
            return Ok(ingreso.setInternment(fechaHoraIngreso, habitacion, paciente));
        }
        [HttpPut("editar-ingreso")]
        public ActionResult editInternment(int id, DateTime fechaHoraIngreso, int habitacion, int paciente)
        {
            return Ok(ingreso.updateInternment(id, fechaHoraIngreso, habitacion, paciente));
        }

        [HttpDelete("eliminar-ingreso")]
        public ActionResult deleteInternment(int id)
        {
            return Ok(ingreso.DeleteInternment(id));
        }
    }
}
