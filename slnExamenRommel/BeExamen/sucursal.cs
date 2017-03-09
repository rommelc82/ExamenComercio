namespace BeExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("sucursal")]
    [DataContract] 
    public partial class sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sucursal()
        {
            ordenpagoes = new HashSet<ordenpago>();
        }
        [DataMember] 
        public int id { get; set; }

        [DataMember] 
        public int? idbanco { get; set; }

        [StringLength(100)]
        [DataMember] 
        public string nombre { get; set; }

        [StringLength(100)]
        [DataMember] 
        public string direccion { get; set; }
        //[DataMember] 
        public DateTime? fecharegistro { get; set; }
        [DataMember] 
        public virtual banco banco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember] 
        public virtual ICollection<ordenpago> ordenpagoes { get; set; }
    }
}
