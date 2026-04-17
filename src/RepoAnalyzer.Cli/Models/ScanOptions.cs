public sealed class ScanOptions
{
    public required string Path { get; init; }
    public required string Mode { get; init; }

    public int MaxFilesToSend { get; init; } = 2;
    public int MaxCharsPerFile { get; init; } = 2000;

    public string OutputDirectory { get; init; } = "output";
    public string ReportPath { get; init; } = @"output\report.md";
}

