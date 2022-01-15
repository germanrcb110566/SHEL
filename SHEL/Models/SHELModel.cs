using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SHEL.Models
{
    public partial class SHELModel : DbContext
    {
        public SHELModel()
            : base("name=SHELModel")
        {
        }

        public virtual DbSet<mAtencion> mAtencion { get; set; }
        public virtual DbSet<mAuditoria> mAuditoria { get; set; }
        public virtual DbSet<mCalendario> mCalendario { get; set; }
        public virtual DbSet<mCatalogo> mCatalogo { get; set; }
        public virtual DbSet<mCita> mCita { get; set; }
        public virtual DbSet<mParametros> mParametros { get; set; }
        public virtual DbSet<mPermisos> mPermisos { get; set; }
        public virtual DbSet<mPersona> mPersona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mAtencion>()
                .Property(e => e.diagnostico)
                .IsUnicode(false);

            modelBuilder.Entity<mAtencion>()
                .Property(e => e.examenes)
                .IsUnicode(false);

            modelBuilder.Entity<mAtencion>()
                .Property(e => e.receta)
                .IsUnicode(false);

            modelBuilder.Entity<mCalendario>()
                .HasMany(e => e.mPersona)
                .WithMany(e => e.mCalendario)
                .Map(m => m.ToTable("rMedico_Calendario").MapLeftKey("calendario_id").MapRightKey("medico_id"));

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mCita)
                .WithRequired(e => e.mCatalogo)
                .HasForeignKey(e => e.especialidad_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPersona)
                .WithRequired(e => e.mCatalogo)
                .HasForeignKey(e => e.ciudad_residencia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPersona1)
                .WithRequired(e => e.mCatalogo1)
                .HasForeignKey(e => e.genero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPermisos)
                .WithRequired(e => e.mCatalogo)
                .HasForeignKey(e => e.modulo_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPersona2)
                .WithRequired(e => e.mCatalogo2)
                .HasForeignKey(e => e.nacionalidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPermisos1)
                .WithRequired(e => e.mCatalogo1)
                .HasForeignKey(e => e.accion_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPermisos2)
                .WithRequired(e => e.mCatalogo2)
                .HasForeignKey(e => e.rol_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPersona3)
                .WithRequired(e => e.mCatalogo3)
                .HasForeignKey(e => e.identificacion_tipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mCatalogo>()
                .HasMany(e => e.mPersona4)
                .WithMany(e => e.mCatalogo4)
                .Map(m => m.ToTable("rTipo_Persona").MapLeftKey("tipopersona_id").MapRightKey("persona_id"));

            modelBuilder.Entity<mCita>()
                .HasOptional(e => e.mAtencion)
                .WithRequired(e => e.mCita);

            modelBuilder.Entity<mPersona>()
                .HasMany(e => e.mAuditoria)
                .WithRequired(e => e.mPersona)
                .HasForeignKey(e => e.usuario_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mPersona>()
                .HasMany(e => e.mCita)
                .WithRequired(e => e.mPersona)
                .HasForeignKey(e => e.paciente_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mPersona>()
                .HasMany(e => e.mCita1)
                .WithRequired(e => e.mPersona1)
                .HasForeignKey(e => e.medico_id)
                .WillCascadeOnDelete(false);
        }
    }
}
