using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

List<string> inputs = Shared.ReadAllSplitByRegex(Day6.Properties.Resources.Input, $"{Environment.NewLine}{Environment.NewLine}");

int Part1()
{
    return inputs
        .Select(it => it.Where(itt => !char.IsWhiteSpace(itt))
            .Distinct()
            .Count()
        ).Sum();
}

int Part2()
{
    return inputs
    .Select(it => it.Split(Environment.NewLine)
        .Aggregate((prev, next) => string.Join("", prev.Intersect(next)))
        .Count()
    ).Sum();
}

Console.WriteLine("Part1: " + Part1());
Console.WriteLine("Part2: " + Part2());