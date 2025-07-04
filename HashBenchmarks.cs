using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using System.Text;

namespace DemoBenchMark;

/// <summary>
/// Hash fonksiyonlarının performans testlerini içeren sınıf
/// Bu sınıf farklı hash algoritmaları arasında performans karşılaştırması yapar
/// BenchmarkDotNet kütüphanesi kullanılarak otomatik performans ölçümleri yapılır
/// </summary>
[MemoryDiagnoser] // Bellek kullanımını da ölçümler
[SimpleJob] // Basit iş konfigürasyonu - hızlı test için
public class HashBenchmarks
{
    /// <summary>
    /// Test edilecek örnek veri - 1000 karakterlik rastgele string
    /// Tüm hash fonksiyonları bu veri üzerinde test edilir
    /// </summary>
    private readonly string _testData;
    
    /// <summary>
    /// Test verisinin byte dizisi halinde saklanması
    /// Hash fonksiyonları byte dizisi ile çalıştığı için önceden dönüştürülür
    /// </summary>
    private readonly byte[] _testBytes;

    /// <summary>
    /// SHA256 hash algoritması örneği
    /// Güvenli hash fonksiyonu - yavaş ama güvenli
    /// </summary>
    private readonly SHA256 _sha256 = SHA256.Create();
    
    /// <summary>
    /// MD5 hash algoritması örneği
    /// Hızlı hash fonksiyonu - güvenlik açısından zayıf ama performanslı
    /// </summary>
    private readonly MD5 _md5 = MD5.Create();

    /// <summary>
    /// Benchmark sınıfının yapıcı metodu
    /// Test verilerini hazırlar ve hash algoritmalarını başlatır
    /// </summary>
    public HashBenchmarks()
    {
        // 1000 karakterlik rastgele test verisi oluştur
        var random = new Random(42); // Sabit seed - tutarlı sonuçlar için
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringBuilder = new StringBuilder(1000);
        
        // Rastgele karakterlerle string oluştur
        for (int i = 0; i < 1000; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }
        
        _testData = stringBuilder.ToString();
        _testBytes = Encoding.UTF8.GetBytes(_testData);
    }

    /// <summary>
    /// SHA256 hash fonksiyonunun performans testi
    /// Güvenli ama yavaş hash algoritması
    /// Kriptografik güvenlik gerektiren durumlarda tercih edilir
    /// </summary>
    /// <returns>Hash sonucu byte dizisi</returns>
    [Benchmark]
    public byte[] SHA256Hash()
    {
        // Test verisini SHA256 ile hash'le
        return _sha256.ComputeHash(_testBytes);
    }

    /// <summary>
    /// MD5 hash fonksiyonunun performans testi
    /// Hızlı ama güvenlik açısından zayıf hash algoritması
    /// Sadece hız gerektiren ve güvenlik önemli olmayan durumlarda kullanılır
    /// </summary>
    /// <returns>Hash sonucu byte dizisi</returns>
    [Benchmark]
    public byte[] MD5Hash()
    {
        // Test verisini MD5 ile hash'le
        return _md5.ComputeHash(_testBytes);
    }

    /// <summary>
    /// Basit string hash fonksiyonunun performans testi
    /// .NET'in dahili GetHashCode() metodunu kullanır
    /// En hızlı seçenek ama hash kalitesi düşük
    /// </summary>
    /// <returns>Hash sonucu integer değeri</returns>
    [Benchmark]
    public int StringHashCode()
    {
        // String'in dahili hash fonksiyonunu kullan
        return _testData.GetHashCode();
    }

    /// <summary>
    /// Özel hash fonksiyonunun performans testi
    /// Basit bir hash algoritması implementasyonu
    /// Eğitim amaçlı - gerçek projede kullanılmamalı
    /// </summary>
    /// <returns>Hash sonucu integer değeri</returns>
    [Benchmark]
    public int CustomHash()
    {
        int hash = 0;
        
        // Her karakter için basit hash hesaplama
        foreach (char c in _testData)
        {
            // Hash değerini kaydır ve yeni karakteri ekle
            hash = (hash * 31) + c; // 31 sayısı hash fonksiyonlarında yaygın kullanılır
        }
        
        return hash;
    }

    /// <summary>
    /// Kaynakları temizleme metodu
    /// Hash algoritmalarının kullandığı kaynakları serbest bırakır
    /// </summary>
    public void Dispose()
    {
        _sha256?.Dispose();
        _md5?.Dispose();
    }
}
