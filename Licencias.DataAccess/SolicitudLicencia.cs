//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Licencias.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class SolicitudLicencia
    {
        public SolicitudLicencia()
        {
            this.DeclaracionJuradas = new HashSet<DeclaracionJurada>();
        }
    
        public int Id { get; set; }
        public int GiroId { get; set; }
        public int AdministradoId { get; set; }
        public string Solicitante { get; set; }
    
        public virtual Giro Giro { get; set; }
        public virtual Administrado Administrado { get; set; }
        public virtual ICollection<DeclaracionJurada> DeclaracionJuradas { get; set; }
        public virtual FormularioUnicoTramite FormularioUnicoTramite { get; set; }
    }
}