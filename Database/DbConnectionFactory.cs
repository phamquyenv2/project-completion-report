using Microsoft.Data.SqlClient;
using System.Data;

namespace ProjectCompletionReport.Database
{
    public static class DbConnectionFactory
    {
        private static string Server => Environment.GetEnvironmentVariable("DB_SERVER") ?? @"QUYENDZ\QUYENDZ";
        private static string DatabaseName => Environment.GetEnvironmentVariable("DB_NAME") ?? "ProjectCompletionReport";
        private static string UserId => Environment.GetEnvironmentVariable("DB_USER") ?? "quyen_tt";
        private static string Password => Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";

        public static string MasterConnectionString =>
            $"Server={Server};Database=master;User Id={UserId};Password={Password};TrustServerCertificate=True";

        public static string ConnectionString =>
            $"Server={Server};Database={DatabaseName};User Id={UserId};Password={Password};TrustServerCertificate=True";
        public static IDbConnection Create()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
        public static IDbConnection CreateMaster()
        {
            var connection = new SqlConnection(MasterConnectionString);
            connection.Open();
            return connection;
        }
    }
}
