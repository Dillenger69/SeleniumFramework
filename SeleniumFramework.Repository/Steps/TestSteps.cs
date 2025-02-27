using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeleniumFramework.Repository.Pages;
using SeleniumFramework.Repository.Controller;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFramework.Repository.Steps
{
    public class TestSteps(TestController controller, PageGoogleMain googleMain)
    {
     
       /// <summary>
       /// Main test controller
       /// </summary>       
       private TestController Controller { get; } = controller;
       
       /// <summary>
       /// 
       /// </summary>
       private PageGoogleMain GoogleMain { get; } = googleMain;

       // An element can be located using ExpectedConditions through an explicit wait
       public bool IsLoaded => GoogleMain.FluentWait.Until(d => GoogleMain.SearchField.Displayed);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="searchText"></param>
       public void SearchFor(string searchText = "webdriver")
       {
           GoogleMain.SearchField.SendKeys(searchText);
           GoogleMain.SearchField.SendKeys(Keys.Enter);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="title"></param>
       /// <returns></returns>
       public bool ValidateWindowTitle(string title)
       {
           return Controller.Driver.Title == title;
       }
    }
}