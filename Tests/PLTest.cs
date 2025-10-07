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
    public class PLTest
    {
        private IWebDriver _driver;
        private PLCalculatorPage _PlPage;

        public PLTest(IWebDriver driver)
        {
            _driver = driver;
            _PlPage = new PLCalculatorPage(driver);
        }

        public void RunTestFromUserDefineValue(string UILoanAmt, string UIInterestRate, string UITenure, string UIExpectedEMI)
        {
            _PlPage.ReadPageHeader("Personal Loan", "Personal Loan");
            Thread.Sleep(2000);

            _PlPage.CookieAcceptClick();
            Thread.Sleep(3000);

            _PlPage.ScrollByPixel(0, 200);

            _PlPage.SetPLoanParameters(UILoanAmt, UIInterestRate, UITenure, UIExpectedEMI);

            decimal lnAmt = Convert.ToDecimal(UILoanAmt);
            decimal IntRate = Convert.ToDecimal(UIInterestRate);
            decimal ten = Convert.ToDecimal(UITenure);

            _PlPage.DataInputinLoanAmount(lnAmt);

            _PlPage.DataInputinInterestRate(IntRate);

            _PlPage.DataInputinTenure(ten);

            string expEMi = _PlPage.ExpectedEMI(UIExpectedEMI);

            string emi = _PlPage.getEMIfromUI();

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
            _PlPage.ReadPageHeader("Personal Loan", "Personal Loan");
            Thread.Sleep(2000);

            _PlPage.CookieAcceptClick();

            Thread.Sleep(3000);

            _PlPage.ScrollByPixel(0, 200);

            _PlPage.DataInputinLoanAmount(200000);

            _PlPage.DataInputinInterestRate(11);

            _PlPage.DataInputinTenure(30);

            string expEMi = _PlPage.ExpectedEMI("7,656");

            string emi = _PlPage.getEMIfromUI();

            if (expEMi == emi)
            {
                Reporter.LogPass("Both Generated and expected EMI are same!");
            }
        }
    }
}
