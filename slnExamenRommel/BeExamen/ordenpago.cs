namespace BeExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordenpago")]
    public partial class ordenpago
    {
        public int id { get; set; }

        public int? idsucursal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? monto { get; set; }

        [StringLength(5)]
        public string moneda { get; set; }

        public int? estado { get; set; }

        public string des_estado { get; set; }

        public virtual sucursal sucursal { get; set; }
    }
}
