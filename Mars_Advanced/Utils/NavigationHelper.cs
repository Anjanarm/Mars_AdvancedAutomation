using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Utils
{ 
    public class NavigationHelper
    {
        private readonly IWebDriver _driver;

        public NavigationHelper(IWebDriver driver)
        {
            _driver = driver;
        }
        public void NavigateTo(string urlPath)
        {
            _driver.Navigate().GoToUrl(Hooks.Settings.Environment.BaseUrl + urlPath);
        }
    }
    
}
