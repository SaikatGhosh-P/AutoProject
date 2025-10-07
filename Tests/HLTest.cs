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

        public void RunTestFromUserDefineValue(string UILoanAmt, string UIInterestRate, string UITenure, string UIExpectedEMI)
        {
            _hlPage.ReadPageHeader("Home Loan", "Home Loan");
            Thread.Sleep(2000);

            _hlPage.CookieAcceptClick();
            Thread.Sleep(3000);

            _hlPage.ScrollByPixel(0, 50);

            _hlPage.SetPLoanParameters(UILoanAmt, UIInterestRate, UITenure, UIExpectedEMI);

            decimal lnAmt = Convert.ToDecimal(UILoanAmt);
            decimal IntRate = Convert.ToDecimal(UIInterestRate);
            decimal ten = Convert.ToDecimal(UITenure);

            Thread.Sleep(2000);
            _hlPage.DataInputinLoanAmount(lnAmt);

            Thread.Sleep(2000);
            _hlPage.DataInputinInterestRate(IntRate);

            Thread.Sleep(2000);
            _hlPage.DataInputinTenure(ten);

            string expEMi = _hlPage.ExpectedEMI(UIExpectedEMI);

            string emi = _hlPage.getEMIfromUI();

            if (expEMi == emi)
            {
                Reporter.LogPass("Both Generated and expected EMI are same!");
            }


        }

        public void RunAllTests()
        {
            Test_001_TestFromPredefinedValue();
            //Test_002_MinimumAmountValidation();
            // ... Call all other test methods here
        }

        public void Test_001_TestFromPredefinedValue()
        {
            _hlPage.ReadPageHeader("Home Loan", "Home Loan");
            Thread.Sleep(2000);

            _hlPage.CookieAcceptClick();

            Thread.Sleep(3000);

            _hlPage.ScrollByPixel(0, 50);

            _hlPage.DataInputinLoanAmount(1000000);

            _hlPage.DataInputinInterestRate(9);

            _hlPage.DataInputinTenure(30);

            string expEMi = _hlPage.ExpectedEMI("8,046");

            string emi = _hlPage.getEMIfromUI();

            if (expEMi == emi)
            {
                Reporter.LogPass("Both Generated and expected EMI are same!");
            }
        }
    }
}
