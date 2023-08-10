namespace Sistema_de_control_medico.Models
{
    public class GetCitas
    {
        public int ID_Cita { get; set; }
        public DateTime Fecha_Cita { get; set; }
        public bool Estado { get; set; }
        public string Estatus { get; set; }
        public string? medico { get; set; }
        public int ID_Medico { get; set; }
        public string paciente { get; set; }
        public int ID_Paciente { get; set; }
    }
}
