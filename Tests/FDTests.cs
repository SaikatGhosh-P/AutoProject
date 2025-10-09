using FDAutomationProject.Pages;
using FDAutomationProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

            Test_reinvestment_with_predefine_value_forSenior();
            Test_quaterlyPayout_with_predefine_value_forSenior();
            Test_monthlyPayout_with_predefine_value_forSenior();
            //Test_002_MinimumAmountValidation();
            // ... Call all other test methods here
        }

        // Test Case TC_FD_001 equivalent
         public void Test_reinvestment_with_predefine_value_forSenior()
        {
            Thread.Sleep(3000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(3000);
            _fdPage.ScrollByPixel(0, 200);

            _driver.FindElement(By.XPath("//label[text()='Senior Citizen' and @for='radio2']")).Click(); //senior radio

            Thread.Sleep(2000);

            IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']")); //reinvest type
            SelectElement ele = new SelectElement(InterestPayoutType);
            ele.SelectByValue("Reinvestment (Cumulative)");


            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Control + "a"); //loan amount textbox
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys("6000");

            new SelectElement(_driver.FindElement(By.XPath("//select[@id='tenureYear']"))).SelectByValue("2"); //year dropdown

            new SelectElement(_driver.FindElement(By.XPath("//select[@id='tenureMon']"))).SelectByValue("2"); //month dropdown

            _driver.FindElement(By.Id("tenureDays")).SendKeys(Keys.Control + "a"); //day textbox
            _driver.FindElement(By.Id("tenureDays")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.Id("tenureDays")).SendKeys("10");

            string maturityValue = _driver.FindElement(By.XPath(".//span[@class='MatureAmount brandCr']")).Text; //maturityvalue text

            if (maturityValue == "6,927")
            {
                Reporter.LogPass("Reinvestment (Cumulative) functionality is working properly");
            }
            else
            {
                Reporter.LogFail("Reinvestment (Cumulative) functionality is not working properly");
            }
        }
        public void Test_quaterlyPayout_with_predefine_value_forSenior()
        {
            Thread.Sleep(3000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(3000);
            _fdPage.ScrollByPixel(0, 200);

            _driver.FindElement(By.XPath("//label[text()='Senior Citizen' and @for='radio2']")).Click();

            Thread.Sleep(2000);

            IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']"));
            SelectElement ele = new SelectElement(InterestPayoutType);
            ele.SelectByValue("Reinvestment (Cumulative)");


            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys("10000");

            new SelectElement(_driver.FindElement(By.XPath("//select[@id='tenureYear']"))).SelectByValue("2");

            new SelectElement(_driver.FindElement(By.XPath("//select[@id='tenureMon']"))).SelectByValue("2");

            _driver.FindElement(By.Id("tenureDays")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.Id("tenureDays")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.Id("tenureDays")).SendKeys("10");

            string ipqVal = _driver.FindElement(By.XPath(".//div[@class='column perQuaterCol']/div/span")).Text;

            if (ipqVal == "165")
            {
                Reporter.LogPass("Quarterly Payout functionality is working properly");
            }
            else
            {
                Reporter.LogFail("Quarterly Payout functionality is not working properly");
            }
        }
        public void Test_monthlyPayout_with_predefine_value_forSenior()
        {
            Thread.Sleep(3000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(3000);
            _fdPage.ScrollByPixel(0, 200);

            _driver.FindElement(By.XPath("//label[text()='Senior Citizen' and @for='radio2']")).Click();

            Thread.Sleep(2000);

            IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']"));
            SelectElement ele = new SelectElement(InterestPayoutType);
            ele.SelectByValue("Reinvestment (Cumulative)");


            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys("150000");

            new SelectElement(_driver.FindElement(By.XPath("//select[@id='tenureYear']"))).SelectByValue("2");

            new SelectElement(_driver.FindElement(By.XPath("//select[@id='tenureMon']"))).SelectByValue("2");

            _driver.FindElement(By.Id("tenureDays")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.Id("tenureDays")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.Id("tenureDays")).SendKeys("15");

            string ipqVal = _driver.FindElement(By.XPath(".//div[@class='column perQuaterCol']/div/span")).Text;

            if (ipqVal == "820")
            {
                Reporter.LogPass("Quarterly Payout functionality is working properly");
            }
            else
            {
                Reporter.LogFail("Quarterly Payout functionality is not working properly");
            }
        }
        public void Test_002_TestFromPredefinedValue(string toc,string fdtype, string ad, string yrs, string mnt, string day)
        {
            _fdPage.CookieAcceptClick();
            Thread.Sleep(3000);
            _fdPage.ScrollByPixel(0, 200);
            Thread.Sleep(3000);

            _fdPage.Test(toc, fdtype, ad, yrs, mnt, day);

            // ... implementation steps using _fdPage methods ...
            // e.g., _fdPage.SetDepositAmount("4999");
            // e.g., Read and check for the expected error message element.
        }
    }
}
