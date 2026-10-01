using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.AppointmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DepartmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DoctorCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.MedicalRecordCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.PatientCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IGenaricRepo<>), typeof(GenaricRepo<>));

builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IDoctorCustom, DoctorRepo>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IMedicalRecord, MedicalRecordRepo>();
builder.Services.AddScoped<IPatientRepo, PatientRepo>();


builder.Services.AddScoped<IunitOfWork, UnitOfWork>();


builder.Services.AddDbContext<Context>(u => u.UseSqlServer(builder.Configuration.GetConnectionString("C")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
