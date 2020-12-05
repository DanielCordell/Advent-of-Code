using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Shared
{
    public static List<string> ReadAll(string path)
    {
        return path.Split(Environment.NewLine).ToList();
    }

    public static List<int> ReadAllToInt(string path)
    {
        return ReadAll(path).Select(int.Parse).ToList();
    }

    public static List<long> ReadAllToLong(string path)
    {
        return ReadAll(path).Select(long.Parse).ToList();
    }

    public static List<double> ReadAllToDouble(string path)
    {
        return ReadAll(path).Select(double.Parse).ToList();
    }

    public static List<Match> ReadAllToRegex(string path, string regex)
    {
        Regex rx = new Regex(regex);
        return ReadAll(path).Select(it => rx.Match(it)).ToList();
    }
}