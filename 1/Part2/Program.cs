Console.WriteLine(File
    .ReadLines("input.txt")
    .Select(line => new Dictionary<string, int>
        {
            ["zero"] = 0,
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9,
        }
        .Aggregate(line, (result, next) => result.Replace(next.Key, $"{next.Key[0]}{next.Value}{next.Key[^1]}"))
        .Where(char.IsDigit))
    .Select(line => int.Parse($"{line.FirstOrDefault()}{line.LastOrDefault()}"))
    .Sum());