using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ItchIoCollector
{
    class Program
    {
        static void Main(string[] args)
        {

            const string username = "andre@daoust.org";
            const string password = "forever";
            const string uniqueId = "jUjtVPGDBHeKHktSdtLAjgjy2iPqHLxkx3PsjuWj";
            const int resumeFromPage = 1;


            var gamesUrl = $"https://itch.io/bundle/download/{uniqueId}?page={resumeFromPage}";
            const string loginUrl = "https://itch.io/login";

            IWebDriver driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));

            //Navigate to google page
            driver.Navigate().GoToUrl(loginUrl);

            //Login
            var element = driver.FindElement(By.Name("username"));
            element.SendKeys(username);
            element = driver.FindElement(By.Name("password"));
            element.SendKeys(password);
            driver.FindElements(By.ClassName("button"))[0].Click();

            //Go to games
            driver.Navigate().GoToUrl(gamesUrl);

            //Get number of pages
            var pageElement = driver.FindElement(By.ClassName("pager_label")); //Returns 'Page X of X'
            var pageCount = pageElement.Text.Substring(pageElement.Text.LastIndexOf('f') + 2);

            var pages = Int32.Parse(pageCount);

            for (var pageIndex = 1; pageIndex <= pages+1; pageIndex++)
            {
                Console.WriteLine($"Page {pageIndex} of {pages}");
                var count = 1;
                try
                {
                    var gamesPerPage = driver.FindElements(By.ClassName("game_row_data"));
                    count = gamesPerPage.Count;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                
                for (var index = 0; index <= count; index++)
                {
                    driver.FindElements(By.ClassName("button"))[index].Click();
                    wait.Until(d => d.FindElement(By.ClassName("footer")));
                    driver.Navigate().Back();
                }

                if (pageIndex < count)
                {
                    var next = driver.FindElement(By.LinkText("Next"));
                    next.Click();
                }
            }

            //Close the browser
            Console.WriteLine("All done!");
            driver.Close();
        }
    }
}
