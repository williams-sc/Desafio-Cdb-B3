using B3.CDB.API.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace B3.CDB.Unit.Test.Configuration
{
    public static class SettingsConfiguration
    {
        public static IConfigurationRoot InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                    path: "appsettings.Development.json",
                    optional: true,
                    reloadOnChange: true)
                .Build();

            return config;
        }

        public static IOptions<IncomeTaxRange> InitIncomeTaxVariable()
        {
            var options = InitConfiguration();
            var income = new IncomeTaxRange();

            options.GetSection(nameof(IncomeTaxRange)).Bind(income);

            var incomeOptions = Options.Create(income);

            return incomeOptions;
        }
    }
}
