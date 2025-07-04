using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;

public class HashBenchmarks
{
    private readonly byte[] _data;

    public HashBenchmarks()
    {
        // Sample data for hashing
        _data = Encoding.UTF8.GetBytes("Benchmarking hash algorithms with .NET Core!");
    }

    [Benchmark]
    public byte[] ComputeMD5()
    {
        using (var md5 = MD5.Create())
        {
            return md5.ComputeHash(_data);
        }
    }

    [Benchmark]
    public byte[] ComputeSHA256()
    {
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(_data);
        }
    }
}
