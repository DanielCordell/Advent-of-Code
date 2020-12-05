using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

List<Match> inputs = Shared.ReadAllToRegex(Day2.Properties.Resources.Input, @"(\d+)-(\d+) (\w): (\w+)");

var output1 = inputs
    .Select(it => 
    (
        min: int.Parse(it.Groups[1].Value),
        max: int.Parse(it.Groups[2].Value),
        character: it.Groups[3].Value.First(),
        password: it.Groups[4].Value
    ))
    .Where(it =>
    {
        int characterCount = it.password.Count(it.character.Equals);
        return characterCount >= it.min && characterCount <= it.max;
    })
    .Count();

var output2 = inputs
    .Select(it =>
    (
        first: int.Parse(it.Groups[1].Value),
        second: int.Parse(it.Groups[2].Value),
        character: it.Groups[3].Value.First(),
        password: it.Groups[4].Value
    ))
    .Where(it => (it.password[it.first - 1] == it.character) != (it.password[it.second - 1] == it.character))
    .Count();

Console.WriteLine("Part1: " + output1);
Console.WriteLine("Part2: " + output2);