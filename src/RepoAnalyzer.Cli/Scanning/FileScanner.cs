using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public sealed class FileScanner
{
    public List<string> Scan(string path)
    {
        return Directory
            .GetFiles(path, "*.*", SearchOption.AllDirectories)
            .Where(f =>
                (f.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) ||
                 f.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ||
                 f.EndsWith(".md", StringComparison.OrdinalIgnoreCase)) &&
                !f.Contains("\\bin\\", StringComparison.OrdinalIgnoreCase) &&
                !f.Contains("\\obj\\", StringComparison.OrdinalIgnoreCase) &&
                !f.Contains("\\.git\\", StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

