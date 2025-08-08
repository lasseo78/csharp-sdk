using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace QuickstartWeatherServer.Tools;

[McpServerToolType]
public sealed class DummyTools
{
    [McpServerTool, Description("A dummy tool that tells the meaning of life.")]
    public static Task<string> GetMeaningOfLife() => Task.FromResult("The meaning of life is beer.");
    [McpServerTool, Description("A tool that gets life expectancy in norway the past 10 years.")]
    public static Task<IEnumerable<double>> GetLifeExpectancies() => Task.FromResult<IEnumerable<double>>(new[]
    {
        81.4, // 2022
        81.2, // 2021
        81.0, // 2020
        80.8, // 2019
        80.6, // 2018
        80.4, // 2017
        80.2, // 2016
        80.0, // 2015
        79.8, // 2014
        79.6, // 2013
    });
}
