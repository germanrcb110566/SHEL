//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SHEL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mPersona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mPersona()
        {
            this.mAuditoria = new HashSet<mAuditoria>();
            this.mCita = new HashSet<mCita>();
            this.mCita1 = new HashSet<mCita>();
            this.rTipo_Persona = new HashSet<rTipo_Persona>();
            this.mCalendario = new HashSet<mCalendario>();
        }
    
        public int registro_id { get; set; }
        public int identificacion_tipo { get; set; }
        public string identificacion { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public string correo_electronico { get; set; }
        public int genero { get; set; }
        public int ciudad_residencia { get; set; }
        public int nacionalidad { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mAuditoria> mAuditoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mCita> mCita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mCita> mCita1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rTipo_Persona> rTipo_Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mCalendario> mCalendario { get; set; }
    }
}
