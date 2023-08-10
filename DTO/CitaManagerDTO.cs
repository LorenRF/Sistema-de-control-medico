namespace Sistema_de_control_medico.DTO
{
    public class CitaManagerDTO
    {
        public int? ID_Cita { get; set; }
        public DateTime? Fecha_Cita { get; set; }
        public int? ID_Medico { get; set; }
        public int? ID_Paciente { get; set; }
    }
}
