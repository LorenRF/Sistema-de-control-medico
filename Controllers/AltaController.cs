using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.Interfaces;

namespace Sistema_de_control_medico.Controllers
{
    public class AltaController : Controller
    {
        IAltas alta { set; get; }

        public AltaController(IAltas alta)
        {
            this.alta = alta;
        }

        [HttpGet("obtener-altas")]
        public ActionResult getDischargeList()
        {
            var doc = alta.getDischarge();
            return Ok(doc);
        }

        [HttpGet("obtener-alta")]
        public ActionResult getDischarge(int id)
        {
            var doc = alta.getDischarge(id);
            return Ok(doc);

        }


        [HttpPost("agregar-alta")]
        public ActionResult addDischarge(DateTime fechaHoraSalida, int ingreso)
        {
            return Ok(alta.setDischarge(fechaHoraSalida, ingreso));
        }
        [HttpPut("editar-alta")]
        public ActionResult editDischarge(int id, DateTime fechaHoraSalida, DateTime fechaHoraIngreso, int habitacion, int paciente, float pago)
        {
            return Ok(alta.updateDischarge(id, fechaHoraSalida, fechaHoraIngreso, habitacion, paciente, pago));
        }

        [HttpDelete("eliminar-alta")]
        public ActionResult deleteDischarge(int id)
        {
            return Ok(alta.DeleteDischarge(id));
        }
    }
}
