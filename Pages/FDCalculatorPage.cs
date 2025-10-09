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
        private By AgregateInterestAmount => By.XPath(".//span[@class='InterestAmount']");

        // 2. Constructor
        public FDCalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // 3. Page Methods (Actions)
        public void agregateInterestAmountValueRead(int matVal)
        {
            string matValSE = matVal.ToString();
            string matValSR = _driver.FindElement(By.XPath($"{AgregateInterestAmount}")).Text;

            if (matValSE != matValSR)
            {
                Reporter.LogError($"Expected and Get {AgregateInterestAmount} are not Same!");
            }
            else
            {
                Reporter.LogPass($"Expected and Get {AgregateInterestAmount} are Same!");
            }
        }
        public void interestRatPerQuaterValueRead(int matVal)
        {
            string matValSE = matVal.ToString();
            string matValSR = _driver.FindElement(By.XPath($"{InterestPerQuater}")).Text;

            if (matValSE != matValSR)
            {
                Reporter.LogError($"Expected and Get {InterestPerQuater} are not Same!");
            }
            else
            {
                Reporter.LogPass($"Expected and Get {InterestPerQuater} are Same!");
            }
        }
        public void interestRateValueRead(int matVal)
        {
            string matValSE = matVal.ToString();
            string matValSR = _driver.FindElement(By.XPath($"{InterestRateDisplay}")).Text;

            if (matValSE != matValSR)
            {
                Reporter.LogError($"Expected and Get {InterestRateDisplay} are not Same!");
            }
            else
            {
                Reporter.LogPass($"Expected and Get {InterestRateDisplay} are Same!");
            }
        }
        public void maturityDateValueRead(int matVal)
        {
            string matValSE = matVal.ToString();
            string matValSR = _driver.FindElement(By.XPath($"{MaturityDate}")).Text;

            if (matValSE != matValSR)
            {
                Reporter.LogError($"Expected and Get {MaturityDate} are not Same!");
            }
            else
            {
                Reporter.LogPass($"Expected and Get {MaturityDate} are Same!");
            }
        }
        public void maturityValueRead(int matVal)
        {
            string matValSE = matVal.ToString();
            string matValSR = _driver.FindElement(By.XPath($"{MaturityValueDisplay}")).Text;

            if (matValSE != matValSR)
            {
                Reporter.LogError("Expected and Get Maturity value are not Same!");
            }
            else
            {
                Reporter.LogPass("Expected and Get Maturity value are Same!");
            }
        }
        public void radiobuttonSelection(string type)
        {
            if (type.Contains("se"))
            {
                _driver.FindElement(By.XPath("//label[text()='Senior Citizen' and @for='radio2']")).Click();
            }
            else
            {
                _driver.FindElement(By.XPath("//label[text()='Normal' and @for='radio1']")).Click();
            }
        }

        public void fdType_dropdownSelection(string fdType)
        {
            if (fdType.Contains("re"))
            {
                IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']")); //reinvest type
                SelectElement ele = new SelectElement(InterestPayoutType);
                ele.SelectByValue("Reinvestment (Cumulative)");
            }
            else if (fdType.Contains("qui"))
            {
                IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']")); //reinvest type
                SelectElement ele = new SelectElement(InterestPayoutType);
                ele.SelectByValue("Reinvestment (Cumulative)");
            }
            else if (fdType.Contains("moi"))
            {
                IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']")); //reinvest type
                SelectElement ele = new SelectElement(InterestPayoutType);
                ele.SelectByValue("Reinvestment (Cumulative)");
            }
            else
            {
                IWebElement InterestPayoutType = _driver.FindElement(By.XPath("//select[@id='FdepType']/option[text()='Reinvestment (Cumulative)']")); //reinvest type
                SelectElement ele = new SelectElement(InterestPayoutType);
                ele.SelectByValue("Reinvestment (Cumulative)");
            }

        }
        public void valueInput_loanAmount(int loanAmt)
        {
            string loanAmtS = loanAmt.ToString();
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(loanAmtS);
        }

        public void valueInput_tenureDay(decimal tenDay)
        {
            string tenDayS = tenDay.ToString();
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Control + "a");
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(Keys.Backspace);
            _driver.FindElement(By.XPath("//input[@id='loan_amount']")).SendKeys(tenDayS);
        }

        public void setYearDropdoen(int yr)
        {
            string yrS = yr.ToString();
            IWebElement yearDropdownTyp = _driver.FindElement(By.XPath("//select[@id='tenureYear']")); //reinvest type
            SelectElement ele = new SelectElement(yearDropdownTyp);
            ele.SelectByValue(yrS);
        }

        public void setMonthDropdoen(int mon)
        {
            string monS = mon.ToString();
            IWebElement yearDropdownTyp = _driver.FindElement(By.XPath("//select[@id='tenureMon']")); //reinvest type
            SelectElement ele = new SelectElement(yearDropdownTyp);
            ele.SelectByValue(monS);
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

        public void Testtu(String TOC, String IPT, String AD, String years, String months, String days)
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.axisbank.com/");
            //driver.Manage().Window.FullScreen();

            //Thread.Sleep(2000);

            //IWebElement FDCalculator = driver.FindElement(By.XPath("//p[text()='Fixed Deposit ']"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", FDCalculator);

            //driver.Manage().Window.FullScreen();

            if (TOC == "S")
            {
                IWebElement customerTypeDropdown = driver.FindElement(By.XPath("//label[text()='Senior Citizen' and @for='radio2']"));
                customerTypeDropdown.Click();
            }
            else
            {
                driver.FindElement(By.XPath("/label[text()='Normal' and @for='radio1']")).Click();
            }

            IWebElement InterestPayoutType = driver.FindElement(By.XPath("//select[@id='FdepType']"));
            SelectElement ele = new SelectElement(InterestPayoutType);
            ele.SelectByText(IPT);

            IWebElement AmountDeposit = driver.FindElement(By.XPath("//input[@id='loan_amount']"));
            AmountDeposit.Clear();
            AmountDeposit.SendKeys(AD);

            IWebElement Years = driver.FindElement(By.XPath("//select[@id='tenureYear']"));
            SelectElement SelectYear = new SelectElement(Years);
            SelectYear.SelectByValue(years);

            IWebElement Months = driver.FindElement(By.XPath("//select[@id='tenureMon']"));
            SelectElement SelectMonths = new SelectElement(Months);
            SelectMonths.SelectByValue(months);

            IWebElement Days = driver.FindElement(By.Id("tenureDays"));
            Days.Clear();
            Days.SendKeys(days);



            Thread.Sleep(2000);

            IWebElement MaturityValue = driver.FindElement(By.XPath("//span[@class='MatureAmount brandCr']"));
            Console.WriteLine("Monthly calculated EMI is " + MaturityValue.Text);

            driver.Quit();

        }
    }
}
