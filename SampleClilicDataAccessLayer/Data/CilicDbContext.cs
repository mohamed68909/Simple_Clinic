using System;
using Microsoft.EntityFrameworkCore;
using SampleClilicDataAccessLayer.Models;

namespace SampleClilicDataAccessLayer.Data
{
    public partial class CilicDbContext : DbContext
    {
        public CilicDbContext() { }

        public CilicDbContext(DbContextOptions<CilicDbContext> options)
            : base(options) { }

        public  DbSet<Appointment> Appointments { get; set; }
        public  DbSet<Doctor> Doctors { get; set; }
        public  DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public  DbSet<Payment> Payments { get; set; }
        public  DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SimpleClinic;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Patients
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);
                entity.Property(e => e.PatientId).HasColumnName("PatientID");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(1);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(200);
            });

            // Doctors
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Specialization).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(1);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(200);
            });

            // Appointments
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);
                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
                entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");
                entity.Property(e => e.AppointmentStatus).HasMaxLength(50);
                entity.Property(e => e.PatientId).HasColumnName("PatientID");
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
                entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Appointments)
                      .HasForeignKey(d => d.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Doctor)
                      .WithMany(p => p.Appointments)
                      .HasForeignKey(d => d.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.MedicalRecord)
                      .WithOne(p => p.Appointment)
                      .HasForeignKey<Appointment>(d => d.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Payment)
                      .WithOne(p => p.Appointment)
                      .HasForeignKey<Appointment>(d => d.PaymentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Medical Records
            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.HasKey(e => e.MedicalRecordId);
                entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
                entity.Property(e => e.VisitDescription).HasMaxLength(200);
                entity.Property(e => e.Diagnosis).HasMaxLength(200);
                entity.Property(e => e.PrescribedMedication).HasMaxLength(200);
                entity.Property(e => e.AdditionalNotes).HasMaxLength(200);
                entity.Property(e => e.PatientId).HasColumnName("PatientID");
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.MedicalRecords)
                      .HasForeignKey(d => d.PatientId);

                entity.HasOne(d => d.Doctor)
                      .WithMany(p => p.MedicalRecords)
                      .HasForeignKey(d => d.DoctorId);
            });

            // Payments
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
                entity.Property(e => e.PaymentMethod).HasMaxLength(50);
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
                entity.Property(e => e.AmountPaid).HasColumnType("decimal(10,2)");
                entity.Property(e => e.AdditionalNotes).HasMaxLength(200);
                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Payments)
                      .HasForeignKey(d => d.PatientId);
            });

            // Prescriptions
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId);
                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");
                entity.Property(e => e.MedicationName).HasMaxLength(100);
                entity.Property(e => e.Dosage).HasMaxLength(50);
                entity.Property(e => e.Frequency).HasMaxLength(50);
                entity.Property(e => e.SpecialInstructions).HasMaxLength(200);
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");

                entity.HasOne(d => d.MedicalRecord)
                      .WithOne(p => p.Prescription)
                      .HasForeignKey<Prescription>(d => d.MedicalRecordId);
            });

            


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
