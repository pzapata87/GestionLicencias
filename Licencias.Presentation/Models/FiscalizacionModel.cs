using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Licencias.Presentation.Core.Attributes;

namespace Licencias.Presentation.Models
{
    public class FiscalizacionModel
    {
        public int Id { get; set; }

        [Required]
        [DateValidation(ErrorMessage = "Fecha Inválida (dd/mm/yyyy)")]
        [DisplayName("Fecha Fiscalización")]
        public string FechaFiscalizacion { get; set; }

        public string FiscalizadorNombre { get; set; }

        [DisplayName("Local")]
        public string LocalDireccion { get; set; }

        [DisplayName("Detalle")]
        public string Detalle { get; set; }

        public int LicenciaId { get; set; }

        [DisplayName("Número de Licencia")]
        public string NumLicencia { get; set; }

        [Required]
        [DisplayName("Estado")]
        public string EstadoId { get; set; }

        public string EstadoNombre { get; set; }

        [DisplayName("Observación")]
        public string Observacion { get; set; }

        public string UriImagen { get; set; }

        public string GiroDescripcion { get; set; }

        public List<string> EvidenciaImagenes { get; set; }
        public List<FiscalizacionRequisitoModel> RequisitoList { get; set; }
    }
}