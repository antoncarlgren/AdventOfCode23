using System.Drawing;
using System.Text.RegularExpressions;

Console.WriteLine(File
    .ReadLines("input.txt")
    .Select((line, y) => new
    {
        Numbers = new Regex(@"[0-9]+")
            .Matches(line)
            .Select(match => new
            {
                match.Value,
                Line = y,
                Start = match.Index,
                match.Length
            }),
        Gears = new Regex(@"[^0-9|.]")
            .Matches(line)
            .Select(match => new
            {
                Line = y,
                Position = match.Index
            }),
    })
    .Chunk(int.MaxValue) // ?????????? sorry
    .Select(chunk => chunk
        .SelectMany(numbers => numbers.Numbers)
        .Where(num => chunk
            .SelectMany(parts => parts.Gears)
            .Any(part => Enumerable.Range(num.Line - 1, 3).Contains(part.Line) 
                && Enumerable.Range(num.Start - 1, num.Length + 2).Contains(part.Position)))
        .Sum(num => int.Parse(num.Value)))
    .First());
