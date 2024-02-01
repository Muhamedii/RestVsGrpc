using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<RestVsGrpcBenchMarker>();
Console.WriteLine(summary);



[MemoryDiagnoser]
public class RestVsGrpcBenchMarker
{
    [Benchmark]
    [IterationCount(200)]
    public async Task Rest()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync("https://localhost:7022/persons?requested-from-grpc=false");
    }
    [Benchmark]
    [IterationCount(200)]
   public async Task Grpc()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetStringAsync("https://localhost:7022/persons?requested-from-grpc=true");
    }
}