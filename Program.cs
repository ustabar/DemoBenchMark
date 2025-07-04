using BenchmarkDotNet.Running;

/// <summary>
/// Demo benchmark application that demonstrates performance testing using BenchmarkDotNet.
/// This application compares the performance of different hashing algorithms.
/// </summary>
class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// Executes the benchmark tests defined in the HashBenchmarks class.
    /// </summary>
    /// <param name="args">Command line arguments (not used in this application)</param>
    static void Main(string[] args)
    {
        // Run benchmarks for the HashBenchmarks class
        // This will execute all methods marked with [Benchmark] attribute
        // and generate performance statistics and comparison reports
        BenchmarkRunner.Run<HashBenchmarks>();
    }
}
