// BenchmarkDotNet kütüphanesini dahil et
using BenchmarkDotNet.Attributes;
// Güvenlik kriptografisi için
using System.Security.Cryptography;
// Metin işleme için
using System.Text;

// DemoBenchMark namespace'i
namespace DemoBenchMark;

/// <summary>
/// Hash algoritmaları için benchmark testleri
/// Bu sınıf farklı hash algoritmalarının performansını karşılaştırır
/// </summary>
[MemoryDiagnoser] // Bellek kullanımını da ölçer
public class HashBenchmarks
{
    // Test edilecek veri
    private readonly string _testData;
    // Test verisinin byte dizisi hali
    private readonly byte[] _testBytes;
    
    // Hash algoritmaları
    private readonly SHA256 _sha256;
    private readonly MD5 _md5;

    /// <summary>
    /// Yapıcı metod - Test verilerini hazırlar
    /// </summary>
    public HashBenchmarks()
    {
        // Test verisi oluştur (1000 karakter)
        var random = new Random(42); // Sabit seed kullan
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var builder = new StringBuilder(1000);
        
        // Rastgele karakterlerle string oluştur
        for (int i = 0; i < 1000; i++)
        {
            builder.Append(chars[random.Next(chars.Length)]);
        }
        
        _testData = builder.ToString();
        _testBytes = Encoding.UTF8.GetBytes(_testData);
        
        // Hash algoritmaları örneklerini oluştur
        _sha256 = SHA256.Create();
        _md5 = MD5.Create();
    }

    /// <summary>
    /// SHA256 hash algoritması testi
    /// Güvenli ama yavaş hash fonksiyonu
    /// </summary>
    [Benchmark]
    public byte[] SHA256Hash()
    {
        return _sha256.ComputeHash(_testBytes);
    }

    /// <summary>
    /// MD5 hash algoritması testi
    /// Hızlı ama güvenlik açısından zayıf
    /// </summary>
    [Benchmark]
    public byte[] MD5Hash()
    {
        return _md5.ComputeHash(_testBytes);
    }

    /// <summary>
    /// String'in dahili hash fonksiyonu testi
    /// En hızlı seçenek
    /// </summary>
    [Benchmark]
    public int StringHashCode()
    {
        return _testData.GetHashCode();
    }

    /// <summary>
    /// Özel hash algoritması testi
    /// Basit bir hash implementasyonu
    /// </summary>
    [Benchmark]
    public int CustomHash()
    {
        int hash = 0;
        // Her karakter için hash hesapla
        foreach (char c in _testData)
        {
            hash = (hash * 31) + c; // 31 sayısı hash için popüler
        }
        return hash;
    }

    /// <summary>
    /// Kaynakları temizle
    /// </summary>
    public void Dispose()
    {
        _sha256?.Dispose();
        _md5?.Dispose();
    }
}