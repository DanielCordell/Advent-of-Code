using System.Linq;
using System.Text;

public static class Program
{
    public static void Main()
    {
        var commands = input.Split(Environment.NewLine)
            .Select(x => x.Split(' '))
            .Select(x => Tuple.Create<string, int?>(x[0], x.Length == 1 ? null : int.Parse(x[1])));

        // Day1
        var day1 = commands.Aggregate((register: 1, cycle: 1, valueAt: new Dictionary<int, int>()), (prev, next) =>
        {
            (int newRegister, int newCycle) = PerformUpdate(prev.register, prev.cycle, next.Item1, next.Item2);
            if ((newCycle - 20) % 40 == 0)
                prev.valueAt[newCycle] = newRegister;
            else if ((newCycle - 20 - 1) % 40 == 0)
                prev.valueAt[newCycle - 1] = prev.register;

            (prev.register, prev.cycle) = (newRegister, newCycle);

            return prev;
        }).valueAt.Select(x => x.Key * x.Value).Sum();

        // Day2
        var day2 = commands.Aggregate((register: 1, cycle: 1, output: new StringBuilder()), (prev, next) =>
        {
            (int newRegister, int newCycle) = PerformUpdate(prev.register, prev.cycle, next.Item1, next.Item2);

            for (int i = prev.cycle; i < newCycle; i++)
            {
                if ((i - 1) % 40 >= prev.register - 1 && (i - 1) % 40 <= prev.register + 1)
                    prev.output.Append('#');
                else
                    prev.output.Append('.');
                if (i % 40 == 0) prev.output.AppendLine();
            }
            prev.register = newRegister;
            prev.cycle = newCycle;
            return prev;
        }).output.ToString();

        Console.WriteLine(day1);
        Console.WriteLine(day2);
    }

    private static (int, int) PerformUpdate(int register, int cycle, string command, int? registerInc = null)
    {
        return command switch
        {
            "noop" => (register, cycle + 1),
            "addx" when registerInc != null => (register + registerInc.Value, cycle + 2),
            _ => (register, 0)
        };
    }

    public static string test =
"""
addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop
""";

public static string input =
"""
noop
addx 5
noop
noop
noop
addx 1
addx 2
addx 5
addx 2
addx 5
noop
noop
noop
noop
noop
addx -12
addx 18
addx -1
noop
addx 3
addx 5
addx -5
addx 7
noop
addx -36
addx 18
addx -16
noop
noop
noop
addx 5
addx 2
addx 5
addx 2
addx 13
addx -6
addx -4
addx 5
addx 2
addx 4
addx -3
addx 2
noop
addx 3
addx 2
addx 5
addx -40
addx 25
addx -22
addx 25
addx -21
addx 5
addx 3
noop
addx 2
addx 19
addx -10
addx -4
noop
addx -4
addx 7
noop
addx 3
addx 2
addx 5
addx 2
addx -26
addx 27
addx -36
noop
noop
noop
noop
addx 4
addx 6
noop
addx 12
addx -11
addx 2
noop
noop
noop
addx 5
addx 5
addx 2
noop
noop
addx 1
addx 2
addx 5
addx 2
addx 1
noop
noop
addx -38
noop
addx 9
addx -4
noop
noop
addx 7
addx 10
addx -9
addx 2
noop
addx -9
addx 14
addx 5
addx 2
addx -24
addx 25
addx 2
addx 5
addx 2
addx -30
addx 31
addx -38
addx 7
noop
noop
noop
addx 1
addx 21
addx -16
addx 8
addx -4
addx 2
addx 3
noop
noop
addx 5
addx -2
addx 5
addx 3
addx -1
addx -1
addx 4
addx 5
addx -38
noop
""";
}
