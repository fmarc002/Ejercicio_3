using System;
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
        //Punto 4 - Agregar otra clase test: Agregar otra clase de test para otra sección diferente
        //de la utilizada en el ejercicio anterior e implementar 2 tests en esa clase:
        //1. Uno que verifique el contenido propio.
        //2. Otro que haga alguna acción permitida en la página y se verifiquen los resultados de
        //esa acción.

        [Test]
        public void test_1()
        {
            //declaración de los selectores
            By seachCourse = By.XPath("//input[@name='q']");
            By title = By.XPath("(//div[@class = 'course-curriculum__container'])[1]");

            driver.Navigate().GoToUrl(ultimateQa);
            driver.FindElement(By.LinkText("Courses")).Click();

            //var search = driver.FindElement(By.XPath("//input[@name='q']"));
            var search = driver.FindElement(seachCourse);
            search.Clear();
            //Extender Webdriver - practice
            driver.ExplicitWaitUntilText(() => driver.FindElement(seachCourse).Displayed, seachCourse, "Selenium", TimeSpan.FromSeconds(3));
            //search.SendKeys("Selenium");
            search.SendKeys(Keys.Enter); //.submit()



            var course = driver.FindElement(By.CssSelector(".products__title")).Text;
            Console.WriteLine(course);
            Assert.IsTrue(course.Contains("Selenium"));


            //lo declaro webelement para poder hacer scroll al elemento, no al boolean como le puse antes y es un elemento
            var webElement = driver.FindElement(By.XPath("//h3[contains(text(),'Page Objects')]"));

            //scroll down (Lo hice de practica ya que me surgio de curiosa para saber como era!)
            var js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);

            Assert.IsFalse(!webElement.Displayed);

            driver.FindElement(By.XPath("//h3[contains(text(),'Page Objects')]")).Click();

            // Punto 7:
            // Extender Webdriver: Extender Webdriver para que se haga un explicit wait del
            // elemento cada vez que se lo busca.Ver ejemplo de cómo se hace en el proyecto
            // ejemplo de git.

            driver.ExplicitWaitUntil(() => driver.FindElement(title).Displayed, TimeSpan.FromSeconds(3));
            //declarás el tipo de elemento del selector en este caso  es tipo "string"
            string titleText = driver.FindElement(title).Text;

            var start_title = titleText.Trim().StartsWith("Course"); //TrimStart y TrimEnd
            Assert.IsTrue(start_title);

        }

        // test with Select Element
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
