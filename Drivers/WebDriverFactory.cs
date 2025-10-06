using FDAutomationProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDAutomationProject.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetDriver(string browserName)
        {
            IWebDriver driver = null;
            string driverPath = GetDriverPath(); // Helper to determine the driver location

            Reporter.LogInfo($"Initializing WebDriver for browser: {browserName}...");

            try
            {
                switch (browserName.ToLower())
                {
                    case "chrome":
                        // Uses ChromeDriverService for configuration
                        var chromeService = ChromeDriverService.CreateDefaultService(driverPath);
                        var chromeOptions = new ChromeOptions();
                        // Optional: Add common options here (e.g., headless, incognito)
                        // chromeOptions.AddArguments("start-maximized"); 

                        driver = new ChromeDriver(chromeService, chromeOptions);
                        break;

                    case "edge":
                        // Uses EdgeDriverService for configuration
                        var edgeService = EdgeDriverService.CreateDefaultService(driverPath);
                        var edgeOptions = new EdgeOptions();
                        // Optional: Add common options here

                        driver = new EdgeDriver(edgeService, edgeOptions);
                        break;

                    default:
                        Reporter.LogError($"Browser '{browserName}' is not supported by the factory.");
                        throw new NotSupportedException($"Browser '{browserName}' is not supported.");
                }

                Reporter.LogInfo($"{browserName} WebDriver successfully initialized.");
                return driver;
            }
            catch (Exception ex)
            {
                Reporter.LogError($"Failed to initialize WebDriver: {ex.Message}");
                // This is a common location for driver-related issues (e.g., version mismatch)
                Reporter.LogError("HINT: Check if ChromeDriver/MSEdgeDriver packages are installed and up to date, or if the browser itself is installed.");
                throw; // Re-throw the exception to stop execution in Program.cs
            }
        }
        private static string GetDriverPath()
        {
            // When using NuGet packages like 'Selenium.WebDriver.ChromeDriver', 
            // the driver executable is usually copied to the project's output directory (e.g., bin/Debug/netcoreappX.Y).
            // We use Environment.CurrentDirectory to point to the correct folder.

            return Environment.CurrentDirectory;
        }
    }
}
