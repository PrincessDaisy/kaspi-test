using DapperRepository.Database;
using FluentMigrator.Runner;

namespace kaspi_test.Extensions
{
    public static class DapperMigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app, string dbName)
        {
            using (var scope = app.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<DapperDatabase>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    databaseService.CtreateDatabase(dbName);

                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex}");
                    throw;
                }
            }

            return app;
        }
    }
}
