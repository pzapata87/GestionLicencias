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
    
    public partial class CronogramaFiscalizacion
    {
        public int Id { get; set; }
        public System.DateTime FechaFiscalizacion { get; set; }
        public string Fiscalizador { get; set; }
        public int UsuarioId { get; set; }
        public string Comentario { get; set; }
        public int LicenciaId { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Licencia Licencia { get; set; }
    }
}
