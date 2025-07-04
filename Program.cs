// BenchmarkDotNet kütüphanesini dahil et
using BenchmarkDotNet.Running;

// DemoBenchMark namespace'i
namespace DemoBenchMark;

/// <summary>
/// Ana program sınıfı
/// Bu sınıf uygulamanın giriş noktasını sağlar ve benchmark testlerini çalıştırır
/// </summary>
public class Program
{
    /// <summary>
    /// Ana metod - Uygulamanın çalışmaya başladığı ilk nokta
    /// </summary>
    /// <param name="args">Komut satırı argümanları</param>
    public static void Main(string[] args)
    {
        // Kullanıcıya hoş geldin mesajı göster
        Console.WriteLine("=== DemoBenchMark Uygulaması ===");
        Console.WriteLine("Performans testleri başlatılıyor...");
        
        // BenchmarkDotNet ile Hash benchmark testlerini çalıştır
        BenchmarkRunner.Run<HashBenchmarks>();
        
        // Kullanıcıdan çıkmak için tuş bekle
        Console.WriteLine("\nTestler tamamlandı. Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}