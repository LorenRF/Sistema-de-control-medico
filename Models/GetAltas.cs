namespace Sistema_de_control_medico.Models
{
    public class GetAltas
    {
        public int? ID_Alta { get; set; }
        public bool? Estado { get; set; }
        public string? Estatus { get; set; }
        public DateTime? Ingresado { get; set; }
        public DateTime? Alta { get; set; }
        public string? Paciente { get; set; }
        public int? ID_Paciente { get; set; }
        public int? Habitacion { get; set; }
        public int? ID_Habitacion { get; set; }
        public Double? Pago { get; set; }
    }
}
