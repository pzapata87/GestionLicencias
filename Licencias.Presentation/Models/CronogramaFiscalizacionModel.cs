namespace Licencias.Presentation.Models
{
    public class CronogramaFiscalizacionModel
    {
        public int Id { get; set; }
        public string FechaFiscalizacion { get; set; }
        public string Fiscalizador { get; set; }
        public int UsuarioId { get; set; }
        public string Comentario { get; set; }
        public int LicenciaId { get; set; }
        public string NumLicencia { get; set; }
    }
}