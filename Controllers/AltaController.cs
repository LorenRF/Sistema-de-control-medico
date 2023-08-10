using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

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
        public ActionResult getDischargeList(int? id)
        {
            var doc = alta.getDischarge(id);
            return Ok(doc);
        }


        [HttpPost("agregar-alta")]
        public ActionResult addDischarge(AltaManagerDTO model)
        {

            return Ok(alta.setDischarge(model));
        }
        [HttpPut("editar-alta")]
        public ActionResult editDischarge(AltaManagerDTO model)
        {
            return Ok(alta.updateDischarge(model));
        }

        [HttpDelete("eliminar-alta")]
        public ActionResult deleteDischarge(AltaManagerDTO model)
        {
            return Ok(alta.DeleteDischarge(model));
        }
    }
}
