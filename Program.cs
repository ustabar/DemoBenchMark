using BenchmarkDotNet.Running;

namespace DemoBenchMark;

/// <summary>
/// Ana program sınıfı - Benchmark testlerini çalıştırmak için giriş noktasıdır
/// Bu sınıf, BenchmarkDotNet kütüphanesini kullanarak performans testlerini başlatır
/// </summary>
public class Program
{
    /// <summary>
    /// Uygulamanın ana giriş noktası
    /// Benchmark testlerini çalıştırır ve sonuçları konsola yazdırır
    /// </summary>
    /// <param name="args">Komut satırı argümanları</param>
    public static void Main(string[] args)
    {
        // Konsol ekranına hoş geldiniz mesajı yazdır
        Console.WriteLine("=== DemoBenchMark Performans Test Uygulaması ===");
        Console.WriteLine("Hash fonksiyonlarının performans testleri başlatılıyor...");
        Console.WriteLine();

        // BenchmarkDotNet ile HashBenchmarks sınıfındaki testleri çalıştır
        // Bu, otomatik olarak tüm [Benchmark] öznitelikli metotları bulur ve test eder
        BenchmarkRunner.Run<HashBenchmarks>();
        
        // Test tamamlandıktan sonra kullanıcıdan giriş bekle
        Console.WriteLine("\nTestler tamamlandı. Çıkmak için herhangi bir tuşa basın...");
        Console.ReadKey();
    }
}
