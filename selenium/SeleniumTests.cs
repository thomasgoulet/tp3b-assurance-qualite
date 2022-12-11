using System;
using System.Collections.Generic;
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

    // Test 1 --------------------------------------------------------------------------------------------------------

    [InlineData(1, 10, 10)]
    [InlineData(61, 2, 122)]
    [InlineData(0.5, 10, 5)]
    [InlineData(0.5, 0.7, 0.35)]
    [InlineData(-10, 0.6, -6)]
    [Theory]
    public void TestMultiply(float x, float y, float result)
    {
        Driver.FindElement(By.Id("test1-x")).SendKeys(x.ToString());
        Driver.FindElement(By.Id("test1-y")).SendKeys(y.ToString());

        Assert.Equal(result.ToString(), Driver.FindElement(By.Id("test1-result")).GetAttribute("value"));
    }

    // Test 2 --------------------------------------------------------------------------------------------------------


    public static IEnumerable<object[]> TestAddListElementData()
    {
        yield return new object[] { new List<string> { "a", "b", "c" } };
        yield return new object[] { new List<string> { "Pier-Luc", "Alexis", "Thomas" } };
        yield return new object[] { new List<string> { "Wow", "ça", "marche" } };
    }

    [MemberData(nameof(TestAddListElementData))]
    [Theory]
    public void TestAddListElement(ICollection<String> strings)
    {

        IWebElement contentInput = Driver.FindElement(By.Id("test2-content"));
        IWebElement addButton = Driver.FindElement(By.Id("second-test-content")).FindElement(By.TagName("button"));

        foreach (var str in strings)
        {
            contentInput.SendKeys(str);
            addButton.Click();
            contentInput.Clear();
        }

        IWebElement list = Driver.FindElement(By.Id("test2-list"));
        IReadOnlyCollection<IWebElement> listItems = list.FindElements(By.TagName("li"));
        List<string> itemValues = new List<string>();


        foreach(var item in listItems)
        {
            itemValues.Add(item.Text);
        }

        Assert.Equal(strings, itemValues);

    }

    // Test 3 --------------------------------------------------------------------------------------------------------


    [Fact]
    public void TestHideShowAttribute()
    {
        IWebElement row1 = Driver.FindElement(By.Id("test3-row1"));
        IWebElement row2 = Driver.FindElement(By.Id("test3-row2"));
        IWebElement row3 = Driver.FindElement(By.Id("test3-row3"));
        IWebElement showAllButton = Driver.FindElement(By.XPath("/html/body/div/div/div[3]/button"));

        row1.FindElement(By.TagName("button")).Click();
        Assert.Equal("none", row1.GetCssValue("display"));
        Assert.Equal("table-row", row2.GetCssValue("display"));
        Assert.Equal("table-row", row3.GetCssValue("display"));


        row2.FindElement(By.TagName("button")).Click();
        Assert.Equal("none", row1.GetCssValue("display"));
        Assert.Equal("none", row2.GetCssValue("display"));
        Assert.Equal("table-row", row3.GetCssValue("display"));

        showAllButton.Click();
        Assert.Equal("table-row", row1.GetCssValue("display"));
        Assert.Equal("table-row", row2.GetCssValue("display"));
        Assert.Equal("table-row", row3.GetCssValue("display"));
    }

}