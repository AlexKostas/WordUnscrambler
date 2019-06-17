using System;

namespace WordUnscrambler.Utils {
    public static class IOUtil {
        public static void Print(string message) {
            Console.WriteLine(message);
        }

        public static void Print(string message, object obj1, object obj2) {
            Console.WriteLine(message, obj1, obj2);
        }
        
        public static void LogError(string message) {
            Console.WriteLine(DateTime.Now + " " + message);
        }

        public static string GetLine() {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}