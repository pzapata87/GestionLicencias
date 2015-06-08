using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Licencias.Presentation.Models
{
    public class FiscalizacionModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Fecha Fiscalización")]
        public string FechaFiscalizacion { get; set; }

        public string FiscalizadorNombre { get; set; }

        [Required]
        [DisplayName("Local")]
        public int LocalId { get; set; }

        public string LocalDireccion { get; set; }

        [DisplayName("Detalle")]
        public string Detalle { get; set; }

        public int LicenciaId { get; set; }

        [DisplayName("Número de Licencia")]
        public string NumLicencia { get; set; }

        public string EstadoNombre { get; set; }
    }
}