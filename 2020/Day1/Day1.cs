using System;
using System.Collections.Generic;
using System.Linq;

const int toFind = 2020;

List<int> inputs = Shared.ReadAllToInt(Day1.Properties.Resources.Input);

var output = inputs
    .SelectMany((it, i) => inputs.Where((it2, i2) => i2 > i).Select(it2 => (it + it2, it * it2)).Where(it2 => it2.Item1 == toFind));

Console.WriteLine("Part1: " + output.FirstOrDefault().Item2);

for (int i = 0; i < inputs.Count; i++)
{
    int a = inputs[i];
    for (int i1 = i; i1 < inputs.Count; i1++)
    {
        int b = inputs[i1];
        for (int i2 = i1; i2 < inputs.Count; i2++)
        {
            int c = inputs[i2];
            if (a+b+c == toFind) Console.WriteLine("Part2: " + a*b*c);
        }
    }
}