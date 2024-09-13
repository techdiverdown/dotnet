using System.Reflection;
using DbUp;

namespace OneReview.Persistence.Database.Scripts
{
    public static class DbInitializer
    {
        public static void Initialize(string connectionString)
        {
            // Ensure the postgresdb exists
            EnsureDatabase.For.PostgresqlDatabase(connectionString);
            
            // Run scripts in order
            var upgrader = DeployChanges.To.PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssemblies(new[] { Assembly.GetExecutingAssembly() })
                .WithTransaction()
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception("Database upgrade failed", result.Error);
            }
        }
    }
}