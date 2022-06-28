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


namespace Ejercicio3
{
    public class JavaTest : BaseTest
    {

        // Punto 3.1 - Ir a la sección “NN” (cada pasante le toca una) y verifique la visualización
        //de los elementos principales de la página, verificar su texto y/o valor por defecto.
        [Test]
        public void test_1()
        {
            driver.Navigate().GoToUrl(ultimateQa);
            driver.FindElement(By.LinkText("Selenium Java")).Click();
            //XPATH
            var title = driver.FindElement(By.XPath("//div/h1[contains(text(),'Java')]")).Text;
            Console.WriteLine(title);
            Assert.IsTrue(title.Contains("Java"));
            //XPATH
            var description = driver.FindElement(By.XPath("(//div[@class ='et_pb_text_inner']/p)[1]"));
            Assert.IsTrue(description.Displayed);
            Assert.IsTrue(description.Text.Contains("automation engineer"));
            
        }

        // Punto 3.3 - Clonar el test y cambiar alguna assertion para lograr que falle el segundo test
        [Test]
        public void test_2()
        {
            driver.Navigate().GoToUrl(ultimateQa);
            driver.FindElement(By.LinkText("Selenium Java")).Click();
            //XPATH
            var title = driver.FindElement(By.XPath("//div/h1[contains(text(),'Java')]")).Text;
            Console.WriteLine(title);
            //XPATH
            driver.FindElement(By.XPath("(//div[@class ='et_pb_text_inner']/p)[1]"));

            //XPATH
            //var joinnow = driver.FindElement(By.XPath("(//*[contains(text(),'join now')])[5]")).Displayed;
            // //div[contains(@class, 'mobile')]//a
            //locator con 2 contains: //div[contains(@class, 'mobile')]//a[contains(text(),'join now')]

            //Buscar por href y por id, busco el padre unico y despues el hijo, en este caso tienen el mismo id los hijos:
            // locator: //a[contains(@href, '/enroll/808620')]
            var joinnow = driver.FindElement(By.XPath("//div[contains(@class, 'mobile')]//a")).Displayed;

            Assert.False(joinnow);

        }

        // Punto 3.4 - Crear otro test que realice alguna acción/workflow en la página y agregar las aserciones del resultado.
        [Test]
        public void test_3()
        {
            driver.Navigate().GoToUrl(ultimateQa);
            driver.FindElement(By.LinkText("Selenium Java")).Click();
            //XPATH
            var title = driver.FindElement(By.XPath("//div/h1[contains(text(),'Java')]")).Text;
            Console.WriteLine(title);
            //XPATH
            driver.FindElement(By.XPath("(//div[@class ='et_pb_text_inner']/p)[1]"));

            //XPATH
            var joinnow = driver.FindElement(By.XPath("//div[contains(@class, 'mobile')]//a")).Displayed;
            Assert.IsTrue(joinnow);

            //CSSS - obtener el color de background-image. Va en degrade
            var row = driver.FindElement(By.CssSelector(".et_pb_section_0"));
            var rgbFormat = row.GetCssValue("background-image");
            Console.WriteLine(rgbFormat);

            Assert.IsTrue(rgbFormat.Contains("linear-gradient(rgb(71, 74, 182) 0%, rgb(146, 113, 246) 100%)"));

            //XPATH watch the video
            var video = driver.FindElement(By.XPath("//div//a[@class='et_pb_video_play']")).Displayed;
            // css: driver.FindElement(By.CssSelector(".et_pb_video_play"));
            Assert.IsTrue(video);


            //image: Featured On These Websites
            var image = driver.FindElement(By.XPath("(//div/span[@class = 'et_pb_image_wrap'])[15]")).Displayed;
            Assert.IsNotNull(image);

            //url - Use method GetAttribute()
            String url_video = driver.FindElement(By.XPath("//*[contains(@name,'fitvid0')]")).GetAttribute("src");
            Console.WriteLine(url_video);
            var url_expected = "https://www.youtube.com/embed/aRbmmYf41yQ?feature=oembed";
            Assert.AreEqual(url_expected, url_video); // For the same object reference

            driver.FindElement(By.XPath(" (//div/h5[@class ='et_pb_toggle_title'])[1]")).Click();
            var questions = driver.FindElement(By.XPath("(//div[@class ='et_pb_toggle_content clearfix'])[1]"));
            // use method GetCssValue ("Style")
            var display_question = questions.GetCssValue("display");
            Console.WriteLine(display_question);
            Assert.AreEqual("block", display_question);

        }
    }
}
