using Microsoft.AspNetCore.Mvc;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;

namespace Sistema_de_control_medico.Controllers
{
    public class HabitacionController : ControllerBase
    {

        IHabitacion habitacion { set; get; }

        public HabitacionController(IHabitacion habitacion)
        {
            this.habitacion = habitacion;
        }

        [HttpGet("obtener-habitacions")]
        public ActionResult getRooms()
        {
            var doc = habitacion.getRooms();
            return Ok(doc);
        }

        [HttpGet("obtener-habitacion")]
        public ActionResult getRoom(int id)
        {
            var doc = habitacion.getRoom(id);
            return Ok(doc);

        }


    }
}
