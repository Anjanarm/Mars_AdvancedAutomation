using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Pages.HomePage
{
    public class Profile
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By AvailabilityUpdate = By.XPath("(//i[@class='right floated outline small write icon'])[1]");
        private readonly By ChooseAvailability = By.XPath("(//select[@name='availabiltyType'])[1]");
        private readonly By ActualAvailability = By.XPath("//div[@class='right floated content']//span");
        private readonly By HourUpdate = By.XPath("(//i[@class='right floated outline small write icon'])[2]");
        private readonly By ChooseHour = By.XPath("(//select[@name='availabiltyHour'])[1]");
        private readonly By ActualHour = By.XPath("(//div[@class='right floated content'])[3]//span");
        private readonly By EarnTargetUpdate = By.XPath("(//i[@class='right floated outline small write icon'])[3]");
        private readonly By ChooseEarnTarget = By.XPath("(//select[@name='availabiltyTarget'])[1]");
        private readonly By ActualEarnTarget = By.XPath("(//div[@class='right floated content'])[4]//span");

        public Profile(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void SelectAvailability(string availability)
        {
            var writeAvailability = _wait.Until(d => d.FindElement(AvailabilityUpdate));
            writeAvailability.Click();
            var selectAvailability = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseAvailability));
            selectAvailability.Click();
            selectAvailability.SendKeys(availability);
            selectAvailability.Click();
          
        }
        public string CheckAvailability()
        {

            //var chosenAvailability = _wait.Until(ExpectedConditions.ElementIsVisible(ActualAvailability));
            var chosenAvailability = _wait.Until(driver =>
            {
                var el = driver.FindElement(ActualAvailability);
                var text = el.Text.Trim();

                return text.Contains("\n") ? null : el;
            });

            return chosenAvailability.Text.Trim();
        }
        public void SelectHours(string hour)
        {
            var writehour = _wait.Until(d => d.FindElement(HourUpdate));
            writehour.Click();
            var selectHour = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseHour));
            selectHour.Click();
            selectHour.SendKeys(hour);
            selectHour.Click();
        }
        public string CheckHour()
        {
            var chosenHour = _wait.Until(driver =>
            {
                var el = driver.FindElement(ActualHour);
                var text = el.Text.Trim();

                return text.Contains("\n") ? null : el;
            });

            return chosenHour.Text.Trim();
        }
        public void SelectTarget(string target)
        {
            var writeTarget = _wait.Until(d => d.FindElement(EarnTargetUpdate));
            writeTarget.Click();
            var selectTarget = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseEarnTarget));
            selectTarget.Click();
            selectTarget.SendKeys(target);
            selectTarget.Click();
        }
        public string CheckTarget()
        {
            var chosenTarget = _wait.Until(driver =>
            {
                var el = driver.FindElement(ActualEarnTarget);
                var text = el.Text.Trim();

                return text.Contains("\n") ? null : el;
            });

            return chosenTarget.Text.Trim();
        }
    }
}
