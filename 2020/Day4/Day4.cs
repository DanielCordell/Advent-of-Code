using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

List<string> inputs = Shared.ReadAllSplitByRegex(Day4.Properties.Resources.Input, $"{Environment.NewLine}{Environment.NewLine}");

List<Dictionary<string, string>> Part1() {
    return inputs
        .Select(it => it.Split()
            .Where(it => !string.IsNullOrWhiteSpace(it))
            .Select(it => it.Split(":"))
            .ToDictionary(it => it[0], it => it[1]))
        .Where(it => it.Count == 8 || (it.Count == 7 && !it.ContainsKey("cid")))
        .ToList();
}

List<Dictionary<string, string>> Part2()
{
    return Part1()
        .Where(it =>
            Regex.IsMatch(it["byr"], "(19[2-9][0-9])|(200[0-2])") &&
            Regex.IsMatch(it["iyr"], "(201[0-9])|(2020)") &&
            Regex.IsMatch(it["eyr"], "(202[0-9])|(2030)") &&
            HeightCheck(it["hgt"]) &&
            Regex.IsMatch(it["hcl"], "^#[0-9a-f]{6}$") &&
            Regex.IsMatch(it["ecl"], "(amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)") &&
            Regex.IsMatch(it["pid"], @"^[0-9]{9}$")
        ).ToList();
}

bool HeightCheck(string height)
{
    Match match = Regex.Match(height, @"(\d+)(cm|in)");
    if (!match.Success) return false;

    int heightVal = int.Parse(match.Groups[1].Value);

    return match.Success && ((match.Groups[2].Value == "cm" && heightVal >= 150 && heightVal <= 193) || (match.Groups[2].Value == "in" && heightVal >= 59 && heightVal <= 76));
}

var part1 = Part1();
var part2 = Part2();
Console.WriteLine("Part1: " + part1.Count());
Console.WriteLine("Part2: " + part2.Count());
