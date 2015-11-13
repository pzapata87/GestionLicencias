using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Licencias.Presentation.Models
{
    public class FormularioUnicoTramiteModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Ruc")]
        public string Ruc { get; set; }

        [Required]
        [DisplayName("Dni")]
        public string Dni { get; set; }

        [DisplayName("Carnet Extranjeria")]
        public string CarnetExtranjeria { get; set; }

        [Required]
        [DisplayName("Domicilio")]
        public string Domicilio { get; set; }

        [Required]
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; }

        [DisplayName("Telefax")]
        public string Telefax { get; set; }

        [Required]
        [DisplayName("Correo")]
        public string Correo { get; set; }

        [Required]
        [DisplayName("Ficha Literal")]
        public string FichaLiteral { get; set; }

        [Required]
        [DisplayName("Representante")]
        public string Representante { get; set; }
    }
}