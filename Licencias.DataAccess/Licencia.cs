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
    
    public partial class Licencia
    {
        public Licencia()
        {
            this.Fiscalizacions = new HashSet<Fiscalizacion>();
        }
    
        public int Id { get; set; }
        public int LocalId { get; set; }
        public string Responsable { get; set; }
        public string NumLicencia { get; set; }
        public System.DateTime FechaLicencia { get; set; }
        public string UriImagen { get; set; }
    
        public virtual Local Local { get; set; }
        public virtual ICollection<Fiscalizacion> Fiscalizacions { get; set; }
    }
}
