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
    public class HLCalculatorPage
    {
        private IWebDriver _driver;

        // 1. Locators
        private By coockieAcceptbtn => By.XPath(".//button[contains(@id,'allow-btn-privy-cmp') and text()='Accept All']");
        private By bodyTag => By.XPath(".//body");
        private By Heading => By.XPath(".//div[@class='col-md-12']/h1");
        private By LoanAmount => By.XPath(".//input[@id='loan_amount']");
        private By InterestRate => By.XPath(".//input[@id='interest_rate']");
        private By Tenure => By.XPath(".//input[@id='tenure']");
        private By CalculateButton => By.XPath(".//*[@id='calculateBtn']");
        private By EMIResult => By.XPath(".//div[@class='finalResult']/span[@id='lblEMIAmt']");
        private By PrincipleAmt => By.XPath(".//div[@class='semiColmn princAmt']/div/span[@id='princAmt']");
        private By InterestAmt => By.XPath(".//div[@class='semiColmn intAmt']/div/span[@id='intrAmt']]");
        private By TotPayAmt => By.XPath(".//div[@class='semiColmn totPay']/div/span[@id='totalPayAmt']");


        // 2. Constructor
        public HLCalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // 3. Page Methods (Actions)


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

        public void ReadPageHeader(string header, string pmsg)
        {
            string head = _driver.FindElement(Heading).Text;
            if (head.Contains(header))
            {
                Reporter.LogPass(pmsg + "Read Header Case Pass");
            }
            else
            {
                Reporter.LogFail("Read Header Case Fail");
            }
        }
        public void DataInputinLoanAmount(decimal data)
        {
            string dataS = data.ToString();
            _driver.FindElement(LoanAmount).Click();
            _driver.FindElement(LoanAmount).SendKeys(Keys.Control + "a");
            _driver.FindElement(LoanAmount).SendKeys(Keys.Delete);
            _driver.FindElement(LoanAmount).SendKeys(dataS);
            _driver.FindElement(bodyTag).Click();

        }

        public void DataInputinInterestRate(decimal data)
        {
            string dataS = data.ToString();
            _driver.FindElement(InterestRate).Click();
            _driver.FindElement(InterestRate).SendKeys(Keys.Control + "a");
            _driver.FindElement(InterestRate).SendKeys(Keys.Delete);
            _driver.FindElement(InterestRate).SendKeys(dataS);
            _driver.FindElement(bodyTag).Click();

        }

        public void DataInputinTenure(decimal data)
        {
            string dataS = data.ToString();
            _driver.FindElement(Tenure).Click();
            _driver.FindElement(Tenure).SendKeys(Keys.Control + "a");
            _driver.FindElement(Tenure).SendKeys(Keys.Delete);
            _driver.FindElement(Tenure).SendKeys(dataS);
            _driver.FindElement(bodyTag).Click();

        }
        public void SetPLoanParameters(string amount, string rate, string tenure, string expEMI)
        {
            Console.WriteLine($"\nACTION: Setting \nLoan Parameters: Amount={amount}, \nRate={rate}%, \nTenure={tenure} months, \nExpectedEMI={expEMI} months");
        }

        public string ExpectedEMI(string EMIAmt)
        {            
            string EMIAmtS = EMIAmt;
            return EMIAmtS;
        }

        public string getEMIfromUI()
        {
            string EMI = _driver.FindElement(EMIResult).Text;
            return EMI;
        }

        public string getPrincipleAmt()
        {
            string principleAmt = _driver.FindElement(PrincipleAmt).Text;
            return principleAmt;
        }

        public string getInterestAmt()
        {
            string interestAmt = _driver.FindElement(InterestAmt).Text;
            return interestAmt;
        }
        public string getTotalPayable()
        {
            string totPayable = _driver.FindElement(TotPayAmt).Text;
            return totPayable;
        }
    }
}
