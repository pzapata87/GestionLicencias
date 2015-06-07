using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Licencias.Presentation.Models
{
    public class CronogramaFiscalizacionModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Fecha Fiscalización")]
        public string FechaFiscalizacion { get; set; }

        public string FiscalizadorNombre { get; set; }

        [Required]
        [DisplayName("Fiscalizador")]
        public int FiscalizadorId { get; set; }

        [Required]
        [DisplayName("Local")]
        public int LocalId { get; set; }

        public string LocalNombre { get; set; }

        public int UsuarioId { get; set; }

        [DisplayName("Comentario")]
        public string Comentario { get; set; }

        public int LicenciaId { get; set; }

        [DisplayName("Número de Licencia")]
        public string NumLicencia { get; set; }

        public string Accion { get; set; }
    }
}