//Check this shit out :D
// Time Complexity = O(N!^2)

using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace Kata3;

class OriginalCode
{
    static void _ExampleMain()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }; 
        long count = FactorialSquaredAlgorithm(elements);
        stopwatch.Stop();
        Console.WriteLine($"Total operations: {count}" + '\n' + $"Time to complete: {stopwatch.Elapsed}");
    }

    static long FactorialSquaredAlgorithm(List<int> elements)
    {
        var perms1 = GetPermutations(elements, elements.Count).ToList();
        var perms2 = GetPermutations(elements, elements.Count).ToList();

        long count = 0;

        foreach (var p1 in perms1)
        {
            foreach (var p2 in perms2)
            {
                // Constant-time operation
                count++;
            }
        }

        return count;
    }

    static IEnumerable<List<T>> GetPermutations<T>(List<T> list, int length)
    {
        if (length == 1)
            return list.Select(t => new List<T> { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => new List<T>(t1) { t2 });
    }
}