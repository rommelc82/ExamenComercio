namespace BeExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detalleparametro")]
    public partial class detalleparametro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? idparametro { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        [StringLength(10)]
        public string valor { get; set; }

        public virtual parametro parametro { get; set; }
    }
}
