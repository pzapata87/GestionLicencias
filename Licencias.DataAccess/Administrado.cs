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
    
    public partial class Administrado
    {
        public Administrado()
        {
            this.SolicitudLicencias = new HashSet<SolicitudLicencia>();
        }
    
        public int Id { get; set; }
        public string NDocumento { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
    
        public virtual ICollection<SolicitudLicencia> SolicitudLicencias { get; set; }
    }
}
