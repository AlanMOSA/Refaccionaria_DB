//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Refaccionaria_DB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuimicosSucursal
    {
        public int idQuimicosSucursal { get; set; }
        public int idQuimicos { get; set; }
        public int idSucursal { get; set; }
        public bool estatus { get; set; }
        public Nullable<int> idUsuarioCrea { get; set; }
        public Nullable<System.DateTime> fechaCrea { get; set; }
        public Nullable<int> idUsuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    
        public virtual Quimicos Quimicos { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
