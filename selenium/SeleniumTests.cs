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
        Driver = new ChromeDriver("./driver");
        Driver.Navigate().GoToUrl("https://tp3b-assurance.tgoulet.com");
    }
    
    public void Dispose()
    {
        Driver.Dispose();
    }
    
    [Fact]
    public void TestMultiply()
    {
        System.Threading.Thread.Sleep(1000000);
    }

    [Fact]
    public void TestAddListElement()
    {

    }

    [Fact]
    public void TestHideShowAttribute()
    {

    }

}