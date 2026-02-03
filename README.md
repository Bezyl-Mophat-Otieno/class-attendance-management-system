
# Automated Code Formatting with Husky.Net

This repository uses **Husky.Net** to enforce consistent C# code styling across the codebase.

Before every commit, `dotnet format` automatically runs on **staged files only**, ensuring clean commits and reducing “style-only” pull request comments.

---

## Initial Setup

If you are setting this up for the **first time** in the repository, follow the steps below.

---

### 1️⃣ Initialize the Tool Manifest

```bash
dotnet new tool-manifest
```

Creates a `.config/dotnet-tools.json` file to track local .NET tools.

---

### 2️⃣ Install Husky.Net

```bash
dotnet tool install Husky
```

Adds Husky.Net as a local project tool.

---

### 3️⃣ Activate Git Hooks

```bash
dotnet husky install
dotnet husky add pre-commit -c "dotnet husky run"
```

* Redirects Git hooks to the `.husky` directory
* Creates a `pre-commit` hook that runs the Husky task runner

---

### 4️⃣ Configure the Task Runner

Ensure your `.husky/task-runner.json` includes the formatting task below:

```json
{
  "tasks": [
    {
      "name": "format-staged",
      "group": "pre-commit",
      "command": "dotnet",
      "args": ["format", "--include", "${staged}"],
      "include": ["**/*.cs"]
    }
  ]
}
```

This ensures:

* Only **staged `.cs` files** are formatted
* Formatting runs automatically before each commit

---

### 5️⃣ Automate Setup for the Entire Team

```bash
dotnet husky attach <path-to-your-project>.csproj
```

This adds a build target to the `.csproj` file so that:

* Git hooks are automatically installed
* No manual Husky setup is required for other developers

---

## 💻 Developer Workflow

Once setup is complete, **no extra steps are required** in your daily workflow.

### Committing Code

When you run:

```bash
git commit
```

Husky automatically:

* Runs `dotnet format` on staged `.cs` files
* Ensures formatting consistency before the commit is created

---

### Failed Commits

If:

* Formatting issues cannot be auto-fixed, or
* `dotnet format --verify-no-changes` fails

The commit will be **blocked** until the issues are resolved.

---

### Bypassing Hooks (Use Sparingly)

If you must commit without running hooks:

```bash
git commit -m "Your message" --no-verify
```

Use this only when absolutely necessary.

---

## 🔧 Requirements

* **.NET SDK**: v6.0 or later (recommended)
* **EditorConfig** file at the repository root for custom style rules

---

## (Optional) Running Unit Tests on Pre-Commit

You can extend this setup to **run unit tests before committing** by adding an additional task.

### Example: Add Unit Tests to `task-runner.json`

```json
{
  "tasks": [
    {
      "name": "format-staged",
      "group": "pre-commit",
      "command": "dotnet",
      "args": ["format", "--include", "${staged}"],
      "include": ["**/*.cs"]
    },
    {
      "name": "run-tests",
      "group": "pre-commit",
      "command": "dotnet",
      "args": ["test", "--no-build"]
    }
  ]
}
```

This ensures:

* Code is formatted
* Tests pass
* Only high-quality commits make it into the repository

> 💡 Tip: Consider keeping unit tests fast to avoid slowing down commits.

---

## Why This Setup Works Well

* Enforces consistent formatting automatically
* Reduces review noise and style-only PR comments
* Keeps commits clean, intentional, and production-ready
* Zero friction for new developers joining the project

