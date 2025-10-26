using OpenQA.Selenium;
using FDAutomationProject.Drivers;
using FDAutomationProject.Tests;
using FDAutomationProject.Utilities;

namespace FDAutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShowMainMenu();
            }
            catch (Exception ex)
            {
                Reporter.LogError($"Framework Error: {ex.Message}");
            }
            finally
            {
                PrintColoredSummary();
            }
        }

        private static void ShowMainMenu()
        {
            var categories = new Dictionary<int, string>
            {
                { 1, "Personal Loan Test" },
                { 2, "Home Loan Test" },
                { 3, "FD Calculator Test" },
                { 4, "Credit Card Test" }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("      FUNCTIONAL TEST CATEGORY SELECTION");
                Console.WriteLine("=============================================");
                foreach (var kvp in categories)
                    Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                Console.WriteLine("5. Exit Test Runner");
                Console.WriteLine("=============================================");

                int choice = GetInt("Enter your choice (1-5): ");

                if (choice == 5)
                {
                    Console.WriteLine("\nExiting Test Runner. Goodbye!");
                    break;
                }

                if (categories.TryGetValue(choice, out string category))
                    ShowSubMenu(category);
                else
                    ShowError("Invalid choice. Please try again.");
            }
        }

        private static void ShowSubMenu(string category)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=============================================");
                Console.WriteLine($"      {category} - TEST EXECUTION MODE");
                Console.WriteLine($"=============================================");
                Console.WriteLine("1. Run All Tests");
                Console.WriteLine("2. Run By Manual Value Input");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine("=============================================");

                int mode = GetInt("Enter your choice (1-3): ");
                if (mode == 3) break;

                switch (mode)
                {
                    case 1:
                        ExecuteTests(category, "RunAllTest");
                        break;
                    case 2:
                        ExecuteTests(category, "RunByManualValuePut");
                        break;
                    default:
                        ShowError("Invalid mode. Try again.");
                        break;
                }
            }
        }

        private static void ExecuteTests(string category, string mode)
        {
            Console.Clear();
            Console.WriteLine($"--- EXECUTING {category} in {mode} mode ---\n");

            IWebDriver driver = null;
            try
            {
                if (category.Contains("Personal Loan"))
                {
                    driver = InitDriver("https://www.axisbank.com/retail/calculators/personal-loan-emi-calculator?cta=calculator-life-goal-card1");
                    var test = new PLTest(driver);
                    if (mode == "RunAllTest")
                        test.RunAllTests();
                    else
                        RunPersonalLoanManual(test);
                }
                else if (category.Contains("Home Loan"))
                {
                    driver = InitDriver("https://www.axisbank.com/retail/calculators/home-loan-emi-calculator?cta=calculator-life-goal-card2");
                    var test = new HLTest(driver);
                    if (mode == "RunAllTest")
                        test.RunAllTests();
                    else
                        RunHomeLoanManual(test);
                }
                else if (category.Contains("FD Calculator"))
                {
                    driver = InitDriver("https://www.axisbank.com/retail/calculators/fd-calculator?cta=calculators-life-goal-card3");
                    var test = new FDTests(driver);
                    if (mode == "RunAllTest")
                        test.RunAllTests();
                    else
                        RunFDManual(test);
                }
                else if (category.Contains("Credit Card"))
                {
                    Console.WriteLine("[INFO] Credit Card test logic pending...");
                }

                PrintColoredSummary();
            }
            catch (Exception ex)
            {
                ShowError($"Execution failed: {ex.Message}");
            }
            finally
            {
                driver?.Quit();
                Console.WriteLine("\n[Execution Complete] Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        #region Manual Input Handlers
        private static void RunPersonalLoanManual(PLTest test)
        {
            Console.WriteLine("=== Enter Loan Details ===");
            var loan = GetDecimal("Loan Amount: ").ToString("F2");
            var rate = GetDecimal("Interest Rate (%): ").ToString("F2");
            var tenure = GetInt("Tenure (months): ").ToString();
            var expectedEMI = GetString("Expected EMI: ");
            test.RunTestFromUserDefineValue(loan, rate, tenure, expectedEMI);
        }

        private static void RunHomeLoanManual(HLTest test)
        {
            Console.WriteLine("=== Enter Home Loan Details ===");
            var loan = GetDecimal("Loan Amount: ").ToString("F2");
            var rate = GetDecimal("Interest Rate (%): ").ToString("F2");
            var tenure = GetInt("Tenure (years): ").ToString();
            var expectedEMI = GetString("Expected EMI: ");
            test.RunTestFromUserDefineValue(loan, rate, tenure, expectedEMI);
        }

        private static void RunFDManual(FDTests test)
        {
            Console.WriteLine("=== Enter FD Details ===");
            var toc = GetString("Type Of Customer (se/no): ");
            var ipt = GetString("Interest Payout Type (re/qu/mo/sh): ");
            var ad = GetString("Amount Deposited: ");
            var years = GetString("Years (1-10): ");
            var months = GetString("Months (1-11): ");
            var days = GetString("Days: ");
            // test.Test_002_TestFromPredefinedValue(toc, ipt, ad, years, months, days);
        }
        #endregion

        #region Helpers
        private static IWebDriver InitDriver(string url)
        {
            var driver = WebDriverFactory.GetDriver("Chrome");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        private static int GetInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val) && val > 0)
                    return val;
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

        private static decimal GetDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal val) && val > 0)
                    return val;
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

        private static string GetString(string prompt, bool allowEmpty = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim();
                if (!allowEmpty && string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }
                return input!;
            }
        }

        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR: {message}");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static void PrintColoredSummary()
        {
            Console.WriteLine("\n================ TEST SUMMARY ================");
            int passCount = Reporter.PassCount;
            int failCount = Reporter.FailCount;
            int skippedCount = Reporter.SkippedCount;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"PASSED: {passCount}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"FAILED: {failCount}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"SKIPPED/ERROR: {skippedCount}");
            Console.ResetColor();

            Console.WriteLine("==============================================\n");
        }
        #endregion
    }
}
