using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;

namespace Sistema_de_control_medico.Controllers
{
    public class IngresosController : ControllerBase
    {
        IIngreso ingreso { set; get; }

        public IngresosController(IIngreso iingreso)
        {
            ingreso = iingreso;
        }

        [HttpGet("obtener-ingreso")]
        public ActionResult getInternment(int? id)
        {
            var doc = ingreso.getInternment(id);
            return Ok(doc);

        }


        [HttpPost("agregar-ingreso")]
        public ActionResult addInternment(IngresosManagerDTO model)
        {
            return Ok(ingreso.setInternment(model));
        }
        [HttpPut("editar-ingreso")]
        public ActionResult editInternment(IngresosManagerDTO model)
        {
            return Ok(ingreso.updateInternment(model));
        }

        [HttpDelete("eliminar-ingreso")]
        public ActionResult deleteInternment(IngresosManagerDTO model)
        {
            return Ok(ingreso.DeleteInternment(model));
        }
    }
}
