# AI Repo Analyzer (CLI)

A lightweight .NET CLI tool that scans a codebase and generates AI-powered analysis reports using a locally running LLM via Ollama.

## 🚀 Features

- Scan a directory for source files (`.cs`, `.json`, `.md`)
- Generate AI-based summaries of the codebase
- Run in different modes:
  - `summary`: high-level overview
  - `review`: code review-style feedback
- Uses a **local LLM (Ollama)** — no cloud dependency required
- Outputs reports as Markdown files

## 🧠 Tech Stack

- .NET 9 (Console Application)
- Ollama (Local LLM runtime)
- Cursor (AI-assisted development)
- Git / GitHub

## 📦 Project Structure
src/RepoAnalyzer.Cli/
Application/
Models/
Scanning/
Prompting/
Reporting/
Ollama/


## ⚙️ Requirements

- .NET 9 SDK
- Ollama installed and running

Install Ollama:
https://ollama.com/

Run a model:
```bash
ollama run llama3

▶️ Usage
dotnet run --project ./src/RepoAnalyzer.Cli -- scan <path> --mode summary
dotnet run --project ./src/RepoAnalyzer.Cli -- scan . --mode review

📄 Output
Reports are generated in the output/ folder:
output/
  report_summary_YYYY-MM-DD_HH-mm.md
  report_review_YYYY-MM-DD_HH-mm.md

💡 Example Use Cases
Quickly understand unfamiliar codebases
Generate AI-assisted summaries before code reviews
Experiment with local LLM integration in developer tooling

🔮 Future Improvements
Add support for more file types
Improve prompt engineering
Add configuration options (model, limits, etc.)
Integrate with CI/CD pipelines

🧑‍💻 Author

Built as a Proof of Concept to explore AI-powered developer tools and CLI workflows.
