using System.Diagnostics;

try
{
    var total = 0;
    for(int i = 0; i < 1000; i++)
    {
        var sw = new Stopwatch();

        using var httpClient = new HttpClient();
        sw.Start();
        var response = await httpClient.GetStringAsync("https://localhost:7022/persons?requested-from-grpc=false");
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        total += (int)sw.ElapsedMilliseconds;

    }
    Console.WriteLine($"Avg. { total / 1000}");
    Console.ReadKey();
}
catch(Exception ex)
{

}