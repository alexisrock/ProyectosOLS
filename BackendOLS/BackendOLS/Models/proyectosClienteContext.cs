using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackendOLS.Models
{
    public partial class proyectosClienteContext : DbContext
    {
        public proyectosClienteContext()
        {
        }

        public proyectosClienteContext(DbContextOptions<proyectosClienteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleProyecoLenguaje> DetalleProyecoLenguajes { get; set; }
        public virtual DbSet<EstadoProyecto> EstadoProyectos { get; set; }
        public virtual DbSet<LenguajesProgramacion> LenguajesProgramacions { get; set; }
        public virtual DbSet<Nivellenguaje> Nivellenguajes { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-G58E8B1\\ALEXISDESARROLLA;Initial Catalog=proyectosCliente;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(250)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Cedula).HasMaxLength(250);

                entity.Property(e => e.Direcion)
                    .HasMaxLength(250)
                    .HasColumnName("direcion");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(250)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(250)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<DetalleProyecoLenguaje>(entity =>
            {
                entity.ToTable("DetalleProyecoLenguaje");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idlenguaje).HasColumnName("idlenguaje");

                entity.Property(e => e.Idnivel).HasColumnName("idnivel");

                entity.Property(e => e.Idproyecto).HasColumnName("idproyecto");

                entity.HasOne(d => d.IdlenguajeNavigation)
                    .WithMany(p => p.DetalleProyecoLenguajes)
                    .HasForeignKey(d => d.Idlenguaje)
                    .HasConstraintName("FK__DetallePr__idlen__21B6055D");

                entity.HasOne(d => d.IdnivelNavigation)
                    .WithMany(p => p.DetalleProyecoLenguajes)
                    .HasForeignKey(d => d.Idnivel)
                    .HasConstraintName("FK__DetallePr__idniv__22AA2996");

                entity.HasOne(d => d.IdproyectoNavigation)
                    .WithMany(p => p.DetalleProyecoLenguajes)
                    .HasForeignKey(d => d.Idproyecto)
                    .HasConstraintName("FK__DetallePr__idpro__20C1E124");
            });

            modelBuilder.Entity<EstadoProyecto>(entity =>
            {
                entity.ToTable("EstadoProyecto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<LenguajesProgramacion>(entity =>
            {
                entity.ToTable("LenguajesProgramacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Nivellenguaje>(entity =>
            {
                entity.ToTable("Nivellenguaje");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("Proyecto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidadhoras)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cantidadhoras");

                entity.Property(e => e.Fechafin)
                    .HasColumnType("date")
                    .HasColumnName("fechafin");

                entity.Property(e => e.Fechainicio)
                    .HasColumnType("date")
                    .HasColumnName("fechainicio");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK__Proyecto__idclie__164452B1");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK__Proyecto__idesta__173876EA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
