using Microsoft.Data.SqlClient;

namespace StockService.Infrastructure.Data
{
    public interface ISqlConnectionFactory
    {
        public SqlConnection SqlCreateConnection();
    }
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection SqlCreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("StockDbConn")!;
            return new SqlConnection(connectionString);
        }
    }
}
