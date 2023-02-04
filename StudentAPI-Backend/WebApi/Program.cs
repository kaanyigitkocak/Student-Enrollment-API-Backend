using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConfirmationService, ConfirmationManager>();
builder.Services.AddSingleton<IConfirmationDal, EfConfirmationDal>();

builder.Services.AddSingleton<IStudentService, StudentManager>();
builder.Services.AddSingleton<IStudentDal, EfStudentDal>();

builder.Services.AddSingleton<ISchoolService, SchoolManager>();
builder.Services.AddSingleton<ISchoolDal, EfSchoolDal>();


builder.Services.AddSingleton<IParentService, ParentManager>();
builder.Services.AddSingleton<IParentDal, EfParentDal>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();