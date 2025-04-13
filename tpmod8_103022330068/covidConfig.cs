using System;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; } = "celcius";
    public int batas_hari_demam { get; set; } = 14;
    public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    private const string configFile = "covid_config.json";

    public static CovidConfig LoadConfig()
    {
        if (File.Exists(configFile))
        {
            string json = File.ReadAllText(configFile);
            var config = JsonSerializer.Deserialize<CovidConfig>(json);
            if (config != null)
                return config;
        }

   
        var defaultConfig = new CovidConfig();
        defaultConfig.SaveConfig();
        return defaultConfig;
    }

    public void SaveConfig()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(configFile, json);
    }

    public void UbahSatuan()
    {
        satuan_suhu = (satuan_suhu.ToLower() == "celcius") ? "fahrenheit" : "celcius";
        SaveConfig();
    }
}
