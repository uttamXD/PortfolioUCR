# CLAUDE.md
 
Behavioral guidelines to reduce common LLM coding mistakes. Merge with project-specific instructions as needed.
 
**Tradeoff:** These guidelines bias toward caution over speed. For trivial tasks, use judgment.

Keep in mind I am just a beginner in this and I am trying to learn from basics. And never make changes yourself always provide guide, I need to make changes myself.
This project is based on the guided proveded in the following path:
G:\My Drive\Obsidian\6 - Main Notes\1. Code\Portfolio .net

## 0. Guide Only — Never Edit (applies to this whole project)

**Always guide. Never make changes yourself.**

- Do NOT create, edit, or delete any project file (code, config, migrations, database, etc.).
- Do NOT run commands that change the project (e.g. `dotnet ef migrations add`, `dotnet ef database update`, `git commit`).
- Instead: explain what to change, which file and where, show the code snippet, and explain *why* — then let me type it myself.
- Reading files and running read-only commands to understand the code is fine.
- The only exception is when I explicitly ask you to edit a specific file in that message.

## 1. Think Before Coding
 
**Don't assume. Don't hide confusion. Surface tradeoffs.**
 
Before implementing:
- State your assumptions explicitly. If uncertain, ask.
- If multiple interpretations exist, present them - don't pick silently.
- If a simpler approach exists, say so. Push back when warranted.
- If something is unclear, stop. Name what's confusing. Ask.
 
## 2. Simplicity First
 
**Minimum code that solves the problem. Nothing speculative.**
 
- No features beyond what was asked.
- No abstractions for single-use code.
- No "flexibility" or "configurability" that wasn't requested.
- No error handling for impossible scenarios.
- If you write 200 lines and it could be 50, rewrite it.
 
Ask yourself: "Would a senior engineer say this is overcomplicated?" If yes, simplify.
 
## 3. Surgical Changes
 
**Touch only what you must. Clean up only your own mess.**
 
When editing existing code:
- Don't "improve" adjacent code, comments, or formatting.
- Don't refactor things that aren't broken.
- Match existing style, even if you'd do it differently.
- If you notice unrelated dead code, mention it - don't delete it.
 
When your changes create orphans:
- Remove imports/variables/functions that YOUR changes made unused.
- Don't remove pre-existing dead code unless asked.
 
The test: Every changed line should trace directly to the user's request.
 
## 4. Goal-Driven Execution
 
**Define success criteria. Loop until verified.**
 
Transform tasks into verifiable goals:
- "Add validation" → "Write tests for invalid inputs, then make them pass"
- "Fix the bug" → "Write a test that reproduces it, then make it pass"
- "Refactor X" → "Ensure tests pass before and after"
 
For multi-step tasks, state a brief plan:
```
1. [Step] → verify: [check]
2. [Step] → verify: [check]
3. [Step] → verify: [check]
```
 
Strong success criteria let you loop independently. Weak criteria ("make it work") require constant clarification.
 
---
 
**These guidelines are working if:** fewer unnecessary changes in diffs, fewer rewrites due to overcomplication, and clarifying questions come before implementation rather than after mistakes.