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
                // 1. Setup: Initialize WebDriver
                driver = WebDriverFactory.GetDriver("Chrome"); // Custom method to setup Chrome/Edge
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.axisbank.com/retail/calculators/fd-calculator?cta=calculators-life-goal-card3");

                // 2. Execution: Run the tests
                FDTests tests = new FDTests(driver);
                tests.RunAllTests(); // Calls all the defined test methods
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
    }
}