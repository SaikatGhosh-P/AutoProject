using OpenQA.Selenium;
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
        private By coockieAcceptbtn => By.XPath(".//button[contains(@id,'allow-btn-privy-cmp') and text()='Accept All']");
        private By NormalCustomerRadio => By.XPath(".//label[text()='Normal']/preceding::input[@id='radio1']");
        //private By SeniorCitizenRadio => By.XPath(".//input[@id='radio2']");
        //private By SeniorCitizenRadio => By.XPath(".//label[contains(text(),'Senior')]/preceding::input[@id='radio2']");
        private By SeniorCitizenRadio => By.XPath(".//div[@id='RadioButton']/input[@id='radio2']");
        private By InterestPayoutDropdown => By.Id("interest-payout-type-id"); // Assuming an ID or use a descriptive XPath
        private By AmountDepositInput => By.Name("amountDeposit"); // Assuming a name
        private By OpenFDButton => By.XPath("//button[text()='Open FD']");

        // Output Locators
        private By MaturityValueDisplay => By.XPath("//h4[text()='Maturity Value']/following-sibling::span");
        //private By InterestRateDisplay => By.XPath(".//span[@id='matIntRate']/preceding::span[text()='Rate of Interest*']");
        private By InterestRateDisplay => By.XPath(".//span[@id='matIntRate']");

        // 2. Constructor
        public FDCalculatorPage(IWebDriver driver)
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
        public void SelectCustomerType(string type)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement normalElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SeniorCitizenRadio));
            IWebElement seniorElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SeniorCitizenRadio));
            

            if (type.ToLower() == "senior citizen")
            {
                seniorElement.Click();
                //_driver.FindElement(SeniorCitizenRadio).Click();
            }
            else
            {
                normalElement.Click();
                //_driver.FindElement(NormalCustomerRadio).Click();
            }
        }

        public void clickonNormal()
        {
            _driver.FindElement(NormalCustomerRadio).Click();
        }

        public void clickonSenior()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SeniorCitizenRadio));
            element.Click();
            //_driver.FindElement(SeniorCitizenRadio).Click();
        }
        public void SetDepositAmount(string amount)
        {
            _driver.FindElement(AmountDepositInput).Clear();
            _driver.FindElement(AmountDepositInput).SendKeys(amount);
        }

        // 4. Page Methods (Verification/Getters)
        public string GetInterestRate()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(InterestRateDisplay));
            return element.Text;
            //return _driver.FindElement(InterestRateDisplay).Text;
        }

        public string GetMaturityValue()
        {
            return _driver.FindElement(MaturityValueDisplay).Text;
        }
    }
}
