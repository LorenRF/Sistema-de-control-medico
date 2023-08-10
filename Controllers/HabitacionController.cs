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

        [HttpGet("obtener-habitacion")]
        public ActionResult getRooms(int? id)
        {
            var doc = habitacion.getRoom(id);
            return Ok(doc);
        }


    }
}
