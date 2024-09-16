using System.Reflection;
using DbUp;

namespace OneReview.Persistence.Database
{
    public static class DbInitializer
    {
        public static void Initialize(string connectionString)
        {
            // Ensure the postgresdb exists
            EnsureDatabase.For.PostgresqlDatabase(connectionString);
            
            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()) // get hold of all the sql scripts
                .WithTransaction()
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new InvalidOperationException("Database upgrade failed", result.Error);
            }
        }
    }
}