namespace Sistema_de_control_medico.DTO
{
    public class PacientesManagerDTO
    {
        public int? ID_Paciente { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre_Paciente { get; set; }
        public string? Apellido_Paciente { get; set; }
        public bool? Asegurado { get; set; }
    }
}
