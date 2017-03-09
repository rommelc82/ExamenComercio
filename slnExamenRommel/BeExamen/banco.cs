namespace BeExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco")]
    public partial class banco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public banco()
        {
            sucursals = new HashSet<sucursal>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        public DateTime? fecharegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sucursal> sucursals { get; set; }
    }
}
