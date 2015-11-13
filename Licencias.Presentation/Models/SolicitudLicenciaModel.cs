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
        public int GiroId { get; set; }

        public string GiroNombre { get; set; }

        [Required]
        [DisplayName("Administrado")]
        public int AdministradoId { get; set; }

        public string AdministradoNombre { get; set; }

        [Required]
        [DisplayName("Solicitante")]
        public string Solicitante { get; set; }

        public FormularioUnicoTramiteModel Fut { get; set; }
        public SolicitudAnuncioModel SolicitudAnuncio { get; set; }

        public string Accion { get; set; }

        public List<KeyValuePair<int?, string>> GiroList { get; set; }
        public List<KeyValuePair<int?, string>> AdministradoList { get; set; }
        public List<DeclaracionJuradaModel> DeclaracionJuradaList { get; set; }
    }
}