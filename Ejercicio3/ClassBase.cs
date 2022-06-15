using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ejercicio3
{
    public class ClassBase
    {
        // Punto 5:
        // Implementar métodos cleanup e initialize para todas las clases de que se tengan.
        // Poner el código común en la clase tanto al inicializar como al terminar.

        // Punto 6:
        // Implementar clase base test: La idea es implementar una clase base test que luego
        // extiendan las clases test que se definieron, donde se hagan pasos básicos y comunes
        // a todos los tests. La clase base test tendría su Initialize y Cleanup que es común a
        // todos los test de todas las clases.

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
