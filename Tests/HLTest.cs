using FDAutomationProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDAutomationProject.Tests
{
    public class HLTest
    {
        private IWebDriver _driver;
        private FDCalculatorPage _fdPage;

        public HLTest(IWebDriver driver)
        {
            _driver = driver;
            _fdPage = new FDCalculatorPage(driver);
        }


        public void RunAllTests()
        {
            Test_001_SeniorCitizenRateChange();
            //Test_002_MinimumAmountValidation();
            // ... Call all other test methods here
        }

        public void Test_001_SeniorCitizenRateChange()
        {

        }
    }
}
