using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using SeleniumFramework.Repository.Pages;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;

namespace SeleniumFramework.Repository.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public class BasePage
    {
        protected IWebDriver Driver {get;set;}
        protected int TimeoutSeconds {get;set;}
        protected int TimeoutMilliseconds {get;set;}
        public WebDriverWait Wait {get;set;}
        public DefaultWait<IWebDriver> FluentWait {get;set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="timeoutSeconds"></param>
        /// <param name="timeoutMilliseconds"></param>
        protected BasePage(IWebDriver driver, int timeoutSeconds, int timeoutMilliseconds)
        {
            Driver = driver;
            TimeoutSeconds = timeoutSeconds < 0 ? 10 : timeoutSeconds;
            TimeoutMilliseconds = timeoutMilliseconds < 0 ? 10 : timeoutMilliseconds;

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeoutSeconds));

            FluentWait = new DefaultWait<IWebDriver>(Driver);
                FluentWait.Timeout = TimeSpan.FromSeconds(TimeoutSeconds);
                FluentWait.PollingInterval = TimeSpan.FromMilliseconds(TimeoutMilliseconds);
                FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                FluentWait.Message = "Element to be searched not found";
        }
    }
}