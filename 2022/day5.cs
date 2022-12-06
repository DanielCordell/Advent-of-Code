using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()
	{
		var inputSplt = input.Split("\n");
		var inputChars = inputSplt.TakeWhile(x => x.Length != 0)
			.SkipLast(1).Select((x, i) => (i, x.Where((c, i) => i % 4 == 1).ToArray())).Reverse();
		var inputSet = inputChars
			.Aggregate(
				Enumerable.Range(0, inputChars.Count() + 1).Select(_ => new Stack<char>()).ToList(),
				(curr, next) => { 
					for (int i = 0; i < next.Item2.Length; i++)
					{
						char c = next.Item2[i];
						if (!char.IsWhiteSpace(c)) curr[i].Push(c); }
					return curr; 
				} );
		
		var inputInstr = inputSplt.Skip(inputChars.Count() + 2)
			.Select(x => Regex.Match(x, "move (\\d+) from (\\d+) to (\\d+)").Groups);
			
		var outputDay1 = inputSet;
		var outputDay2 = inputSet.ConvertAll(x => new Stack<char>(x.Reverse()));		
		
		foreach (var instr in inputInstr)
			for (int i = 0; i < int.Parse(instr[1].Value); i++)
				outputDay1[int.Parse(instr[3].Value) - 1].Push(outputDay1[int.Parse(instr[2].Value) - 1].Pop());
	
		var day1 = string.Join("", outputDay1.Select(n => n.Peek()));
		
		foreach (var instr in inputInstr)
		{
			var working = new Stack<char>();
			for (int i = 0; i < int.Parse(instr[1].Value); i++)
				working.Push(outputDay2[int.Parse(instr[2].Value) - 1].Pop());
			while (working.Count != 0)
				outputDay2[int.Parse(instr[3].Value) - 1].Push(working.Pop());
		}
		
		var day2 = string.Join("", outputDay2.Select(n => n.Peek()));
		
		Console.WriteLine(day1 + " " + day2);
	}
