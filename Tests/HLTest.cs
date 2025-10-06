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
    public class HLTest
    {
        private IWebDriver _driver;
        private HLCalculatorPage _hlPage;

        public HLTest(IWebDriver driver)
        {
            _driver = driver;
            _hlPage = new HLCalculatorPage(driver);
        }


        public void RunAllTests()
        {
            Test_001_SeniorCitizenRateChange();
            //Test_002_MinimumAmountValidation();
            // ... Call all other test methods here
        }

        public void Test_001_SeniorCitizenRateChange()
        {
            _hlPage.ReadPageHeader("Home Loan");
            _hlPage.CookieAcceptClick();

            _hlPage.DataInputinInterestRate(1000000);

            _hlPage.DataInputinInterestRate(9);

            _hlPage.DataInputinTenure(30);

            string expEMi = _hlPage.ExpectedEMI("8,046");

            string emi = _hlPage.getEMIfromUI();

            if (expEMi.Equals(emi))
            {
                Reporter.LogPass("Both Generated and expected EMI are same!");
            }
        }
    }
}
