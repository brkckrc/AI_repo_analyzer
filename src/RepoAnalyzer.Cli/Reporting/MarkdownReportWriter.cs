using System;
using System.IO;
using System.Threading.Tasks;

public sealed class MarkdownReportWriter
{
    public async Task WriteAsync(string reportMarkdown, ScanOptions options)
    {
        Directory.CreateDirectory(options.OutputDirectory);

        var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");

        var fileName = $"report_{options.Mode}_{timestamp}.md";
        var fullPath = Path.Combine(options.OutputDirectory, fileName);

        await File.WriteAllTextAsync(fullPath, reportMarkdown);

        Console.WriteLine($"\nReport saved to {fullPath}");
    }
}