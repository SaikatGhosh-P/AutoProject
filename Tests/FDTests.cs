using FDAutomationProject.Pages;
using FDAutomationProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDAutomationProject.Tests
{
    public class FDTests
    {
        private IWebDriver _driver;
        private FDCalculatorPage _fdPage;

        public FDTests(IWebDriver driver)
        {
            _driver = driver;
            _fdPage = new FDCalculatorPage(driver);
        }


        public void RunAllTests()
        {
            Test_001_SeniorCitizenRateChange();
            Test_002_MinimumAmountValidation();
            // ... Call all other test methods here
        }

        // Test Case TC_FD_001 equivalent
        public void Test_001_SeniorCitizenRateChange()
        {
            Reporter.LogInfo("Starting Test 001: Verify Senior Citizen Rate Increase.");

            try
            {
                //Thread.Sleep(3000);
                //_fdPage.ScrollByPixel(0, -500);

                Thread.Sleep(3000);
                _fdPage.CookieAcceptClick();

                //Thread.Sleep(3000);
                _fdPage.ScrollByPixel(0, 400);
                //_fdPage.ForceClick(_driver, _driver.FindElement(By.XPath(".//label[text()='Normal']/preceding::input[@id='radio1']")));

                Thread.Sleep(3000);
                // Pre-condition: Get base rate (Normal)
                string baseRate = _fdPage.GetInterestRate();

                Thread.Sleep(5000);
                // Step 1: Click on the Senior Citizen radio button.
                _fdPage.SelectCustomerType("senior citizen");
                //_fdPage.clickonSenior();

                Thread.Sleep(5000);
                // Step 2: Get the new rate.
                string newRate = _fdPage.GetInterestRate();

                // Custom Assertion
                if (newRate != baseRate && newRate.Contains("3.50%"))
                {
                    Reporter.LogPass($"Test 001 Passed. Rate changed from {baseRate} to {newRate}.");
                }
                else
                {
                    Reporter.LogFail($"Test 001 Failed. Expected rate 3.50%, Actual rate {newRate}.");
                }
            }
            catch (Exception ex)
            {
                Reporter.LogError($"Test 001 Exception: {ex.Message}");
            }
        }

        public void Test_002_MinimumAmountValidation()
        {
            Reporter.LogInfo("Starting Test 002: Verify minimum deposit amount validation.");

            // ... implementation steps using _fdPage methods ...
            // e.g., _fdPage.SetDepositAmount("4999");
            // e.g., Read and check for the expected error message element.
        }
    }
}
