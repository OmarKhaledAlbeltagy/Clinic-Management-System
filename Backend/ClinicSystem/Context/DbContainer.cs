using ClinicSystem.Entities;
using ClinicSystem.Privilage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Context
{
    public class DbContainer : IdentityDbContext<ExtendIdentityUser, IdentityRole, string>
    {
        public DbContainer(DbContextOptions<DbContainer> ops) : base(ops)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Followup>().HasOne(a => a.Examination).WithOne(a => a.followupE);
            builder.Entity<Followup>().HasOne(a => a.Followupp).WithOne(a => a.followupF);
            builder.Entity<PatientProfile>().HasIndex(b => b.PhoneNumber);
            
        }
        public DbSet<AppointmentsToCancel> appointmentsToCancel { get; set; }

        public DbSet<AppointmentType> appointmentType { get; set; }

        public DbSet<CheifComplaint> cheifComplaint { get; set; }

        public DbSet<DoctorProcessPrice> doctorProcessPrice { get; set; }

        public DbSet<MedicalDiagnosis> diagnosis { get; set; }

        public DbSet<Drugs> drug { get; set; }

        public DbSet<Followup> followup { get; set; }

        public DbSet<Gender> gender { get; set; }

        public DbSet<Insurance> insurance { get; set; }

        public DbSet<InsurancePackage> insurancePackage { get; set; }

        public DbSet<InsurancePackageOperation> insurancePackageOperation { get; set; }

        public DbSet<LaboratoryInvestigation> laboratoryInvestigation { get; set; }

        public DbSet<MedicalHistory> medicalHistory { get; set; }

        public DbSet<MedicineHistory> medicineHistory { get; set; }

        public DbSet<Operation> operation { get; set; }

        public DbSet<PatientProcess> patientProcess { get; set; }

        public DbSet<PatientProcessOperation> patientProcessOperation { get; set; }

        public DbSet<PatientProfile> patientProfile { get; set; }

        public DbSet<PatientProfileInsurancePackage> patientProfileInsurancePackage { get; set; }

        public DbSet<PreAppointment> preAppointment { get; set; }

        public DbSet<ProcessType> processType { get; set; }

        public DbSet<RadioGraphicExamination> radioGraphicExamination { get; set; }

        public DbSet<Setup> setup { get; set; }

        public DbSet<SurgeryHistory> surgeryHistory { get; set; }

        public DbSet<Vacation> vacation { get; set; }

        public DbSet<WorkingTime> workingTime { get; set; }

        public DbSet<WorkingTimeByDate> workingTimeByDate { get; set; }
    }
}
