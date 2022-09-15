using NUnit.Framework;
using OpenQA.Selenium;

namespace TestProject1
{
    public class Tests
    {
       private IWebDriver driver;
        private readonly By _searchInput = By.XPath("//input[@class='gLFyf gsfi']");
        private readonly By _imagesTab = By.XPath("//a[contains(text(),'Картинки')]");
        private readonly By _imagesList = By.XPath("//div[@id='islrg']//img");

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var a = driver.FindElement(_searchInput);
            a.Click();
            a.SendKeys("cat\n");
            var b = driver.FindElement(_imagesTab);
            b.Click();
            var c = driver.FindElements(_imagesList);
            Assert.IsTrue(c.Count > 0);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}