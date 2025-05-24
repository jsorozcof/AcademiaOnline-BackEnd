using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcademiaOnline.Infrastructure.Academia
{
    public partial class AcademiaOnlineBDContext : DbContext
    {
        public AcademiaOnlineBDContext()
        {
        }

        public AcademiaOnlineBDContext(DbContextOptions<AcademiaOnlineBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbEstudiante> TbEstudiantes { get; set; } = null!;
        public virtual DbSet<TbEstudianteMaterium> TbEstudianteMateria { get; set; } = null!;
        public virtual DbSet<TbEstudiantePrograma> TbEstudianteProgramas { get; set; } = null!;
        public virtual DbSet<TbMateria> TbMaterias { get; set; } = null!;
        public virtual DbSet<TbProfesorMaterium> TbProfesorMateria { get; set; } = null!;
        public virtual DbSet<TbProfesore> TbProfesores { get; set; } = null!;
        public virtual DbSet<TbProgramasCredito> TbProgramasCreditos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //     #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AcademiaOnlineBD;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbEstudiante>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__TbEstudi__A9D10534A44683DF")
                    .IsUnique();

                entity.Property(e => e.Codigo).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.ProgramaCreditos).HasColumnName("Programa_Creditos");
            });

            modelBuilder.Entity<TbEstudianteMaterium>(entity =>
            {
                entity.ToTable("TbEstudiante_Materia");

                entity.HasIndex(e => new { e.EstudianteId, e.MateriaId }, "UQ_Estudiante_Materia")
                    .IsUnique();

                entity.Property(e => e.EstudianteId).HasColumnName("Estudiante_Id");

                entity.Property(e => e.MateriaId).HasColumnName("Materia_Id");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.TbEstudianteMateria)
                    .HasForeignKey(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstudianteMateria_Estudiante");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.TbEstudianteMateria)
                    .HasForeignKey(d => d.MateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstudianteMateria_Materia");
            });

            modelBuilder.Entity<TbEstudiantePrograma>(entity =>
            {
                entity.ToTable("TbEstudiante_Programa");

                entity.HasIndex(e => e.EstudianteId, "UQ_Estudiante")
                    .IsUnique();

                entity.Property(e => e.EstudianteId).HasColumnName("Estudiante_Id");

                entity.Property(e => e.ProgramaId).HasColumnName("Programa_Id");

                entity.HasOne(d => d.Estudiante)
                    .WithOne(p => p.TbEstudiantePrograma)
                    .HasForeignKey<TbEstudiantePrograma>(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante");

                entity.HasOne(d => d.Programa)
                    .WithMany(p => p.TbEstudianteProgramas)
                    .HasForeignKey(d => d.ProgramaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programa");
            });

            modelBuilder.Entity<TbMateria>(entity =>
            {
                entity.Property(e => e.Codigo).HasMaxLength(100);

                entity.Property(e => e.Creditos).HasDefaultValueSql("((3))");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<TbProfesorMaterium>(entity =>
            {
                entity.ToTable("TbProfesor_Materia");

                entity.HasIndex(e => new { e.ProfesorId, e.MateriaId }, "UQ_Profesor_Materia")
                    .IsUnique();

                entity.Property(e => e.MateriaId).HasColumnName("Materia_Id");

                entity.Property(e => e.ProfesorId).HasColumnName("Profesor_Id");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.TbProfesorMateria)
                    .HasForeignKey(d => d.MateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materia");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.TbProfesorMateria)
                    .HasForeignKey(d => d.ProfesorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profesor");
            });

            modelBuilder.Entity<TbProfesore>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<TbProgramasCredito>(entity =>
            {
                entity.ToTable("TbProgramas_Credito");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.TotalCreditos).HasColumnName("Total_Creditos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
