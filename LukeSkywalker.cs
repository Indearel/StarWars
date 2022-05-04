using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace StarWars
{
    public class LukeSkywalker
    {
        private const string HomeUrl = "https://swapi.dev/";
        private const string PersonalDataUrl = "https://swapi.dev/api/people/1/";
        private const string PlanetUrl = "https://swapi.dev/api/planets/1/";

        [Fact]
        public void TestHomeworldChrome()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                driver.Navigate().GoToUrl(PersonalDataUrl);
                IWebElement JediName = driver.FindElement(By.CssSelector("#content > div > div.response-info > pre > span:nth-child(7)"));

                Assert.Equal("\"Luke Skywalker\"", JediName.Text);

                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;

                Screenshot screenshot = takesScreenshot.GetScreenshot();

                screenshot.SaveAsFile("JediNameChrome.jpg", ScreenshotImageFormat.Jpeg);

                driver.Navigate().GoToUrl(PlanetUrl);
                DemoHelper.Pause();

                IWebElement Homeworld = driver.FindElement(By.CssSelector("#content > div > div.response-info > pre > span:nth-child(7)"));

                Assert.Equal("\"Tatooine\"", Homeworld.Text);

                screenshot.SaveAsFile("HomeworldCheckChrome.jpg", ScreenshotImageFormat.Jpeg);
            }
        }
        [Fact]
        public void TestHomeworldFirefox()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                driver.Navigate().GoToUrl(PersonalDataUrl);
                IWebElement JediName = driver.FindElement(By.CssSelector("span.str:nth-child(7)"));

                Assert.Equal("\"Luke Skywalker\"", JediName.Text);

                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;

                Screenshot screenshot = takesScreenshot.GetScreenshot();

                screenshot.SaveAsFile("JediNameFirefox.jpg", ScreenshotImageFormat.Jpeg);

                driver.Navigate().GoToUrl(PlanetUrl);
                DemoHelper.Pause();

                IWebElement Homeworld = driver.FindElement(By.CssSelector("span.str:nth-child(7)"));

                Assert.Equal("\"Tatooine\"", Homeworld.Text);

                screenshot.SaveAsFile("HomeworldCheckFirefox.jpg", ScreenshotImageFormat.Jpeg);
            }
        }
    }
}
