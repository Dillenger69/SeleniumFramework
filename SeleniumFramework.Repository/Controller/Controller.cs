using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Runtime.CompilerServices;
using SeleniumFramework.Repository.Pages;
using SeleniumFramework.Repository.Steps;

namespace SeleniumFramework.Repository.Controller
{
    public class TestController
    {
        public string DriverType {get;set;}
        public IWebDriver Driver {get;set;}
        public int TimeoutSeconds {get;set;}
        public int TimeoutMilliseconds {get;set;}
        public PageGoogleMain GoogleMain {get;set;}
        public TestSteps TestSteps {get;set;}

        public TestController(string driverType = "Chrome", int timeoutSeconds = 60, int timeoutMilliseconds = 250)
        {
            DriverType = driverType;
            Driver = StartBrowser(); ;
            TimeoutSeconds = timeoutSeconds;
            TimeoutMilliseconds = timeoutMilliseconds;
            GoogleMain = new PageGoogleMain(Driver, TimeoutSeconds, TimeoutMilliseconds);
            TestSteps = new TestSteps(this, GoogleMain);
        }

        public IWebDriver StartBrowser()
        {
            IWebDriver? driver;

            // default to Chrome
            if (DriverType == "Firefox")
            {
                driver = new FirefoxDriver();
            }
            else 
            {
                try
                {
                    driver = new ChromeDriver();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Installing ChromeDriver");

                    var chromeDriverInstaller = new ChromeDriverInstaller();

                    // not necessary, but added for logging purposes
                    var chromeVersion = chromeDriverInstaller.GetChromeVersion();
                    Console.WriteLine($"Chrome version {chromeVersion} detected");

                    chromeDriverInstaller.Install(ChromeDriverPlatform.Win64, chromeVersion).Wait();
                    Console.WriteLine("ChromeDriver installed");
                    
                    driver = new ChromeDriver();
                }
            }

            return driver;
        }

        /// <summary>
        /// Navigates ti the given URL
        /// </summary>
        /// <param name="startingUrl"></param>
        public void GoTo(string startingUrl)
        {
            Driver.Url = startingUrl;
        }

        /// <summary>
        /// Returns the driver title.
        /// </summary>
        /// <returns></returns>
        public string DiverTitle()
        {
            return Driver.Title;
        }
        
        /// <summary>
        /// Closes the active window and kills the driver.
        /// </summary>
        public void DriverQuit()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}