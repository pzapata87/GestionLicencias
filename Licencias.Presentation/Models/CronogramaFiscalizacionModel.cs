using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Licencias.Presentation.Core.Attributes;

namespace Licencias.Presentation.Models
{
    public class CronogramaFiscalizacionModel
    {
        public int Id { get; set; }

        [Required]
        [DateValidation(ErrorMessage = "Fecha Inválida (dd/mm/yyyy)")]
        [DisplayName("Fecha Fiscalización")]
        public string FechaFiscalizacion { get; set; }

        public string FiscalizadorNombre { get; set; }

        [Required]
        [DisplayName("Fiscalizador")]
        public int FiscalizadorId { get; set; }

        [Required]
        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Comentario")]
        public string Comentario { get; set; }

        public int LicenciaId { get; set; }

        [DisplayName("Número de Licencia")]
        public string NumLicencia { get; set; }

        public string Accion { get; set; }
    }
}