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
       
        public static bool ExplicitWaitUntil( this IWebDriver driver, Func<bool> func, TimeSpan timeout)
        {
            
            try
            {
                var result = new WebDriverWait(driver, timeout).Until(x => func());

                return result;

            }

            catch(Exception)
            {
                return false;
                
            }

        }
    }
}
