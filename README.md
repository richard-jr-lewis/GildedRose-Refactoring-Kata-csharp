# Gilded Rose Refactoring Kata - C# Only
**This repo was forked from the original [Gilded Rose Refactoring Kata](https://github.com/emilybache/GildedRose-Refactoring-Kata) and is a sample implementation in C#, with additional functionality. Please see the original for more detail.**

["Gilded Rose Requirements"](https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/main/GildedRoseRequirements.md) explains what the code is for.

## How to Run This Codebase
- Clone the repo

### Branches
- `main` - The original, unmodified 
- `refactor` - the completed refactor, without the conjured items update
- `conjured_items` - the completed refactor, with the conjured items update
- `extra_changes` - further additional changes, beyond the refactor and conjured items

### Build
Run from the `<SOURCE_DIRECTORY>`:
```
dotnet build ./csharpcore
```

### Unit Tests
This includes the existing Approval Test implementation as a Unit Test.

Run from the `<SOURCE_DIRECTORY>`:
```
dotnet test ./csharpcore
```

### Approval Tests Using TextTest
This uses the already implemented [TextTest](https://texttest.org) fixture for Approval testing.

Run from the `<SOURCE_DIRECTORY>`:
```
./start_texttest.bat
```

### Console App
Run from the `<SOURCE_DIRECTORY>`:
```
./csharpcore/GildedRoseConsole/bin/Debug/net8.0/GildedRoseConsole.exe x
```
where `x` is the number of days to run.

### API
Run from the `<SOURCE_DIRECTORY>`:
```
./csharpcore/GildedRoseApi/bin/Debug/net8.0/GildedRoseApi.exe
```

In the browser, you can test the following endpoints:

```
http://localhost:5000/api/gildedrose

http://localhost:5000/api/gildedrose/x
```
where `x` is the number of days to run.