using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Ejercicio3
{
    public static class WebDriverExtensions
    {

        // Punto 7:
        // Extender Webdriver: Extender Webdriver para que se haga un explicit wait del
        // elemento cada vez que se lo busca.Ver ejemplo de cómo se hace en el proyecto
        // ejemplo de git.

        public static bool ExplicitWaitUntil(this IWebDriver driver, Func<bool> func, TimeSpan timeout)
        {

            try
            {
                var result = new WebDriverWait(driver, timeout).Until(x => func());

                return result;

            }

            catch (Exception)
            {
                return false;

            }

        }
    }
}
