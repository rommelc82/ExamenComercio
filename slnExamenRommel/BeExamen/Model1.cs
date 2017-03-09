namespace BeExamen
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<banco> bancoes { get; set; }
        public virtual DbSet<detalleparametro> detalleparametroes { get; set; }
        public virtual DbSet<ordenpago> ordenpagoes { get; set; }
        public virtual DbSet<parametro> parametroes { get; set; }
        public virtual DbSet<sucursal> sucursals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<banco>()
                .HasMany(e => e.sucursals)
                .WithOptional(e => e.banco)
                .HasForeignKey(e => e.idbanco);

            modelBuilder.Entity<detalleparametro>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<detalleparametro>()
                .Property(e => e.valor)
                .IsUnicode(false);

            modelBuilder.Entity<ordenpago>()
                .Property(e => e.monto)
                .HasPrecision(6, 2);

            modelBuilder.Entity<ordenpago>()
                .Property(e => e.moneda)
                .IsUnicode(false);

            modelBuilder.Entity<parametro>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<parametro>()
                .Property(e => e.valor)
                .IsUnicode(false);

            modelBuilder.Entity<parametro>()
                .HasMany(e => e.detalleparametroes)
                .WithOptional(e => e.parametro)
                .HasForeignKey(e => e.idparametro);

            modelBuilder.Entity<sucursal>()
                .HasMany(e => e.ordenpagoes)
                .WithOptional(e => e.sucursal)
                .HasForeignKey(e => e.idsucursal);
        }
    }
}
