using KeyStoneEmployeeManageMent_BusinessObject.InterFace;
using KeyStoneEmployeeManageMent_DataBaseLogic.Data;
using KeyStoneEmployeeManageMent_RepositaryLayer;
using KeyStoneEmployeeManageMent_ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepositary, CustomerRepositary>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IConfigurationFactory, ConfigurationFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
