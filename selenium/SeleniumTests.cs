using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace selenium;

        
        

public class SeleniumTests : IDisposable
{

    IWebDriver Driver;

    public SeleniumTests() 
    {
        Driver = new ChromeDriver();
        Driver.Navigate().GoToUrl(Path.GetFullPath("../webapp/index.html"));
    }
    
    public void Dispose()
    {
        Driver.Dispose();
    }
    
    [Fact]
    public void Test1()
    {
        Console.WriteLine(Driver.Title);
    }
}