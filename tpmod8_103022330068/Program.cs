using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        Console.WriteLine($"Satuan suhu saat ini: {config.satuan_suhu}");
        Console.Write($"Berapa suhu badan anda saat ini? (dalam {config.satuan_suhu}): ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;

        if (config.satuan_suhu.ToLower() == "celcius")
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        else
            suhuValid = suhu >= 97.7 && suhu <= 99.5;

        bool hariValid = hari < config.batas_hari_demam;

        if (suhuValid && hariValid)
            Console.WriteLine(config.pesan_diterima);
        else
            Console.WriteLine(config.pesan_ditolak);

        Console.Write("\nApakah anda ingin mengganti satuan suhu? (y/n): ");
        string pilihan = Console.ReadLine();
        if (pilihan.ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu sekarang adalah: {config.satuan_suhu}");
        }
    }
}
