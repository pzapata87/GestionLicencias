using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Licencias.Presentation.Models
{
    public class SolicitudAnuncioModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Gráfico")]
        public string Grafico { get; set; }

        [Required]
        [DisplayName("Leyenda")]
        public string Leyenda { get; set; }

        [Required]
        [DisplayName("Color")]
        public string Color { get; set; }

        [Required]
        [DisplayName("Largo")]
        public decimal Largo { get; set; }

        [Required]
        [DisplayName("Alto")]
        public decimal Alto { get; set; }

        [Required]
        [DisplayName("Ancho")]
        public decimal Ancho { get; set; }
    }
}