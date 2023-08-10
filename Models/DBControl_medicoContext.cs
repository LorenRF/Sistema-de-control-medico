//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace Sistema_de_control_medico.Models
//{
//    public partial class DBControl_medicoContext : DbContext
//    {
//        public DBControl_medicoContext()
//        {
//        }

//        public DBControl_medicoContext(DbContextOptions<DBControl_medicoContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Alta> Altas { get; set; } = null!;
//        public virtual DbSet<Cita> Citas { get; set; } = null!;
//        public virtual DbSet<Habitacion> Habitaciones { get; set; } = null!;
//        public virtual DbSet<Ingreso> Ingresos { get; set; } = null!;
//        public virtual DbSet<Medico> Medicos { get; set; } = null!;
//        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("Name=ConnectionStrings:AppConnection");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Alta>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("ID");

//                entity.Property(e => e.FechaDeSalida)
//                    .HasColumnType("datetime")
//                    .HasColumnName("Fecha_de_salida");

//                entity.Property(e => e.IdIngreso).HasColumnName("ID_ingreso");

//                entity.HasOne(d => d.IdIngresoNavigation)
//                    .WithMany(p => p.Alta)
//                    .HasForeignKey(d => d.IdIngreso)
//                    .HasConstraintName("FK__Altas__Pago__5EBF139D");
//            });

//            modelBuilder.Entity<Cita>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("ID");

//                entity.Property(e => e.Fecha).HasColumnType("datetime");

//                entity.Property(e => e.IdMedico).HasColumnName("ID_Medico");

//                entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

//                entity.HasOne(d => d.IdMedicoNavigation)
//                    .WithMany(p => p.Cita)
//                    .HasForeignKey(d => d.IdMedico)
//                    .HasConstraintName("FK__Citas__ID_Pacien__3F466844");

//                entity.HasOne(d => d.IdPacienteNavigation)
//                    .WithMany(p => p.Cita)
//                    .HasForeignKey(d => d.IdPaciente)
//                    .HasConstraintName("FK__Citas__ID_Pacien__403A8C7D");
//            });

//            modelBuilder.Entity<Habitacion>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("ID");

//                entity.Property(e => e.Tipo)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Ingreso>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("ID");

//                entity.Property(e => e.FechaDeIngreso)
//                    .HasColumnType("datetime")
//                    .HasColumnName("Fecha_de_ingreso");

//                entity.Property(e => e.IdHabitacion).HasColumnName("ID_Habitacion");

//                entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

//                entity.HasOne(d => d.IdHabitacionNavigation)
//                    .WithMany(p => p.Ingresos)
//                    .HasForeignKey(d => d.IdHabitacion)
//                    .HasConstraintName("FK__Ingresos__ID_Pac__4316F928");

//                entity.HasOne(d => d.IdPacienteNavigation)
//                    .WithMany(p => p.Ingresos)
//                    .HasForeignKey(d => d.IdPaciente)
//                    .HasConstraintName("FK__Ingresos__ID_Pac__440B1D61");
//            });

//            modelBuilder.Entity<Medico>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("ID");

//                entity.Property(e => e.Apellido)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);

//                entity.Property(e => e.Especialidad)
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Paciente>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("ID");

//                entity.Property(e => e.Apellido)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);

//                entity.Property(e => e.Asegurado)
//                    .HasMaxLength(1)
//                    .IsUnicode(false)
//                    .IsFixedLength();

//                entity.Property(e => e.Cedula)
//                    .HasMaxLength(13)
//                    .IsUnicode(false);

//                entity.Property(e => e.Nombre)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
