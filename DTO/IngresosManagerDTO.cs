namespace Sistema_de_control_medico.DTO
{
    public class IngresosManagerDTO
    {
        public int? ID_Ingreso { get; set; }
        public DateTime? Fecha_de_ingreso { get; set; }
        public int? ID_Habitacion { get; set; }
        public int? ID_Paciente { get; set; }
    }
}
