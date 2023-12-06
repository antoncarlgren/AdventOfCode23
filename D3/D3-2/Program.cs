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
                match.Length,
            }),
        Gears = new Regex(@"[*]")
            .Matches(line)
            .Select(match => new
            {
                Numbers = new List<int>(),
                Line = y,
                Position = match.Index
            }),
    })
    .Chunk(int.MaxValue) // ?????????? sorry
    .Select(chunk => chunk
        .SelectMany(gears => gears.Gears)
        .Select(gear => gear with
        {
            Numbers = chunk
                .SelectMany(number => number.Numbers)
                .Where(num => Enumerable.Range(num.Line - 1, 3).Contains(gear.Line)
                    && Enumerable.Range(num.Start - 1, num.Length + 2).Contains(gear.Position))
                .Select(num => int.Parse(num.Value))
                .ToList()
        })
        .Where(gear => gear.Numbers.Count is 2)
        .Select(gear => gear.Numbers[0] * gear.Numbers[1])
        .Sum())
    .First());