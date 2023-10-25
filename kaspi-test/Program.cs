using DapperRepository.Database;
using DapperRepository.Migrations;
using FluentMigrator.Runner;
using kaspi_test.Extensions;
using Repository.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var sqlConn = builder.Configuration.GetConnectionString("SqlConnection");
string dnName = builder.Configuration.GetSection("DbName").Value;

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<DapperDatabase>();

var type = typeof(InitialTables_202310250001);

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer()
            .WithGlobalConnectionString(sqlConn)
            .ScanIn(Assembly.GetAssembly(type)).For.Migrations());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MigrateDatabase(dnName);

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
