using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ejercicio3
{
    public class ClassBase
    {

        public IWebDriver driver;
        public String ultimateQa = "https://www.ultimateqa.com/automation/";
        public ChromeOptions options;

        [SetUp]
        public void initialize()
        {
            options = new ChromeOptions();
            driver = new ChromeDriver(options);
            //cada vez que busca un elemento espera 10seg
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

        }


        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
