using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.DTO;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Controllers
{
    public class MedicoController : ControllerBase
    {
        IMedico DBMedico { set; get; }

        public MedicoController(IMedico DBMedico)
        {
            this.DBMedico = DBMedico;
        }


        [HttpGet("obtener-medicos")]
        public ActionResult getMedic(int? id)
        {
            var doc = DBMedico.getMedic(id);
            return Ok(doc);

        }


        [HttpPost("agregar-medico")]
        public ActionResult addMedic(MedicosManagerDTO model)
        {
            return Ok(DBMedico.setMedic( model));
        }
        [HttpPut("editar-medico")]
        public ActionResult editMedic(MedicosManagerDTO model)
        {
            return Ok(DBMedico.updateMedic(model));
        }

        [HttpDelete("eliminar-medico")]
        public ActionResult deleteMedic(MedicosManagerDTO model)
        {
            return Ok(DBMedico.DeleteMedic(model));
        }
    }
}


