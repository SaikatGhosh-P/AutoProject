using FDAutomationProject.Pages;
using FDAutomationProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

            Test_Normal_With_reinvestment_pre_define_value(6000, 2, 2, 15, "6,933", "6.60%", "933");
            Reporter.LogPass($"Normal Customer with Reinvestment (Cumulative): \n Loan Amount: {6000}\n Year: {2}\n Month: {2}\n Day: {15}\n Executed Properly");
            Test_Normal_With_quarterly_pre_define_value(6000, 2, 2, 15, "6,000", "6.60%", "99", "873");
            Reporter.LogPass($"Normal Customer with Quarterly Payout: \n Loan Amount: {6000}\n Year: {2}\n Month: {2}\n Day: {15}\n Executed Properly");
            Test_Normal_With_monthly_pre_define_value(6000, 2, 2, 15, "6,000", "6.60%", "33", "869");
            Reporter.LogPass($"Normal Customer with Monthly Payout: \n Loan Amount: {6000}\n Year: {2}\n Month: {2}\n Day: {15}\n Executed Properly");
            Test_Senior_With_reinvestment_pre_define_value(6000, 2, 2, 15, "7,009", "7.10%", "1,009");
            Reporter.LogPass($"Normal Customer with Monthly Payout: \n Loan Amount: {6000}\n Year: {2}\n Month: {2}\n Day: {15}\n Executed Properly");
            Test_Senior_With_quarterly_pre_define_value(6000, 2, 2, 15, "6000", "7.10%", "106", "940");
            Reporter.LogPass($"Normal Customer with Monthly Payout: \n Loan Amount: {6000}\n Year: {2}\n Month: {2}\n Day: {15}\n Executed Properly");
            Test_Senior_With_monthly_pre_define_value(6000, 2, 2, 15, "6000", "7.10%", "35", "935");
            Reporter.LogPass($"Normal Customer with Monthly Payout: \n Loan Amount: {6000}\n Year: {2}\n Month: {2}\n Day: {15}\n Executed Properly");
            //Test_002_MinimumAmountValidation();
            // ... Call all other test methods here
        }

        // Test Case TC_FD_001 equivalent
        public void Test_Normal_With_reinvestment_pre_define_value(int loanAmount, int year, int month, int day, string expMaturityAmt, string expROIAmt, string expAIAAmt)
        {
            Console.WriteLine("\n");
            object[] values = new object[] { loanAmount , year, month , day, expMaturityAmt , expROIAmt, expAIAAmt};
            TestOutputGenerator.GenerateTestOutput("Reinvestment Test", "Normal Customer With Reinvestment Type",values);

            _fdPage.PageLoad();
            Thread.Sleep(2000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(2000);
            _fdPage.ScrollByPixel(0, 500);
            Thread.Sleep(2000);
            _fdPage.ClickOnNormal();
            Thread.Sleep(1000);
            _fdPage.SelectReinvestment();
            Thread.Sleep(1000);
            _fdPage.AmountDepositValuePut(loanAmount);
            Thread.Sleep(1000);
            _fdPage.YearSelection(year);
            Thread.Sleep(1000);
            _fdPage.MonthSelection(month);
            Thread.Sleep(1000);
            _fdPage.DayValuePut(day);
            Thread.Sleep(1000);
            _fdPage.MaturityValueRead(expMaturityAmt);
            Thread.Sleep(1000);
            _fdPage.roiValueRead(expROIAmt);
            Thread.Sleep(1000);
            _fdPage.AiaValueRead(expAIAAmt);
            _fdPage.QuitDriver();
        }
        public void Test_Normal_With_quarterly_pre_define_value(int loanAmount, int year, int month, int day, string expMaturityAmt, string expROIAmt, string expIntPerQut, string expAIAAmt)
        {
            Console.WriteLine("\n");
            object[] values = new object[] { loanAmount, year, month, day, expMaturityAmt, expROIAmt, expAIAAmt };
            TestOutputGenerator.GenerateTestOutput("Quarterly Investment Test", "Normal Customer With Quarterly Investment Type", values);

            _fdPage.PageLoad();
            Thread.Sleep(2000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(2000);
            _fdPage.ScrollByPixel(0, 500);
            Thread.Sleep(2000);
            _fdPage.ClickOnNormal();
            Thread.Sleep(1000);
            _fdPage.SelectQuterlyPayout();
            Thread.Sleep(1000);
            _fdPage.AmountDepositValuePut(loanAmount);
            Thread.Sleep(1000);
            _fdPage.YearSelection(year);
            Thread.Sleep(1000);
            _fdPage.MonthSelection(month);
            Thread.Sleep(1000);
            _fdPage.DayValuePut(day);
            Thread.Sleep(1000);
            _fdPage.MaturityValueRead(expMaturityAmt);
            Thread.Sleep(1000);
            _fdPage.roiValueRead(expROIAmt);
            Thread.Sleep(1000);
            _fdPage.InterestPerQuaterRead(expIntPerQut);

            _fdPage.AiaValueRead(expAIAAmt);
            _fdPage.QuitDriver();
        }
        public void Test_Normal_With_monthly_pre_define_value(int loanAmount, int year, int month, int day, string expMaturityAmt, string expROIAmt, string expIntPerMon, string expAIAAmt)
        {
            Console.WriteLine("\n");
            object[] values = new object[] { loanAmount, year, month, day, expMaturityAmt, expROIAmt, expAIAAmt };
            TestOutputGenerator.GenerateTestOutput("Monthly Investment Test", "Normal Customer With Monthly Investment Type", values);

            _fdPage.PageLoad();
            Thread.Sleep(2000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(2000);
            _fdPage.ScrollByPixel(0, 500);
            Thread.Sleep(2000);
            _fdPage.ClickOnNormal();
            Thread.Sleep(1000);
            _fdPage.SelectMonthlyPayout();
            Thread.Sleep(1000);
            _fdPage.AmountDepositValuePut(loanAmount);
            Thread.Sleep(1000);
            _fdPage.YearSelection(year);
            Thread.Sleep(1000);
            _fdPage.MonthSelection(month);
            Thread.Sleep(1000);
            _fdPage.DayValuePut(day);
            Thread.Sleep(1000);
            _fdPage.MaturityValueRead(expMaturityAmt);
            Thread.Sleep(1000);
            _fdPage.roiValueRead(expROIAmt);
            Thread.Sleep(1000);
            _fdPage.InterestPerMonthRead(expIntPerMon);
            _fdPage.AiaValueRead(expAIAAmt);
            _fdPage.QuitDriver();
        }
        public void Test_Normal_With_reinvestment_user_define_value()
        {

        }
        public void Test_Normal_With_quarterly_user_define_value()
        {

        }
        public void Test_Normal_With_monthly_user_define_value()
        {

        }

        //Test for Senior Citizen
        public void Test_Senior_With_reinvestment_pre_define_value(int loanAmount, int year, int month, int day, string expMaturityAmt, string expROIAmt, string expAIAAmt)
        {
            Console.WriteLine("\n");
            object[] values = new object[] { loanAmount, year, month, day, expMaturityAmt, expROIAmt, expAIAAmt };
            TestOutputGenerator.GenerateTestOutput("ReInvestment Test", "Senior Customer With ReInvestment Type", values);


            _fdPage.PageLoad();
            Thread.Sleep(2000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(2000);
            _fdPage.ScrollByPixel(0, 500);
            Thread.Sleep(2000);
            _fdPage.ClickOnSenior();
            Thread.Sleep(1000);
            _fdPage.SelectReinvestment();
            Thread.Sleep(1000);
            _fdPage.AmountDepositValuePut(loanAmount);
            Thread.Sleep(1000);
            _fdPage.YearSelection(year);
            Thread.Sleep(1000);
            _fdPage.MonthSelection(month);
            Thread.Sleep(1000);
            _fdPage.DayValuePut(day);
            Thread.Sleep(1000);
            _fdPage.MaturityValueRead(expMaturityAmt);
            Thread.Sleep(1000);
            _fdPage.roiValueRead(expROIAmt);
            Thread.Sleep(1000);
            _fdPage.AiaValueRead(expAIAAmt);
            _fdPage.QuitDriver();

        }
        public void Test_Senior_With_quarterly_pre_define_value(int loanAmount, int year, int month, int day, string expMaturityAmt, string expROIAmt, string expIntPerQut, string expAIAAmt)
        {
            Console.WriteLine("\n");
            object[] values = new object[] { loanAmount, year, month, day, expMaturityAmt, expROIAmt, expAIAAmt };
            TestOutputGenerator.GenerateTestOutput("Querterly Investment Test", "Senior Customer With Querterly Investment Type", values);

            _fdPage.PageLoad();
            Thread.Sleep(2000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(2000);
            _fdPage.ScrollByPixel(0, 500);
            Thread.Sleep(2000);
            _fdPage.ClickOnSenior();
            Thread.Sleep(1000);
            _fdPage.SelectQuterlyPayout();
            Thread.Sleep(1000);
            _fdPage.AmountDepositValuePut(loanAmount);
            Thread.Sleep(1000);
            _fdPage.YearSelection(year);
            Thread.Sleep(1000);
            _fdPage.MonthSelection(month);
            Thread.Sleep(1000);
            _fdPage.DayValuePut(day);
            Thread.Sleep(1000);
            _fdPage.MaturityValueRead(expMaturityAmt);
            Thread.Sleep(1000);
            _fdPage.roiValueRead(expROIAmt);
            Thread.Sleep(1000);
            _fdPage.InterestPerQuaterRead(expIntPerQut);

            _fdPage.AiaValueRead(expAIAAmt);
            _fdPage.QuitDriver();
        }
        public void Test_Senior_With_monthly_pre_define_value(int loanAmount, int year, int month, int day, string expMaturityAmt, string expROIAmt, string expIntPerMon, string expAIAAmt)
        {
            Console.WriteLine("\n");
            object[] values = new object[] { loanAmount, year, month, day, expMaturityAmt, expROIAmt, expAIAAmt };
            TestOutputGenerator.GenerateTestOutput("Monthly Investment Test", "Senior Customer With Monthly Investment Type", values);

            _fdPage.PageLoad();
            Thread.Sleep(2000);
            _fdPage.CookieAcceptClick();
            Thread.Sleep(2000);
            _fdPage.ScrollByPixel(0, 500);
            Thread.Sleep(2000);
            _fdPage.ClickOnSenior();
            Thread.Sleep(1000);
            _fdPage.SelectMonthlyPayout();
            Thread.Sleep(1000);
            _fdPage.AmountDepositValuePut(loanAmount);
            Thread.Sleep(1000);
            _fdPage.YearSelection(year);
            Thread.Sleep(1000);
            _fdPage.MonthSelection(month);
            Thread.Sleep(1000);
            _fdPage.DayValuePut(day);
            Thread.Sleep(1000);
            _fdPage.MaturityValueRead(expMaturityAmt);
            Thread.Sleep(1000);
            _fdPage.roiValueRead(expROIAmt);
            Thread.Sleep(1000);
            _fdPage.InterestPerMonthRead(expIntPerMon);
            _fdPage.AiaValueRead(expAIAAmt);
            _fdPage.QuitDriver();
        }
        public void Test_Senior_With_reinvestment_user_define_value()
        {

        }
        public void Test_Senior_With_quarterly_user_define_value()
        {

        }
        public void Test_Senior_With_monthly_user_define_value()
        {

        }






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
        
    }
}
