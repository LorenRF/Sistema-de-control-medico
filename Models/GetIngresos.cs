namespace Sistema_de_control_medico.Models
{
    public class GetIngresos
    {
        public int? ID_Ingreso { get; set; }
        public DateTime? Ingresado { get; set; }
        public bool? Estado { get; set; }
        public string? Estatus { get; set; }
        public int? ID_Habitacion { get; set; }
        public int? Numero { get; set; }
        public string? Tipo { get; set; }
        public string? paciente { get; set; }

        public int? ID_Paciente { get; set; }
    }
}
