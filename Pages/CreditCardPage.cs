using FDAutomationProject.Drivers;
using FDAutomationProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDAutomationProject.Pages
{
    public class CreditCardPage
    {
        private IWebDriver _driver;
        private By transactionAmt => By.XPath(".//input[@id='txtLoanAmount']");
        private By tenureMnth => By.XPath(".//select[@id='DrpMonth']");
        private By interesrRate => By.XPath(".//div[@id='intRate']");
        private By procFee => By.XPath(".//span[@id='ProcessingFee']");
        private By GSTprocFee => By.XPath(".//span[@id='STPF']");
        private By totInstPayable => By.XPath(".//span[@id='TotalInterest']");
        private By GSTonInst => By.XPath(".//span[@id='STInterest']");
        private By extarPay => By.XPath(".//span[@id='ExtraPayable']");
        private By trascAmt => By.XPath(".//span[@id='LoanAmt']");
        private By totPayable => By.XPath(".//span[@id='TotalPayable']");

        public CreditCardPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void PageLoad()
        {

            _driver = WebDriverFactory.GetDriver("Chrome");
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://www.axisbank.com/retail/calculators/fd-calculator?cta=calculators-life-goal-card3");

        }

        public void QuitDriver()
        {
            _driver.Quit();
        }

        public void AmountDepositValuePut(int ccAmt)
        {
            string loanAmtS = ccAmt.ToString();
            _driver.FindElement(By.XPath($"{ transactionAmt}")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.XPath($"{transactionAmt}")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath($"{transactionAmt}")).SendKeys(loanAmtS);

            Reporter.LogInfo($"Loan Amount: {ccAmt} Submitted");
        }

        public void TenureSelection(int ten)
        {
            string yrS = ten.ToString();
            IWebElement tenureDropdownTyp = _driver.FindElement(By.XPath($"{tenureMnth}")); //reinvest type
            SelectElement ele = new SelectElement(tenureDropdownTyp);
            ele.SelectByValue(yrS);

            Reporter.LogInfo($"Year Selected with Value: {ten}");
        }

        public void ReadInterestRate(string intRate)
        {
            string expected = intRate.ToString();
            string readValue = _driver.FindElement(interesrRate).Text;
            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }

        public void ProcessingFee(string processingFee)
        {
            string expected = processingFee.ToString();
            string readValue = _driver.FindElement(procFee).Text;
            
            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }

        public void GSTOnProcessingFee(string gstprocessingFee)
        {
            string expected = gstprocessingFee.ToString();
            string readValue = _driver.FindElement(GSTprocFee).Text;

            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }

        public void ReadTotInterestRate(string interstRate)
        {
            string expected = interstRate.ToString();
            string readValue = _driver.FindElement(totInstPayable).Text;

            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }

        public void ReadGSTonInterest(string gstinterstRate)
        {
            string expected = gstinterstRate.ToString();
            string readValue = _driver.FindElement(GSTonInst).Text;

            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }

        public void ReadExtraPayable(string extraPayable)
        {
            string expected = extraPayable.ToString();
            string readValue = _driver.FindElement(extarPay).Text;

            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }

        public void ReadTransactionAmt(string transactionAmt)
        {
            string expected = transactionAmt.ToString();
            string readValue = _driver.FindElement(trascAmt).Text;

            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }

        public void ReadTotalPayable(string totPay)
        {
            string expected = totPay.ToString();
            string readValue = _driver.FindElement(totPayable).Text;

            if (readValue != expected)
            {
                Reporter.LogInfoError($"Expected: {expected} and Generated: {readValue} Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expected} and Generated: {readValue} Value are Same");
            }
        }
    }
}
