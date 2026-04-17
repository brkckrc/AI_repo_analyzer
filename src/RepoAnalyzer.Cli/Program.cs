using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 2 || args[0] != "scan")
        {
            Console.WriteLine("Usage: repoanalyzer scan <path> [--mode summary|review]");
            return;
        }

        var path = args[1];
        var mode = "summary";

        if (args.Length >= 4 && args[2] == "--mode")
        {
            mode = args[3];
        }

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Path not found.");
            return;
        }

        var app = new RepoScanApplication(
            new FileScanner(),
            new PromptBuilder(),
            new OllamaClient(),
            new MarkdownReportWriter());

        await app.RunAsync(new ScanOptions
        {
            Path = path,
            Mode = mode
        });
    }
}