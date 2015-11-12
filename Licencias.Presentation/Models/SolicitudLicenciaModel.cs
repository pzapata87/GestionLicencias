using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Licencias.Presentation.Models
{
    public class SolicitudLicenciaModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Giro")]
        public string GiroId { get; set; }

        public string GiroNombre { get; set; }

        [Required]
        [DisplayName("Administrado")]
        public string AdministradoId { get; set; }

        public string AdministradoNombre { get; set; }

        [DisplayName("Solicitante")]
        public string Solicitante { get; set; }

        public string Accion { get; set; }

        public List<GiroModel> GiroList { get; set; }
        public List<AdministradoModel> AdministradoList { get; set; }
    }
}