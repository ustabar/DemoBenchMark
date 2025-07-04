using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;

/// <summary>
/// Benchmark class for comparing the performance of different cryptographic hash algorithms.
/// This class tests MD5 and SHA256 hashing algorithms to measure their relative performance
/// when processing the same input data.
/// </summary>
public class HashBenchmarks
{
    /// <summary>
    /// The input data used for all hash algorithm benchmarks.
    /// This byte array contains a UTF-8 encoded string that will be hashed by each algorithm.
    /// </summary>
    private readonly byte[] _data;

    /// <summary>
    /// Constructor that initializes the benchmark test data.
    /// The same data is used across all benchmark methods to ensure fair comparison.
    /// </summary>
    public HashBenchmarks()
    {
        // Sample data for hashing - convert a demo string to byte array
        // This represents typical data that might be hashed in a real application
        _data = Encoding.UTF8.GetBytes("Benchmarking hash algorithms with .NET Core!");
    }

    /// <summary>
    /// Benchmark method that measures the performance of MD5 hash algorithm.
    /// MD5 is a widely used cryptographic hash function that produces a 128-bit hash value.
    /// Note: MD5 is considered cryptographically broken and should not be used for security purposes.
    /// </summary>
    /// <returns>The computed MD5 hash as a byte array</returns>
    [Benchmark]
    public byte[] ComputeMD5()
    {
        // Create MD5 hash algorithm instance and compute hash
        // Using 'using' statement ensures proper disposal of resources
        using (var md5 = MD5.Create())
        {
            return md5.ComputeHash(_data);
        }
    }

    /// <summary>
    /// Benchmark method that measures the performance of SHA256 hash algorithm.
    /// SHA256 is part of the SHA-2 family and produces a 256-bit hash value.
    /// It is considered cryptographically secure and is widely used in security applications.
    /// </summary>
    /// <returns>The computed SHA256 hash as a byte array</returns>
    [Benchmark]
    public byte[] ComputeSHA256()
    {
        // Create SHA256 hash algorithm instance and compute hash
        // Using 'using' statement ensures proper disposal of resources
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(_data);
        }
    }
}
