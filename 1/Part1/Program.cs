Console.WriteLine(File
    .ReadLines("input.txt")
    .Select(line => int.Parse($"{line.FirstOrDefault(char.IsDigit)}{line.LastOrDefault(char.IsDigit)}"))
    .Sum());
