using System;
using Microsoft.Extensions.Configuration;

namespace AdiantamentoRecebiveis.Infrastructure.Configs;

public class AppSettings(IConfiguration configuration)
{
    #region SQL Conection
    private readonly IConfiguration _configuration = configuration;
    public static string? ConnectionString { get; set; }

    public  void LoadSettings()
    {
        ConnectionString = _configuration["ConnectionStrings:MSQL"];
    }

    #endregion
}
