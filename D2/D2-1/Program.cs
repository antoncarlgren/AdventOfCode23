using System.Text.RegularExpressions;

Console.WriteLine(File
    .ReadLines("input.txt")
    .Where(line => !new Regex(@"(1[3-9] red|1[4-9] green|1[5-9] blue)")
        .IsMatch(line))
    .Sum(game => int.Parse(new Regex(@"[0-9]+")
        .Match(game)
        .Value)));