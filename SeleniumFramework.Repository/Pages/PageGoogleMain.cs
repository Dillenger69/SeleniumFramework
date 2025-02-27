using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace SeleniumFramework.Repository.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public class PageGoogleMain(IWebDriver driver, int timeoutSeconds, int timeoutMilliseconds) : BasePage(driver, timeoutSeconds, timeoutMilliseconds)
    {
        private readonly By _searchFieldLocator = By.Name("q");
        private readonly By _searchIconLocator = By.XPath("//*[@jsname='uFMOof']");
        private readonly By _titleLocator = By.TagName("title");
        private readonly By _productCountLocator = By.ClassName("inventory_item");

        /// <summary>
        /// Driver Title Element
        /// </summary>
        public IWebElement DriverTitle => FluentWait.Until(result => Driver.FindElement(_titleLocator)); 
        
        /// <summary>
        /// Search Field Element
        /// </summary>
        public IWebElement SearchField => FluentWait.Until(result => Driver.FindElement(_searchFieldLocator)); 

        /// <summary>
        /// Search Icon Element
        /// </summary>
        public IWebElement SearchIcon => FluentWait.Until(result => Driver.FindElement(_searchIconLocator));
    }
}