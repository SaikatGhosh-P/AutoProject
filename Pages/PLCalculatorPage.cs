using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDAutomationProject.Pages
{
    public class PLCalculatorPage
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
        private By PrincipleAmt => By.XPath(".//div[@class='finalResult']/span[@id='lblEMIAmt']");
        private By InterestAmt => By.XPath(".//div[@class='finalResult']/span[@id='lblEMIAmt']");
       

        // 2. Constructor
        public PLCalculatorPage(IWebDriver driver)
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
    }
}
