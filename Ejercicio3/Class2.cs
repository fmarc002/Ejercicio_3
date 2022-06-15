﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Ejercicio3
{
    //aplicamos herencia
    public class Class2 : ClassBase
    {

        [Test]
        public void test_1()
        {
            By title = By.XPath("(//div[@class = 'course-curriculum__container'])[1]");

            driver.Navigate().GoToUrl(ultimateQa);
            driver.FindElement(By.LinkText("Courses")).Click();
            var search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.Clear();
            search.SendKeys("Selenium");
            search.SendKeys(Keys.Enter); //.submit()

            var course = driver.FindElement(By.CssSelector(".products__title")).Text;
            Console.WriteLine(course);
            Assert.IsTrue(course.Contains("Selenium"));

            //lo declaro webelement para poder hacer scroll al elemento, no al boolean como le puse antes y es un elemento
            var webElement = driver.FindElement(By.XPath("//h3[contains(text(),'Page Objects')]"));
            
            //scroll down
            var js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);

            Assert.IsFalse(!webElement.Displayed);

            driver.FindElement(By.XPath("//h3[contains(text(),'Page Objects')]")).Click();

            driver.ExplicitWaitUntil(() => driver.FindElement(title).Displayed, TimeSpan.FromSeconds(3));
            string titleText =driver.FindElement(title).Text;

            var start_title = titleText.Trim().StartsWith("Course"); //TrimStart y TrimEnd
            Assert.IsTrue(start_title);
            
           

        }

        [Test]
        public void test_2()
        {
            //select element
            driver.Navigate().GoToUrl(ultimateQa);
            driver.FindElement(By.XPath("//a[contains(text(), 'Interactions')]")).Click();           
            SelectElement element = new SelectElement(this.driver.FindElement(By.CssSelector(".et_pb_blurb_description select")));
            //list select element
            var expectedOptions = new List<string>()
            {
                "Volvo", "Saab", "Opel", "Audi"
            };

            foreach (var opt in expectedOptions)
            {
                Assert.True(element.Options.Any(e => e.Text.Equals(opt)));
            }

            Assert.AreEqual(element.SelectedOption.Text, "Volvo");
            element.SelectByText("Audi");
            Assert.AreEqual(element.SelectedOption.Text, "Audi");
            element.SelectByValue("saab");
            Assert.AreEqual(element.SelectedOption.Text, "Saab");
            element.SelectByIndex(0);
            Assert.AreEqual(element.SelectedOption.Text, "Volvo");

      
            
        }

    }
}
