using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\Lungelo\\source\\repos\\Day3_part1\\Day3_part2\\Input.txt";
        string[] lines = File.ReadAllLines(filePath);

        int ans = 0;
        List<(int, int)> gears = new List<(int, int)>();
        List<(string, List<(int, int)>)> numbers = new List<(string, List<(int, int)>)>();

        // Identify gears
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (lines[i][j] == '*')
                {
                    gears.Add((i, j));
                }
            }
        }

        // Identify numbers
        string k = string.Empty;
        List<(int, int)> pos = new List<(int, int)>();

        for (int i = 0; i < lines.Length; i++)
        {
            if (k != string.Empty)
            {
                numbers.Add((k, new List<(int, int)>(pos)));
                k = string.Empty;
                pos.Clear();
            }
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (k != string.Empty && !char.IsDigit(lines[i][j]))
                {
                    numbers.Add((k, new List<(int, int)>(pos)));
                    k = string.Empty;
                    pos.Clear();
                }
                if (char.IsDigit(lines[i][j]))
                {
                    k += lines[i][j];
                    pos.Add((i, j));
                }
            }
        }

        // Check adjacencies and calculate gear ratios
        foreach (var gear in gears)
        {
            List<int> x = CheckAdjacencies(gear.Item1, gear.Item2, numbers);
            if (x.Count == 2)
            {
                ans += x[0] * x[1];
            }
        }

        Console.WriteLine(ans);
    }

    static List<int> CheckAdjacencies(int xg, int yg, List<(string, List<(int, int)>)> numbers)
    {
        List<int> tmp = new List<int>();
        List<(int, int)> adjs = new List<(int, int)>
        {
            (-1, -1), (0, -1), (1, -1),
            (-1, 0),          (1, 0),
            (-1, 1), (0, 1),  (1, 1)
        };

        foreach (var number in numbers)
        {
            foreach (var pos in adjs)
            {
                if (number.Item2.Contains((xg + pos.Item1, yg + pos.Item2)))
                {
                    tmp.Add(int.Parse(number.Item1));
                    break;
                }
            }
        }

        return tmp;
    }
}
