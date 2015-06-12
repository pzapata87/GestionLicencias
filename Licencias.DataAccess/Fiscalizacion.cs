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
    
    public partial class Fiscalizacion
    {
        public int Id { get; set; }
        public System.DateTime FechaProgramada { get; set; }
        public string Comentario { get; set; }
        public int FiscalizadorId { get; set; }
        public int LicenciaId { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public string Detalle { get; set; }
        public Nullable<System.DateTime> FechaReal { get; set; }
        public string Imagenes { get; set; }
    
        public virtual Fiscalizador Fiscalizador { get; set; }
        public virtual Licencia Licencia { get; set; }
    }
}