public static string input = 
"""
                [B] [L]     [J]    
            [B] [Q] [R]     [D] [T]
            [G] [H] [H] [M] [N] [F]
        [J] [N] [D] [F] [J] [H] [B]
    [Q] [F] [W] [S] [V] [N] [F] [N]
[W] [N] [H] [M] [L] [B] [R] [T] [Q]
[L] [T] [C] [R] [R] [J] [W] [Z] [L]
[S] [J] [S] [T] [T] [M] [D] [B] [H]
 1   2   3   4   5   6   7   8   9 

move 5 from 4 to 5
move 2 from 5 to 8
move 2 from 9 to 1
move 2 from 9 to 1
move 1 from 5 to 3
move 10 from 5 to 8
move 1 from 4 to 7
move 1 from 1 to 2
move 5 from 3 to 7
move 1 from 2 to 8
move 21 from 8 to 5
move 13 from 5 to 7
move 2 from 9 to 4
move 1 from 7 to 4
move 5 from 1 to 4
move 1 from 5 to 7
move 2 from 2 to 7
move 1 from 3 to 2
move 1 from 1 to 6
move 7 from 5 to 9
move 16 from 7 to 4
move 7 from 9 to 3
move 1 from 7 to 5
move 1 from 3 to 8
move 3 from 2 to 7
move 1 from 8 to 9
move 3 from 3 to 6
move 21 from 4 to 9
move 1 from 5 to 7
move 4 from 4 to 9
move 8 from 6 to 3
move 6 from 7 to 1
move 12 from 9 to 8
move 6 from 7 to 2
move 3 from 6 to 5
move 1 from 6 to 9
move 4 from 8 to 6
move 3 from 8 to 5
move 4 from 1 to 8
move 4 from 6 to 1
move 2 from 1 to 3
move 1 from 5 to 8
move 2 from 2 to 8
move 5 from 8 to 3
move 4 from 2 to 7
move 5 from 8 to 1
move 2 from 1 to 7
move 1 from 8 to 2
move 2 from 1 to 7
move 11 from 9 to 2
move 1 from 8 to 5
move 2 from 9 to 4
move 3 from 9 to 5
move 2 from 5 to 1
move 6 from 5 to 8
move 2 from 4 to 2
move 1 from 5 to 6
move 7 from 1 to 8
move 2 from 2 to 7
move 13 from 8 to 1
move 16 from 3 to 1
move 3 from 2 to 1
move 12 from 7 to 6
move 15 from 1 to 8
move 2 from 3 to 8
move 16 from 1 to 2
move 24 from 2 to 8
move 1 from 1 to 5
move 1 from 5 to 8
move 3 from 6 to 7
move 26 from 8 to 3
move 20 from 3 to 9
move 1 from 2 to 9
move 16 from 9 to 3
move 14 from 3 to 1
move 13 from 1 to 6
move 3 from 3 to 4
move 3 from 9 to 4
move 1 from 7 to 8
move 5 from 8 to 2
move 8 from 8 to 5
move 18 from 6 to 1
move 4 from 8 to 5
move 6 from 4 to 1
move 2 from 2 to 5
move 5 from 3 to 8
move 5 from 8 to 7
move 2 from 5 to 8
move 5 from 5 to 4
move 3 from 2 to 8
move 22 from 1 to 2
move 1 from 1 to 2
move 5 from 8 to 2
move 2 from 5 to 2
move 1 from 1 to 6
move 5 from 5 to 2
move 1 from 9 to 8
move 5 from 4 to 1
move 6 from 6 to 9
move 3 from 1 to 9
move 1 from 1 to 7
move 8 from 9 to 6
move 6 from 7 to 1
move 5 from 6 to 5
move 27 from 2 to 1
move 4 from 5 to 7
move 9 from 1 to 5
move 1 from 9 to 1
move 3 from 6 to 2
move 9 from 2 to 1
move 2 from 7 to 2
move 1 from 8 to 7
move 10 from 5 to 9
move 1 from 9 to 7
move 25 from 1 to 8
move 6 from 7 to 4
move 11 from 1 to 7
move 3 from 8 to 1
move 3 from 2 to 6
move 3 from 8 to 9
move 11 from 8 to 6
move 1 from 2 to 6
move 12 from 6 to 4
move 13 from 4 to 5
move 1 from 6 to 1
move 3 from 7 to 5
move 5 from 8 to 7
move 1 from 7 to 1
move 5 from 1 to 6
move 3 from 6 to 4
move 3 from 8 to 6
move 2 from 5 to 2
move 12 from 5 to 9
move 5 from 6 to 2
move 2 from 5 to 9
move 6 from 4 to 9
move 11 from 7 to 3
move 1 from 2 to 5
move 1 from 7 to 8
move 1 from 5 to 7
move 1 from 7 to 1
move 1 from 8 to 1
move 2 from 4 to 7
move 2 from 6 to 8
move 5 from 3 to 6
move 2 from 7 to 2
move 2 from 2 to 9
move 1 from 2 to 9
move 1 from 1 to 6
move 35 from 9 to 7
move 2 from 8 to 7
move 3 from 3 to 8
move 5 from 2 to 4
move 3 from 3 to 7
move 2 from 4 to 7
move 4 from 6 to 5
move 4 from 5 to 9
move 3 from 4 to 5
move 1 from 8 to 3
move 4 from 9 to 8
move 1 from 9 to 6
move 38 from 7 to 2
move 1 from 3 to 5
move 1 from 1 to 7
move 4 from 7 to 3
move 3 from 6 to 1
move 22 from 2 to 7
move 1 from 5 to 8
move 7 from 8 to 4
move 8 from 2 to 8
move 3 from 5 to 1
move 4 from 3 to 9
move 1 from 8 to 3
move 1 from 3 to 7
move 2 from 2 to 3
move 5 from 8 to 9
move 3 from 9 to 1
move 2 from 1 to 7
move 6 from 2 to 3
move 6 from 3 to 1
move 2 from 3 to 6
move 1 from 6 to 1
move 14 from 7 to 2
move 4 from 1 to 6
move 8 from 1 to 3
move 4 from 3 to 6
move 3 from 9 to 5
move 1 from 8 to 6
move 1 from 8 to 4
move 9 from 7 to 1
move 8 from 2 to 4
move 4 from 2 to 9
move 2 from 2 to 1
move 3 from 5 to 8
move 1 from 8 to 6
move 1 from 7 to 8
move 1 from 6 to 5
move 3 from 9 to 5
move 2 from 9 to 5
move 4 from 3 to 9
move 3 from 6 to 3
move 3 from 6 to 9
move 9 from 4 to 1
move 1 from 9 to 8
move 3 from 3 to 6
move 2 from 7 to 4
move 4 from 8 to 5
move 7 from 5 to 6
move 19 from 1 to 9
move 5 from 9 to 3
move 2 from 1 to 6
move 1 from 4 to 6
move 4 from 3 to 2
move 21 from 9 to 7
move 1 from 1 to 2
move 1 from 9 to 1
move 1 from 1 to 8
move 16 from 7 to 6
move 24 from 6 to 5
move 7 from 4 to 5
move 1 from 8 to 3
move 2 from 2 to 8
move 31 from 5 to 8
move 1 from 4 to 6
move 2 from 6 to 9
move 1 from 7 to 4
move 3 from 7 to 9
move 1 from 4 to 8
move 2 from 3 to 5
move 1 from 2 to 3
move 1 from 3 to 7
move 1 from 7 to 9
move 24 from 8 to 6
move 1 from 8 to 1
move 30 from 6 to 1
move 2 from 5 to 2
move 1 from 6 to 9
move 6 from 9 to 7
move 1 from 6 to 4
move 1 from 4 to 6
move 23 from 1 to 3
move 21 from 3 to 4
move 4 from 2 to 6
move 3 from 6 to 1
move 1 from 5 to 1
move 4 from 1 to 9
move 3 from 9 to 6
move 8 from 1 to 6
move 4 from 8 to 5
move 2 from 7 to 5
move 7 from 4 to 3
move 3 from 4 to 9
move 9 from 3 to 9
move 1 from 7 to 6
move 6 from 5 to 8
move 14 from 6 to 2
move 4 from 8 to 4
move 7 from 4 to 5
move 1 from 7 to 9
move 6 from 4 to 3
move 13 from 2 to 6
move 5 from 3 to 7
move 1 from 3 to 8
move 1 from 8 to 2
move 4 from 8 to 3
move 6 from 6 to 4
move 2 from 2 to 8
move 5 from 4 to 7
move 3 from 7 to 5
move 1 from 7 to 9
move 2 from 3 to 9
move 3 from 7 to 3
move 1 from 7 to 9
move 1 from 7 to 9
move 3 from 4 to 1
move 6 from 6 to 1
move 2 from 7 to 5
move 1 from 3 to 5
move 11 from 9 to 4
move 9 from 4 to 5
move 3 from 3 to 4
move 1 from 3 to 9
move 2 from 8 to 1
move 9 from 1 to 8
move 22 from 5 to 8
move 2 from 1 to 3
move 3 from 4 to 6
move 14 from 8 to 9
move 1 from 3 to 9
move 19 from 9 to 3
move 3 from 9 to 4
move 2 from 7 to 2
move 1 from 4 to 6
move 1 from 3 to 8
move 8 from 3 to 1
move 2 from 9 to 6
move 1 from 2 to 5
move 3 from 4 to 9
move 1 from 2 to 3
move 20 from 8 to 3
move 4 from 9 to 5
move 1 from 4 to 2
move 26 from 3 to 5
move 1 from 8 to 3
move 8 from 1 to 4
move 1 from 3 to 7
move 1 from 2 to 1
move 1 from 1 to 6
move 1 from 6 to 7
move 4 from 5 to 3
move 3 from 4 to 2
move 5 from 5 to 3
move 2 from 2 to 6
move 3 from 3 to 5
move 2 from 4 to 8
move 5 from 3 to 9
move 5 from 9 to 8
move 19 from 5 to 9
move 1 from 5 to 2
move 2 from 7 to 1
move 1 from 1 to 7
move 1 from 7 to 4
move 13 from 9 to 3
move 8 from 6 to 2
move 10 from 3 to 5
move 14 from 5 to 4
move 7 from 8 to 4
move 1 from 6 to 2
move 6 from 3 to 8
move 4 from 9 to 7
move 2 from 9 to 8
move 1 from 7 to 1
move 3 from 2 to 7
move 1 from 5 to 3
move 7 from 8 to 6
move 5 from 6 to 2
move 8 from 4 to 5
move 3 from 5 to 8
move 3 from 8 to 6
move 5 from 7 to 9
move 5 from 3 to 6
move 1 from 9 to 4
move 17 from 4 to 7
move 1 from 8 to 1
move 12 from 7 to 8
move 3 from 1 to 4
move 2 from 4 to 6
move 8 from 6 to 1
move 4 from 6 to 3
move 1 from 7 to 8
move 5 from 5 to 8
move 4 from 7 to 1
move 3 from 2 to 6
move 2 from 5 to 1
move 6 from 1 to 6
move 4 from 3 to 5
move 4 from 5 to 3
move 1 from 4 to 8
move 3 from 3 to 2
move 17 from 8 to 4
move 6 from 6 to 3
move 14 from 4 to 9
move 1 from 3 to 8
move 1 from 7 to 4
move 3 from 8 to 3
move 5 from 2 to 5
move 6 from 1 to 7
move 2 from 6 to 4
move 4 from 5 to 7
move 1 from 1 to 5
move 1 from 6 to 3
move 10 from 7 to 4
move 1 from 5 to 4
move 1 from 2 to 3
move 15 from 4 to 5
move 3 from 3 to 1
move 6 from 2 to 6
move 1 from 2 to 3
move 2 from 4 to 7
move 2 from 7 to 8
move 1 from 4 to 2
move 2 from 1 to 7
move 1 from 7 to 2
move 12 from 9 to 1
move 4 from 9 to 5
move 4 from 6 to 2
move 1 from 7 to 3
move 6 from 2 to 4
move 1 from 8 to 5
move 2 from 4 to 2
move 11 from 1 to 7
move 3 from 1 to 4
move 17 from 5 to 6
move 15 from 6 to 4
move 1 from 8 to 9
move 10 from 4 to 1
move 1 from 3 to 9
move 2 from 6 to 5
move 1 from 2 to 6
move 4 from 5 to 6
move 4 from 1 to 2
move 6 from 6 to 7
move 2 from 2 to 6
move 9 from 4 to 9
move 6 from 1 to 2
move 3 from 4 to 1
move 10 from 9 to 8
move 4 from 2 to 1
move 1 from 1 to 2
move 5 from 8 to 6
move 1 from 2 to 7
move 1 from 9 to 4
move 2 from 6 to 9
move 13 from 7 to 2
move 5 from 7 to 5
move 2 from 5 to 2
move 1 from 4 to 5
move 4 from 8 to 4
move 17 from 2 to 6
move 3 from 4 to 6
move 2 from 9 to 1
move 7 from 6 to 8
move 1 from 5 to 2
move 1 from 4 to 1
move 2 from 9 to 4
move 1 from 3 to 9
move 4 from 3 to 7
move 2 from 8 to 5
move 3 from 7 to 5
move 10 from 5 to 8
move 2 from 2 to 4
move 6 from 1 to 2
move 4 from 6 to 3
move 8 from 2 to 6
move 1 from 7 to 4
move 5 from 4 to 5
move 7 from 6 to 7
move 5 from 3 to 5
move 5 from 5 to 2
move 4 from 8 to 1
move 6 from 1 to 6
move 3 from 3 to 2
move 22 from 6 to 2
move 1 from 9 to 7
move 8 from 8 to 6
move 1 from 7 to 6
move 2 from 5 to 7
move 4 from 8 to 5
move 7 from 6 to 7
move 2 from 6 to 4
move 14 from 2 to 1
move 7 from 1 to 3
move 12 from 7 to 3
move 1 from 4 to 3
move 2 from 5 to 8
move 2 from 8 to 1
move 1 from 4 to 3
move 6 from 2 to 9
move 6 from 9 to 2
move 2 from 2 to 7
move 6 from 7 to 5
move 13 from 3 to 5
move 5 from 2 to 6
move 5 from 6 to 1
move 2 from 3 to 6
move 1 from 6 to 5
move 1 from 6 to 1
move 3 from 1 to 9
move 6 from 2 to 7
move 1 from 2 to 3
move 24 from 5 to 2
move 7 from 3 to 7
move 13 from 7 to 9
move 4 from 1 to 9
move 4 from 1 to 6
move 1 from 5 to 6
move 16 from 9 to 5
move 1 from 6 to 4
move 1 from 5 to 2
move 5 from 1 to 3
move 11 from 2 to 1
move 4 from 9 to 6
move 1 from 4 to 7
move 2 from 3 to 4
move 6 from 6 to 9
move 1 from 1 to 3
move 2 from 9 to 4
move 1 from 7 to 9
move 4 from 2 to 9
move 8 from 9 to 2
move 3 from 3 to 2
move 1 from 9 to 4
move 5 from 1 to 7
move 1 from 4 to 8
move 2 from 1 to 9
move 1 from 8 to 7
move 6 from 5 to 3
move 1 from 5 to 1
move 5 from 2 to 3
move 4 from 1 to 5
move 4 from 7 to 1
move 8 from 5 to 8
""";
}
