//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoParqueoUSAM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class LUGAR_PARQUEO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LUGAR_PARQUEO()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
            this.TICKET = new HashSet<TICKET>();
        }

        public int ID_PARQUEO { get; set; }
        [DisplayName("Ubicacion")]
        public string NOMBRE_PARQUEO { get; set; }
        [DisplayName("Descripcion")]
        public string DESCRIPCION_D_PARQUEO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKET { get; set; }
    }
}
