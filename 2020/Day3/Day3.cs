using System;
using System.Collections.Generic;
using System.Linq;

List<string> inputs = Shared.ReadAll(Day3.Properties.Resources.Input);

Part1();
Part2();

int CalculateSlope(int right, int down)
{
    int hit = 0;
    int position = 0;
    for (int i = down; i <= inputs.Count - 1; ++i)
    {
        if (i % down != 0) continue;
        string input = inputs[i];
        position = (position + right) % input.Length;
        if (input[position] == '#') hit++;
    }
    return hit;
}

// Day1
void Part1() {
    int hit = CalculateSlope(3, 1);
    Console.WriteLine("Part1: " + hit);
}

void Part2()
{
    int slope1 = CalculateSlope(1, 1);
    int slope2 = CalculateSlope(3, 1);
    int slope3 = CalculateSlope(5, 1);
    int slope4 = CalculateSlope(7, 1);
    int slope5 = CalculateSlope(1, 2);
    Console.WriteLine("Part2: " + slope1 * slope2 * slope3 * slope4 * slope5);
}