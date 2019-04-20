using System.Collections.Concurrent;
using System.Linq;

namespace Task.DontChange
{
    public static class Tracer
    {
        private static int clearCount = 0;
        private static readonly ConcurrentQueue<(string Key, int SpentMilliseconds)> logs = new ConcurrentQueue<(string Key, int SpentMilliseconds)>();

        public static void LogTrace(string key, int spentMilliseconds)
        {
            logs.Enqueue((key, spentMilliseconds));
        }

        public static (string Key, int SpentMilliseconds)[] GetLogs()
        {
            return logs.Skip(clearCount).ToArray();
        }

        public static void Clear()
        {
            clearCount = logs.Count;
        }
    }
}