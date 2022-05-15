using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;
using System;

namespace StarWars
{
    [TestFixture]
    [AllureNUnit]
    public class LukeSkywalker
    {
        private const string HomeUrl = "https://swapi.dev/";
        private const string PersonalDataUrl = "https://swapi.dev/api/people/1/";
        private const string PlanetUrl = "https://swapi.dev/api/planets/1/";

        [Test(Description = "Is Luke Skywalker is from Tatooine - Google Chrome")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Sergiusz")]
        [AllureIssue("0001")]
        [AllureName("LukeSkywalkerHomePlanetGoogleChrome")]
        [AllureTag("Luke Skywalker", "Star Wars API", "Homeworld", "Chrome")]
        public void LukeSkywalkerHomeworldChrome()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                driver.Navigate().GoToUrl(PersonalDataUrl);
                IWebElement JediName = driver.FindElement(By.CssSelector("#content > div > div.response-info > pre > span:nth-child(7)"));
                Assert.AreEqual("\"Luke Skywalker\"", JediName.Text);

                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                Screenshot screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile("JediNameChrome.jpg", ScreenshotImageFormat.Jpeg);

                Console.WriteLine("The person name is");
                Console.WriteLine(JediName.Text);

                driver.Navigate().GoToUrl(PlanetUrl);
                DemoHelper.Pause();

                IWebElement Homeworld = driver.FindElement(By.CssSelector("#content > div > div.response-info > pre > span:nth-child(7)"));
                Assert.AreEqual("\"Tatooine\"", Homeworld.Text);

                Console.WriteLine("Homeworld planet of Luke Skywalker name is");
                Console.WriteLine(Homeworld.Text);

                screenshot.SaveAsFile("HomeworldCheckChrome.jpg", ScreenshotImageFormat.Jpeg);
                
            }
        }

        [Test(Description = "Is Luke Skywalker is from Tatooine - Mozilla Firefox")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Sergiusz")]
        [AllureIssue("0002")]
        [AllureName("LukeSkywalkerHomePlanetMozillaFirefox")]
        [AllureTag("Luke Skywalker", "Star Wars API", "Homeworld", "Firefox")]
        public void LukeSkywalkerHomeworldFirefox()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                driver.Navigate().GoToUrl(PersonalDataUrl);
                IWebElement JediName = driver.FindElement(By.CssSelector("span.str:nth-child(7)"));
                Assert.AreEqual("\"Luke Skywalker\"", JediName.Text);

                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                Screenshot screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile("JediNameChrome.jpg", ScreenshotImageFormat.Jpeg);

                Console.WriteLine("The person name is");
                Console.WriteLine(JediName.Text);

                driver.Navigate().GoToUrl(PlanetUrl);
                DemoHelper.Pause();

                IWebElement Homeworld = driver.FindElement(By.CssSelector("span.str:nth-child(7)"));
                Assert.AreEqual("\"Tatooine\"", Homeworld.Text);

                Console.WriteLine("Homeworld planet of Luke Skywalker name is");
                Console.WriteLine(Homeworld.Text);

                screenshot.SaveAsFile("HomeworldCheckChrome.jpg", ScreenshotImageFormat.Jpeg);
            }
        }
    }
}
