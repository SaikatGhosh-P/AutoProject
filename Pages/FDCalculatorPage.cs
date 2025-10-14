using FDAutomationProject.Drivers;
using FDAutomationProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDAutomationProject.Pages
{
    public class FDCalculatorPage
    {
        private IWebDriver _driver;

        // 1. Locators
        // 1. Locators
        private By coockieAcceptbtn => By.XPath(".//button[contains(@id,'allow-btn-privy-cmp') and text()='Accept All']");
        private By NormalCustomerRadio => By.XPath(".//label[text()='Normal']/preceding::input[@id='radio1']");
        private By SeniorCitizenRadio => By.XPath("//label[text()='Senior Citizen' and @for='radio2']");
        private By InterestPayoutDropdown => By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']");
        private By AmountDepositInput => By.XPath("//input[@id='loan_amount']");
        private By teneurYear => By.XPath("//input[@id='loan_amount']");
        private By teneurMonth => By.XPath("//input[@id='tenureMon']");
        private By teneurDays => By.XPath("//input[@id='tenureDays']");


        // Output Locators
        //private By MaturityValueDisplay => By.XPath(".//span[@class='MatureAmount brandCr' and text()='10,000']");        
        private By MaturityValueDisplay => By.XPath(".//span[@class='MatureAmount brandCr']");
        private By InterestRateDisplay => By.XPath(".//span[@class='idRate pull-right']");
        private By MaturityDate => By.XPath(".//span[@class='maturityDate pull-right']");
        private By InterestPerQuater => By.XPath(".//span[@class='perQuaterAmt']");
        private By InterestPerMonth => By.XPath(".//span[@class='perMPAmt']");
        private By AgregateInterestAmount => By.XPath(".//span[@class='InterestAmount']");

        // 2. Constructor
        public FDCalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // 3. Page Methods (Actions)
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
        public void ClickOnNormal()
        {
            _driver.FindElement(By.XPath("//label[text()='Normal' and @for='radio1']")).Click();
            Reporter.LogInfo("Normal Customer Selected");
        }
        public void ClickOnSenior()
        {
            _driver.FindElement(By.XPath("//label[text()='Senior Citizen' and @for='radio2']")).Click();
            Reporter.LogInfo("Senior Customer Selected");
        }

        public void SelectReinvestment()
        {
            //IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']")); //reinvest type
            IWebElement InterestPayoutType = _driver.FindElement(By.Id("FdepType")); //reinvest type
            SelectElement ele = new SelectElement(InterestPayoutType);

            ele.SelectByValue("Cumulative");

            Reporter.LogInfo("Reinvestment (Cumulative) Selected");
        }
        public void SelectQuterlyPayout()
        {
            IWebElement InterestPayoutType = _driver.FindElement(By.Id("FdepType"));
            SelectElement ele = new SelectElement(InterestPayoutType);

            ele.SelectByValue("Quarterly Payout");

            Reporter.LogInfo("Quarterly Payout Selected");
        }
        public void SelectMonthlyPayout()
        {
            IWebElement InterestPayoutType = _driver.FindElement(By.Id("FdepType"));
            SelectElement ele = new SelectElement(InterestPayoutType);
            ele.SelectByValue("Monthly Payout");

            Reporter.LogInfo("Monthly Payout Selected");
        }

        public void AmountDepositValuePut(int loanAmt)
        {
            string loanAmtS = loanAmt.ToString();
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(loanAmtS);

            Reporter.LogInfo($"Loan Amount: {loanAmtS} Submitted");
        }

        public void YearSelection(int yr)
        {
            string yrS = yr.ToString();
            IWebElement yearDropdownTyp = _driver.FindElement(By.XPath("//select[@id='tenureYear']")); //reinvest type
            SelectElement ele = new SelectElement(yearDropdownTyp);
            ele.SelectByValue(yrS);

            Reporter.LogInfo($"Year Selected with Value: {yrS}");
        }

        public void MonthSelection(int mon)
        {
            string monS = mon.ToString();
            IWebElement yearDropdownTyp = _driver.FindElement(By.XPath("//select[@id='tenureMon']")); //reinvest type
            SelectElement ele = new SelectElement(yearDropdownTyp);
            ele.SelectByValue(monS);

            Reporter.LogInfo($"Month Selected with Value: {monS}");
        }

        public void DayValuePut(int tenDay)
        {
            string tenDayS = tenDay.ToString();
            _driver.FindElement(By.XPath("//input[@id='tenureDays']")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.XPath("//input[@id='tenureDays']")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath("//input[@id='tenureDays']")).SendKeys(tenDayS);

            Reporter.LogInfo($"Day Submitted with Value: {tenDayS}");
        }

        public void MaturityValueRead(string expectedMaturityValue)
        {
            string expectedMaturityValueS = expectedMaturityValue.ToString();
            string readMaturityValue = _driver.FindElement(MaturityValueDisplay).Text;

            if (readMaturityValue != expectedMaturityValueS)
            {
                Reporter.LogInfoError($"Expected: {expectedMaturityValueS} and Generated: {readMaturityValue} Maturity Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expectedMaturityValueS} and Generated: {readMaturityValue} Maturity Value are Same");
            }

        }

        public void roiValueRead(string expectedROIValue)
        {
            string expectedROIValueS = expectedROIValue.ToString();
            string readROIValue = _driver.FindElement(InterestRateDisplay).Text;

            if (readROIValue != expectedROIValueS)
            {
                Reporter.LogInfoError($"Expected: {expectedROIValueS} and Generated: {readROIValue} ROI Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expectedROIValueS} and Generated: {readROIValue} ROI Value are Same");
            }
        }

        public void InterestPerQuaterRead(string expectedInterestPerQuater)
        {
            string expectedInterestPerQuaterS = expectedInterestPerQuater.ToString();
            string readInterestPerQuaterValue = _driver.FindElement(InterestPerQuater).Text;

            if (readInterestPerQuaterValue != expectedInterestPerQuaterS)
            {
                Reporter.LogInfoError($"Expected: {expectedInterestPerQuaterS} and Generated: {readInterestPerQuaterValue} IPQ Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expectedInterestPerQuaterS} and Generated: {readInterestPerQuaterValue} IPQ Value are Same");
            }
        }

        public void InterestPerMonthRead(string expectedInterestPerMonth)
        {
            string expectedInterestPerMonthS = expectedInterestPerMonth.ToString();
            string readInterestPerMonthValue = _driver.FindElement(InterestPerMonth).Text;

            if (readInterestPerMonthValue != expectedInterestPerMonthS)
            {
                Reporter.LogInfoError($"Expected: {expectedInterestPerMonthS} and Generated: {readInterestPerMonthValue} IPQ Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expectedInterestPerMonthS} and Generated: {readInterestPerMonthValue} IPQ Value are Same");
            }
        }
        public void MaturityDateRead()
        {

        }
        public void AiaValueRead(string expectedAIAValue)
        {
            string expectedAIAValueS = expectedAIAValue.ToString();
            string readAIAValue = _driver.FindElement(AgregateInterestAmount).Text;

            if (readAIAValue != expectedAIAValueS)
            {
                Reporter.LogInfoError($"Expected: {expectedAIAValueS} and Generated: {readAIAValue} AIA Value is Not Same");
            }
            else
            {
                Reporter.LogInfo($"Expected: {expectedAIAValueS} and Generated: {readAIAValue} AIA Value are Same");
            }
        }

        public void ScrollToElementByXpath(IWebDriver driver, string xpathLocator)
        {
            try
            {
                // 1. Locate the element using the provided XPath
                IWebElement targetElement = driver.FindElement(By.XPath(xpathLocator));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", targetElement);

                Console.WriteLine($"Successfully scrolled to element using XPath: {xpathLocator}");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Error: Element not found with XPath: {xpathLocator}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during scrolling: {ex.Message}");
            }
        }

        public void ForceClick(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            try
            {
                js.ExecuteScript("arguments[0].click();", element);
                Console.WriteLine("Element forcefully clicked using JavaScript.");
            }
            catch (Exception ex)
            {
                // Handle case where JavaScript click also fails
                Console.WriteLine($"Error: JavaScript click failed. {ex.Message}");
                throw;
            }
        }

        public void ScrollByPixel(int x, int y)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            string script = $"window.scrollBy({x}, {y});";
            js.ExecuteScript(script);
        }

        public void CookieAcceptClick()
        {
            _driver.FindElement(coockieAcceptbtn).Click();
        }
     
    }
}