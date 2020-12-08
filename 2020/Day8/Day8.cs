using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

List<KeyValuePair<string, int>> program = Shared
    .ReadAllToRegex(Day8.Properties.Resources.Input, @"(\w+) ([\+-]\d+)")
    .Select(it => new KeyValuePair<string, int>(it.Groups[1].Value, int.Parse(it.Groups[2].Value)))
    .ToList();

int Part1()
{
    int acc = 0;
    var statementCounter = program.Select(it => (program: it, count: 0)).ToList();

    int pc = 0;

    while (true)
    {
        if (statementCounter[pc].count == 1)
            return acc;
        else
            statementCounter[pc] = (program: statementCounter[pc].program, count: statementCounter[pc].count + 1);

        var program = statementCounter[pc].program;

        if (program.Key == "nop") pc++;
        else if (program.Key == "jmp") pc += program.Value;
        else if (program.Key == "acc")
        {
            acc += program.Value;
            pc++;
        }
    }
}

int Part2()
{
    var statementCounter = program
        .Select(it => (program: it, count: 0))
        .ToList();

    return statementCounter
            .Select((it, i) =>
            {
                if (statementCounter[i].program.Key == "acc") return null;
                var newStatement = statementCounter.Select(itt => (new KeyValuePair<string, int>(itt.program.Key, itt.program.Value), itt.count)).ToList();
                var program = statementCounter[i].program;
                newStatement[i] = (program: new KeyValuePair<string, int>(program.Key == "nop" ? "jmp" : "nop", program.Value), count: statementCounter[i].count);
                return ComputerPart2(newStatement);
            }).Where(it => it.HasValue).First().Value;
}

int? ComputerPart2(List<(KeyValuePair<string, int> program, int count)> statementCounter)
{
    int acc = 0;

    int pc = 0;

    while (true)
    {
        if (pc == statementCounter.Count)
            return acc;
        if (statementCounter[pc].count == 1)
            return null;
        else
            statementCounter[pc] = (program: statementCounter[pc].program, count: statementCounter[pc].count + 1);

        var program = statementCounter[pc].program;

        if (program.Key == "nop") pc++;
        else if (program.Key == "jmp") pc += program.Value;
        else if (program.Key == "acc")
        {
            acc += program.Value;
            pc++;
        }
    }
}

Console.WriteLine("Part1: " + Part1());
Console.WriteLine("Part1: " + Part2());
