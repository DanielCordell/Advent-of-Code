using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

List<string> inputs = Shared.ReadAll(Day5.Properties.Resources.Input);

var seats = inputs.Select(it =>
{
    var (row, max) = (0, 127);
    for (int i = 0; i < 7; ++i)
    {
        if (it[i] == 'B') row += (int)Math.Ceiling((max-row) / 2.0);
        else max -= (int)Math.Ceiling((max-row) / 2.0);
    }
    var (col, colmax) = (0, 7);
    for (int i = 7; i < 10; ++i)
    {
        if (it[i] == 'R') col += (int)Math.Ceiling((colmax - col) / 2.0);
        else colmax -= (int)Math.Ceiling((colmax - col) / 2.0);
    }
    return row * 8 + col;
}).OrderBy(it => it).ToList();

Console.WriteLine("Part1: " + seats.Max());

var results = seats.Where((it, i) => i != 0 && i != seats.Count - 1 && seats[i - 1] != it - 1);

Console.WriteLine("Part2: " + results.First());