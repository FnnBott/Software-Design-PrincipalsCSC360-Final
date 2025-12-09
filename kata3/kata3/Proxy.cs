namespace Kata3;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Proxy
{
    private interface IPermutationGenerator
    {
        IEnumerable<List<T>> GetPermutations<T>(List<T> list, int length);
    }
    
    private class PermutationGenerator : IPermutationGenerator
    {
        public IEnumerable<List<T>> GetPermutations<T>(List<T> list, int length)
        {
            Console.WriteLine($"[RealSubject] Computing permutations for length {length}...");
            
            if (length == 1)
                return list.Select(t => new List<T> { t });
    
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => new List<T>(t1) { t2 });
        }
    }
    
    private class CachingPermutationProxy : IPermutationGenerator
    {
        private readonly IPermutationGenerator _realGenerator;
        private readonly Dictionary<string, object> _cache;
    
        public CachingPermutationProxy(IPermutationGenerator realGenerator)
        {
            _realGenerator = realGenerator;
            _cache = new Dictionary<string, object>();
        }
    
        public IEnumerable<List<T>> GetPermutations<T>(List<T> list, int length)
        {
            // Create a cache key based on list contents and length
            string cacheKey = $"{string.Join(",", list)}_{length}";
    
            if (_cache.ContainsKey(cacheKey))
            {
                Console.WriteLine($"[Proxy] Cache HIT! Returning cached permutations.");
                return (IEnumerable<List<T>>)_cache[cacheKey];
            }
    
            Console.WriteLine($"[Proxy] Cache MISS. Delegating to real generator...");
            var result = _realGenerator.GetPermutations(list, length).ToList();
            _cache[cacheKey] = result;
            
            return result;
        }
    }
    public void RunWithoutProxy()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        var generator = new PermutationGenerator();
        long count = FactorialSquaredAlgorithm(elements, generator);
        
        stopwatch.Stop();
        Console.WriteLine($"\nTotal operations: {count}");
        Console.WriteLine($"Time: {stopwatch.Elapsed}");
    }
    public void RunWithProxy()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        var realGenerator = new PermutationGenerator();
        var proxy = new CachingPermutationProxy(realGenerator);
        long count = FactorialSquaredAlgorithm(elements, proxy);
        
        stopwatch.Stop();
        Console.WriteLine($"\nTotal operations: {count}");
        Console.WriteLine($"Time: {stopwatch.Elapsed}");
    }
    static long FactorialSquaredAlgorithm(List<int> elements, IPermutationGenerator generator)
    {
        var perms1 = generator.GetPermutations(elements, elements.Count).ToList();
        var perms2 = generator.GetPermutations(elements, elements.Count).ToList();
        long count = 0;
        foreach (var p1 in perms1)
        {
            foreach (var p2 in perms2)
            {
                count++;
            }
        }
        return count;
    }
}