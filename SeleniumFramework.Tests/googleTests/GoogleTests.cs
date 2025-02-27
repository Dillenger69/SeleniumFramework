using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeleniumFramework.Repository.Controller;

namespace SeleniumFramework.Tests;

public class GoogleTests
{   
    [Fact]
    public void Test1()
    {
        try
        {
            var controller = new TestController();
            const string searchFor = "Goober";
            controller.GoTo("HTTPS://www.google.com/");
            controller.TestSteps.SearchFor(searchFor);
            var validate = controller.Driver.Title == searchFor;
            
            controller.DriverQuit();
            
            if (validate)
            {
                Assert.True(true, $"Test1 Passed with expected driver title:{controller.Driver.Title}");
            }
            else
            {
                Assert.False(false, $"Test1 Failed with unexpected driver title: {controller.Driver.Title}");
            }
        }
        catch (Exception ex)
        {
            Assert.False(false, $"Test1 failed with message:'{ex.Message}'");
        }
    }
}
