using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDAutomationProject.Utilities
{
    public class Reporter
    {
        private static int PassCount = 0;
        private static int FailCount = 0;

        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[INFO] {message}");
        }

        public static void LogInfoError(string message)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[InfoError] {message}");
            // Optionally take a screenshot here
        }

        public static void LogPass(string message)
        {
            PassCount++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[PASS] {message}");
        }

        public static void LogFail(string message)
        {
            FailCount++;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FAIL] {message}");
            // Optionally take a screenshot here
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ERROR] {message}");
        }

        public static void PrintSummary()
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine($"TEST EXECUTION COMPLETE");
            Console.WriteLine($"Total Passed: {PassCount}");
            Console.WriteLine($"Total Failed: {FailCount}");
            Console.WriteLine("=================================");
            Console.ResetColor();
        }
    }
}
