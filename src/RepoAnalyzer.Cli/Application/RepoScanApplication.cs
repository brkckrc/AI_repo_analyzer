using System;
using System.Threading.Tasks;

public sealed class RepoScanApplication
{
    private readonly FileScanner _fileScanner;
    private readonly PromptBuilder _promptBuilder;
    private readonly OllamaClient _ollamaClient;
    private readonly MarkdownReportWriter _reportWriter;

    public RepoScanApplication(
        FileScanner fileScanner,
        PromptBuilder promptBuilder,
        OllamaClient ollamaClient,
        MarkdownReportWriter reportWriter)
    {
        _fileScanner = fileScanner;
        _promptBuilder = promptBuilder;
        _ollamaClient = ollamaClient;
        _reportWriter = reportWriter;
    }

    public async Task RunAsync(ScanOptions options)
    {
        Console.WriteLine($"Scanning: {options.Path}");
        Console.WriteLine($"Mode: {options.Mode}");

        var files = _fileScanner.Scan(options.Path);

        Console.WriteLine($"Found {files.Count} files:");

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }

        if (files.Count == 0)
        {
            Console.WriteLine("No supported files found for analysis.");
            return;
        }

        var prompt = await _promptBuilder.BuildPromptAsync(files, options);

        Console.WriteLine("\nSending content to Ollama...\n");

        var result = await _ollamaClient.GenerateAsync(prompt);

        Console.WriteLine("\n--- AI ANALYSIS ---\n");
        Console.WriteLine(result);

        await _reportWriter.WriteAsync(result, options);

        Console.WriteLine("\nReport saved to output\\report.md");
    }
}

