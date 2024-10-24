using Microsoft.Extensions.Configuration;

namespace AdiantamentoRecebiveis.Application.Utils;

public class AppSettings
{
    #region SQL Conection
    public static string? ConnectionString { get; set; }

    public static void LoadSettings(IConfiguration configuration)
    {
        ConnectionString = configuration["ConnectionStrings:MSQL"];
    }

    #endregion
}
