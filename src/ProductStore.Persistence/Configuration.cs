using Microsoft.Extensions.Configuration;
namespace ProductStore.Persistence;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            try
            {
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ProductStore.WebApi"));
                configurationManager.AddJsonFile("appsettings.json");
            }
            catch
            {
                configurationManager.AddJsonFile("appsettings.Production.json");
            }

            return configurationManager.GetConnectionString("MySqlConnection");
        }
    }
}
