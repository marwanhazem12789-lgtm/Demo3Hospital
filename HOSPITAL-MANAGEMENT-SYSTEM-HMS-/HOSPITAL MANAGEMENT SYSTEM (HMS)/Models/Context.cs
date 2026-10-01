using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> o) : base(o) { }


        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<MedicalRecord> medicalRecords { get; set; }
        public DbSet<Department> departments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasIndex(i => i.Email).IsUnique();
            modelBuilder.Entity<Doctor>().Property(j => j.Salary).HasPrecision(10, 2);

            modelBuilder.Entity<Doctor>().HasMany(u => u.appointments).WithOne(u => u.Doctor).HasForeignKey(u => u.DoctorId).OnDelete(DeleteBehavior.Cascade); 
            modelBuilder.Entity<Patient>().HasMany(u => u.appointments).WithOne(u => u.Patient).HasForeignKey(u => u.PatientId).OnDelete(DeleteBehavior.Cascade); 
            modelBuilder.Entity<Department>().HasMany(u => u.Doctors).WithOne(u => u.Department).HasForeignKey(u => u.DepartmentId).OnDelete(DeleteBehavior.Cascade); 
            modelBuilder.Entity<Doctor>().HasMany(u => u.appointments).WithOne(u => u.Doctor).HasForeignKey(u => u.DoctorId).OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Appointment>()
                .HasOne(i => i.MedicalRecord)
                .WithOne(i => i.Appointment)
                .HasForeignKey<MedicalRecord>(m => m.AppointmentId).OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>().Property(br => br.Status)
                     .IsRequired()
                     .HasDefaultValue("Scheduled");

     

            modelBuilder.Entity<Patient>().ToTable(t => t.HasCheckConstraint("CK_Appointment_DateInPaste", "[BirthOfDate] < GETUTCDATE()"));


            modelBuilder.Entity<Department>().HasData(
             new Department { Id = 1, Name = "Cardiology", Location = "Cairo" },
             new Department { Id = 2, Name = "Pediatrics", Location = "Giza" },
             new Department { Id = 3, Name = "Orthopedics", Location = "Cairo" },
             new Department { Id = 4, Name = "Dermatology", Location = "Giza" }
         );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Ahmed Hassan", Specialization = "Cardiologist", Email = "ahmed.hassan@hms.com", Phone = "01010000001", Salary = 45000, DepartmentId = 1 },
                new Doctor { Id = 2, FullName = "Mona Adel", Specialization = "Cardiologist", Email = "mona.adel@hms.com", Phone = "01010000002", Salary = 42000, DepartmentId = 1 },
                new Doctor { Id = 3, FullName = "Omar Khaled", Specialization = "Pediatrician", Email = "omar.khaled@hms.com", Phone = "01010000003", Salary = 38000, DepartmentId = 2 },
                new Doctor { Id = 4, FullName = "Nour Samir", Specialization = "Pediatrician", Email = "nour.samir@hms.com", Phone = "01010000004", Salary = 36000,     DepartmentId = 2 },
                new Doctor { Id = 5, FullName = "Karim Tarek", Specialization = "Orthopedic Surgeon", Email = "karim.tarek@hms.com", Phone = "01010000005", Salary = 50000, DepartmentId = 3 },
                new Doctor { Id = 6, FullName = "Salma Youssef", Specialization = "Orthopedic Specialist", Email = "salma.youssef@hms.com", Phone = "01010000006", Salary = 41000, DepartmentId = 3 },
                new Doctor { Id = 7, FullName = "Youssef Emad", Specialization = "Dermatologist", Email = "youssef.emad@hms.com", Phone = "01010000007", Salary = 39000, DepartmentId = 4 },
                new Doctor { Id = 8, FullName = "Laila Mostafa", Specialization = "Dermatologist", Email = "laila.mostafa@hms.com", Phone = "01010000008", Salary = 37000, DepartmentId = 4 }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Omar Ali", Gender = "Male", BirthOfDate = new DateTime(1995, 3, 12), PhoneNumber = "01120000001", Address = "Nasr City, Cairo" },
                new Patient { Id = 2, FullName = "Sara Ahmed", Gender = "Female", BirthOfDate = new DateTime(1998, 7, 24), PhoneNumber = "01120000002", Address = "Dokki, Giza" },
                new Patient { Id = 3, FullName = "Mahmoud Samir", Gender = "Male", BirthOfDate = new DateTime(1987, 11, 5), PhoneNumber = "01120000003", Address = "Heliopolis, Cairo" },
                new Patient { Id = 4, FullName = "Mariam Adel", Gender = "Female", BirthOfDate = new DateTime(2002, 1, 19), PhoneNumber = "01120000004", Address = "Giza" },
                new Patient { Id = 5, FullName = "Yassin Mohamed", Gender = "Male", BirthOfDate = new DateTime(1979, 9, 30), PhoneNumber = "01120000005", Address = "Maadi, Cairo" },
                new Patient { Id = 6, FullName = "Hana Khaled", Gender = "Female", BirthOfDate = new DateTime(1991, 5, 14), PhoneNumber = "01120000006", Address = "October, Giza" },
                new Patient { Id = 7, FullName = "Adam Tarek", Gender = "Male", BirthOfDate = new DateTime(2014, 2, 10), PhoneNumber = "01120000007", Address = "Giza" },
                new Patient { Id = 8, FullName = "Lina Hassan", Gender = "Female",  BirthOfDate = new DateTime(2012, 8, 21), PhoneNumber = "01120000008", Address = "Nasr City, Cairo" },
                new Patient { Id = 9, FullName = "Mostafa Nabil", Gender = "Male", BirthOfDate = new DateTime(1983, 12, 2), PhoneNumber = "01120000009", Address = "Shoubra, Cairo" },
                new Patient { Id = 10, FullName = "Aya Emad", Gender = "Female", BirthOfDate = new DateTime(2000, 6, 17), PhoneNumber = "01120000010", Address = "Mohandessin, Giza" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, AppointmentDate = new DateTime(2026, 9, 29, 9, 0, 0), Status = "Scheduled", DoctorId = 1, PatientId = 1 },
                new Appointment { Id = 2, AppointmentDate = new DateTime(2026, 9, 29, 10, 0, 0), Status = "Scheduled", DoctorId = 3, PatientId = 7 },
                new Appointment { Id = 3, AppointmentDate = new DateTime(2026, 9, 29, 11, 30, 0), Status = "Completed", DoctorId = 5, PatientId = 3 },
                new Appointment { Id = 4, AppointmentDate = new DateTime(2026, 9, 29, 13, 0, 0), Status = "Cancelled", DoctorId = 7, PatientId = 4 },
                new Appointment { Id = 5, AppointmentDate = new DateTime(2026, 9, 28, 9, 30, 0), Status = "Completed", DoctorId = 2, PatientId = 5 },
                new Appointment { Id = 6, AppointmentDate = new DateTime(2026, 9, 28, 12, 0, 0), Status = "Completed", DoctorId = 4, PatientId = 8 },
                new Appointment { Id = 7, AppointmentDate = new DateTime(2026, 9, 27, 14, 0, 0), Status = "Completed", DoctorId = 6, PatientId = 9 },
                new Appointment { Id = 8, AppointmentDate = new DateTime(2026, 10, 1, 10, 0, 0), Status = "Scheduled", DoctorId = 8, PatientId = 10 },
                new Appointment { Id = 9, AppointmentDate = new DateTime(2026, 10, 2, 11, 0, 0), Status = "Scheduled", DoctorId = 1, PatientId = 2 },
                new Appointment { Id = 10, AppointmentDate = new DateTime(2026, 10, 3, 9, 0, 0), Status = "Scheduled", DoctorId = 3, PatientId = 6 },
                new Appointment { Id = 11, AppointmentDate = new DateTime(2026, 9, 26, 15, 0, 0), Status = "Completed", DoctorId = 5, PatientId = 5 },
                new Appointment { Id = 12, AppointmentDate = new DateTime(2026, 9, 25, 16, 0, 0), Status = "Completed", DoctorId = 7, PatientId = 1 }
            );

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { Id = 1, Diagnosis = "Hypertension", Prescription = "Amlodipine 5mg once daily", Notes = "Follow-up after two weeks.", AppointmentId = 3 },
                new MedicalRecord { Id = 2, Diagnosis = "Acute respiratory infection", Prescription = "Rest and fluids", Notes = "Patient advised to return if symptoms worsen.", AppointmentId = 5 },
                new MedicalRecord { Id = 3, Diagnosis = "Knee ligament injury", Prescription = "Physiotherapy and rest", Notes = "MRI recommended.", AppointmentId = 7 },
                new MedicalRecord { Id = 4, Diagnosis = "Mild eczema", Prescription = "Topical moisturizer twice daily", Notes = "Avoid known skin irritants.", AppointmentId = 11 },
                new MedicalRecord { Id = 5, Diagnosis = "Migraine", Prescription = "Paracetamol as needed", Notes = "Maintain regular sleep schedule.", AppointmentId = 12 },
                new MedicalRecord { Id = 6, Diagnosis = "Seasonal allergy", Prescription = "Antihistamine once daily", Notes = "Review if symptoms persist.", AppointmentId = 6 }
            );


        }


    }
}
