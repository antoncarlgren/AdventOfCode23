Console.WriteLine(File
    .ReadLines("input.txt")
    .Select(line => line
        .Split(':', ';')[1..]
        .Select(game => game
            .Split(',')
            .Select(color => new
            {
                Color = string.Join("", color.Where(char.IsLetter)), 
                Count = int.Parse(string.Join("", color.Where(char.IsDigit)))
            }))
        .SelectMany(game => game)
        .GroupBy(color => color.Color, color => color.Count)
        .Select(group => group.MaxBy(count => count))
        .Aggregate((current, next) => current * next))
    .Sum());