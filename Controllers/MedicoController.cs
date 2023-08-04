using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.Interfaces;

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
        public ActionResult getMedicList()
        {
            var doc = DBMedico.getMedics();
            return Ok(doc);
        }

        [HttpGet("obtener-medico")]
        public ActionResult getMedic(int id)
        {
            var doc = DBMedico.getMedic(id);
            return Ok(doc);

        }

      
        [HttpPost("agregar-medico")]
        public ActionResult addMedic(string nombre, string apellido, int Exequatur, string especialidad)
        {
            return Ok(DBMedico.setMedic( nombre, apellido, Exequatur, especialidad));
        }
        [HttpPut("editar-medico")]
        public ActionResult editMedic(int id, string nombre, string apellido, int Exequatur, string especialidad)
        {
            return Ok(DBMedico.updateMedic(id, nombre, apellido, Exequatur, especialidad));
        }

        [HttpDelete("eliminar-medico")]
        public ActionResult deleteMedic(int id)
        {
            return Ok(DBMedico.DeleteMedic(id));
        }
    }
}


