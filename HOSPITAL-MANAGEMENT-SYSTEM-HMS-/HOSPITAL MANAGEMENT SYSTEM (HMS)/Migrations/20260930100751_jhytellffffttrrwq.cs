using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Migrations
{
    /// <inheritdoc />
    public partial class jhytellffffttrrwq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BirthOfDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                    table.CheckConstraint("CK_Appointment_DateInPaste", "[BirthOfDate] < GETUTCDATE()");
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctors_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Scheduled"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointments_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalRecords_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", "Cardiology" },
                    { 2, "Giza", "Pediatrics" },
                    { 3, "Cairo", "Orthopedics" },
                    { 4, "Giza", "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "Address", "BirthOfDate", "FullName", "Gender", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Nasr City, Cairo", new DateTime(1995, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar Ali", "Male", "01120000001" },
                    { 2, "Dokki, Giza", new DateTime(1998, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara Ahmed", "Female", "01120000002" },
                    { 3, "Heliopolis, Cairo", new DateTime(1987, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahmoud Samir", "Male", "01120000003" },
                    { 4, "Giza", new DateTime(2002, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariam Adel", "Female", "01120000004" },
                    { 5, "Maadi, Cairo", new DateTime(1979, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yassin Mohamed", "Male", "01120000005" },
                    { 6, "October, Giza", new DateTime(1991, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hana Khaled", "Female", "01120000006" },
                    { 7, "Giza", new DateTime(2014, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam Tarek", "Male", "01120000007" },
                    { 8, "Nasr City, Cairo", new DateTime(2012, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lina Hassan", "Female", "01120000008" },
                    { 9, "Shoubra, Cairo", new DateTime(1983, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mostafa Nabil", "Male", "01120000009" },
                    { 10, "Mohandessin, Giza", new DateTime(2000, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aya Emad", "Female", "01120000010" }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "Id", "DepartmentId", "Email", "FullName", "Phone", "Salary", "Specialization" },
                values: new object[,]
                {
                    { 1, 1, "ahmed.hassan@hms.com", "Ahmed Hassan", "01010000001", 45000m, "Cardiologist" },
                    { 2, 1, "mona.adel@hms.com", "Mona Adel", "01010000002", 42000m, "Cardiologist" },
                    { 3, 2, "omar.khaled@hms.com", "Omar Khaled", "01010000003", 38000m, "Pediatrician" },
                    { 4, 2, "nour.samir@hms.com", "Nour Samir", "01010000004", 36000m, "Pediatrician" },
                    { 5, 3, "karim.tarek@hms.com", "Karim Tarek", "01010000005", 50000m, "Orthopedic Surgeon" },
                    { 6, 3, "salma.youssef@hms.com", "Salma Youssef", "01010000006", 41000m, "Orthopedic Specialist" },
                    { 7, 4, "youssef.emad@hms.com", "Youssef Emad", "01010000007", 39000m, "Dermatologist" },
                    { 8, 4, "laila.mostafa@hms.com", "Laila Mostafa", "01010000008", 37000m, "Dermatologist" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "AppointmentDate", "DoctorId", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Scheduled" },
                    { 2, new DateTime(2026, 9, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, "Scheduled" },
                    { 3, new DateTime(2026, 9, 29, 11, 30, 0, 0, DateTimeKind.Unspecified), 5, 3, "Completed" },
                    { 4, new DateTime(2026, 9, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, "Cancelled" },
                    { 5, new DateTime(2026, 9, 28, 9, 30, 0, 0, DateTimeKind.Unspecified), 2, 5, "Completed" },
                    { 6, new DateTime(2026, 9, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 8, "Completed" },
                    { 7, new DateTime(2026, 9, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), 6, 9, "Completed" },
                    { 8, new DateTime(2026, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 8, 10, "Scheduled" },
                    { 9, new DateTime(2026, 10, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Scheduled" },
                    { 10, new DateTime(2026, 10, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, "Scheduled" },
                    { 11, new DateTime(2026, 9, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "Completed" },
                    { 12, new DateTime(2026, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "medicalRecords",
                columns: new[] { "Id", "AppointmentId", "Diagnosis", "Notes", "Prescription" },
                values: new object[,]
                {
                    { 1, 3, "Hypertension", "Follow-up after two weeks.", "Amlodipine 5mg once daily" },
                    { 2, 5, "Acute respiratory infection", "Patient advised to return if symptoms worsen.", "Rest and fluids" },
                    { 3, 7, "Knee ligament injury", "MRI recommended.", "Physiotherapy and rest" },
                    { 4, 11, "Mild eczema", "Avoid known skin irritants.", "Topical moisturizer twice daily" },
                    { 5, 12, "Migraine", "Maintain regular sleep schedule.", "Paracetamol as needed" },
                    { 6, 6, "Seasonal allergy", "Review if symptoms persist.", "Antihistamine once daily" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_DepartmentId",
                table: "doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_Email",
                table: "doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_AppointmentId",
                table: "medicalRecords",
                column: "AppointmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicalRecords");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
