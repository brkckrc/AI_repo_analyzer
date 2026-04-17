using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public sealed class PromptBuilder
{
    public async Task<string> BuildPromptAsync(List<string> files, ScanOptions options)
    {
        var selectedFiles = files.Take(options.MaxFilesToSend).ToList();
        var combinedContent = "";

        foreach (var file in selectedFiles)
        {
            var content = await File.ReadAllTextAsync(file);

            if (content.Length > options.MaxCharsPerFile)
            {
                content = content.Substring(0, options.MaxCharsPerFile);
            }

            combinedContent += $"\n\nFILE: {file}\n{content}";
        }

        var mode = options.Mode;

        return mode.ToLower() switch
        {
            "review" => $"""
Analyze this small codebase as a code reviewer.

Return:
1. A short summary
2. What it currently does
3. 3 code quality or design improvements

Code:
{combinedContent}
""",
            _ => $"""
Analyze this small codebase briefly.

Return:
1. One short summary
2. What it currently does
3. Two improvement suggestions

Code:
{combinedContent}
"""
        };
    }
}

