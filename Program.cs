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
            IWebDriver driver = null;

            try
            {
                RunMainMenu();
                
            }
            catch (Exception ex)
            {
                Reporter.LogError($"Framework Error: {ex.Message}");
            }
            finally
            {
                // 3. Teardown: Close WebDriver
                if (driver != null)
                {
                    driver.Quit();
                }
            }

            Reporter.PrintSummary(); // Custom method to display PASS/FAIL count
        }

        private static void RunMainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("    FUNCTIONAL TEST CATEGORY SELECTION");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Personal Loan Test");
                Console.WriteLine("2. Home Loan Test");
                Console.WriteLine("3. FD Calculator Test");
                Console.WriteLine("4. Credit Card Test");
                Console.WriteLine("5. Exit Test Runner");
                Console.WriteLine("=============================================");
                Console.Write("Enter your choice (1-5): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            RunSubMenu(choice);
                            break;
                        case 5:
                            isRunning = false;
                            Console.WriteLine("\nExiting Test Runner. Goodbye!");
                            break;
                        default:
                            DisplayError("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    DisplayError("Invalid input. Please enter a number.");
                }
            }
        }

        private static void RunSubMenu(int testCategory)
        {
            string categoryName = GetCategoryName(testCategory);
            bool returnToMain = false;

            while (!returnToMain)
            {
                Console.Clear();
                Console.WriteLine($"=============================================");
                Console.WriteLine($"    {categoryName} - TEST EXECUTION MODE");
                Console.WriteLine($"=============================================");
                Console.WriteLine("1. Run All Tests (RunAllTest)");
                Console.WriteLine("2. Run By Manual Value Put (RunByManualValuePut)");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine("=============================================");
                Console.Write("Enter your choice (1-3): ");

                if (int.TryParse(Console.ReadLine(), out int modeChoice))
                {
                    switch (modeChoice)
                    {
                        case 1:
                            ExecuteTests(categoryName, "RunAllTest");
                            break;
                        case 2:
                            ExecuteTests(categoryName, "RunByManualValuePut");
                            break;
                        case 3:
                            returnToMain = true; // Exit submenu loop, return to main menu
                            break;
                        default:
                            DisplayError("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    DisplayError("Invalid input. Please enter a number.");
                }
            }
        }

        private static string GetCategoryName(int choice)
        {
            return choice switch
            {
                1 => "Personal Loan Test",
                2 => "Home Loan Test",
                3 => "FD Calculator Test",
                4 => "Credit Card Test",
                _ => "Unknown Test Category"
            };
        }

        private static void ExecuteTests(string category, string mode)
        {
            Console.Clear();
            Console.WriteLine($"\n--- EXECUTING TESTS ---");
            Console.WriteLine($"Category: {category}");
            Console.WriteLine($"Mode: {mode}");

            // --- TEST EXECUTION LOGIC GOES HERE ---
            // In a real application, you would use a test runner library (like NUnit Console Runner) 
            // or directly call the methods from your test class (EmiCalculatorTests).

            if (category == "Personal Loan Test" && mode == "RunAllTest")
            {
                Console.WriteLine("Executing all defined Personal Loan EMI tests (e.g., BVA_001, BVA_002, CAL_001)...");
                // Example of how to call a specific test if it were in a non-NUnit class:
                // var runner = new EmiCalculatorTests();
                // runner.BVA_001_VerifyMinimumLoanAmountCalculation();
            }
            else if (category == "Personal Loan Test" && mode == "RunByManualValuePut")
            {
                Console.WriteLine("Executing specific test scenario by accepting manual inputs...");
                // Example: Prompt user for Loan Amount, Rate, and Tenure here.
            }
            else if (category == "Home Loan Test" && mode == "RunAllTest")
            {
                IWebDriver driver = null;
                driver = WebDriverFactory.GetDriver("Chrome"); // Custom method to setup Chrome/Edge
                driver.Manage().Window.Maximize();
                //driver.Navigate().GoToUrl("https://www.axisbank.com/retail/calculators/fd-calculator?cta=calculators-life-goal-card3");
                driver.Navigate().GoToUrl("https://www.axisbank.com/retail/calculators/home-loan-emi-calculator?cta=calculator-life-goal-card2");

                // 2. Execution: Run the tests
                //FDTests tests = new FDTests(driver);
                HLTest tests = new HLTest(driver);
                tests.RunAllTests();
            }
            else if (category == "Home Loan Test" && mode == "RunByManualValuePut")
            {
                Console.WriteLine("Executing specific test scenario by accepting manual inputs...");
                // Example: Prompt user for Loan Amount, Rate, and Tenure here.
            }
            else if (category == "FD Calculator Test" && mode == "RunAllTest")
            {
                Console.WriteLine("Executing all defined Personal Loan EMI tests (e.g., BVA_001, BVA_002, CAL_001)...");
                // Example of how to call a specific test if it were in a non-NUnit class:
                // var runner = new EmiCalculatorTests();
                // runner.BVA_001_VerifyMinimumLoanAmountCalculation();
            }
            else if (category == "FD Calculator Test" && mode == "RunByManualValuePut")
            {
                Console.WriteLine("Executing specific test scenario by accepting manual inputs...");
                // Example: Prompt user for Loan Amount, Rate, and Tenure here.
            }
            else if (category == "Credit Card Test" && mode == "RunAllTest")
            {
                Console.WriteLine("Executing all defined Personal Loan EMI tests (e.g., BVA_001, BVA_002, CAL_001)...");
                // Example of how to call a specific test if it were in a non-NUnit class:
                // var runner = new EmiCalculatorTests();
                // runner.BVA_001_VerifyMinimumLoanAmountCalculation();
            }
            else if (category == "Credit Card Test" && mode == "RunByManualValuePut")
            {
                Console.WriteLine("Executing specific test scenario by accepting manual inputs...");
                // Example: Prompt user for Loan Amount, Rate, and Tenure here.
            }
            else
            {
                Console.WriteLine($"[MOCK] Test execution logic for {category} in {mode} mode is pending...");
            }

            Console.WriteLine("\n[Execution Complete] Press any key to continue to the submenu...");
            Console.ReadKey(true);
        }

        private static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR: {message}");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey(true);
        }
    }
}