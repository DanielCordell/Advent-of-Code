using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

DateTime dt = DateTime.Now;

List<Match> inputs = Shared.ReadAllToRegex(Day7.Properties.Resources.Input, @"([a-z]+ [a-z]+) bags contain (.*)\.");

Dictionary<string, Dictionary<string, int>> bags = inputs
    .ToDictionary(it => it.Groups[1].Value, it => it.Groups[2].Value.Split(", ")
        .Select((itt, i) => (i, Regex.Match(itt, @"(\d) ([a-z]+ [a-z]+) bags?(,|.)?")))
        .ToDictionary(itt => itt.Item2.Groups[2].Value, itt => itt.Item2.Success ? int.Parse(itt.Item2.Groups[1].Value) : 0)
    );


bool BagContainsBag(string container, string contained)
{
    return container != "" && (container == contained || bags[container].Any(it => BagContainsBag(it.Key, contained)));
}

int HowManyContainingBags(string bag)
{
    return bag == "" ? 0 : bags[bag].Values.Sum() + bags[bag].Select(it => HowManyContainingBags(it.Key) * it.Value).Sum();
}

int Task1()
{
    return bags.Where(it => it.Key != "shiny gold" && BagContainsBag(it.Key, "shiny gold")).Count();
}

int Task2()
{
    return HowManyContainingBags("shiny gold");
}


Console.WriteLine("Task1: " + Task1());
Console.WriteLine("Task2: " + Task2());

DateTime dt2 = DateTime.Now;

Console.WriteLine(dt2 - dt);