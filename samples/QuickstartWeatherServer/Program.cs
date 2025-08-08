using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuickstartWeatherServer.Tools;
using System.Net.Http.Headers;
using System.Net.Sockets;

var builder = Host.CreateApplicationBuilder(args);


// Addon for listeing on a TCP port
var listener = new TcpListener(IPAddress.Loopback, 5000);
listener.Start();
/*
Console.WriteLine("Waiting for connection on port 5000...");
var client = await listener.AcceptTcpClientAsync();
Console.WriteLine("Client connected.");

var stream = client.GetStream();

builder.Services.AddMcpServer()
    .WithStreamServerTransport(stream, stream)
    .WithTools<WeatherTools>();
*/
builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<WeatherTools>()
    .WithTools<DummyTools>();

builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services.AddSingleton(_ =>
{
    var client = new HttpClient() { BaseAddress = new Uri("https://api.weather.gov") };
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("weather-tool", "1.0"));
    return client;
});

await builder.Build().RunAsync();
