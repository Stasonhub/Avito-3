using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using By = OpenQA.Selenium.By;


namespace Avito.Bindings
{
    public static class Browser
    {
        private static IWebDriver _webDriver;

        public static void Start()
        {
            var options = new InternetExplorerOptions
            {
                EnableNativeEvents = true,
                EnablePersistentHover = false,
                RequireWindowFocus = true
            };
            _webDriver = new InternetExplorerDriver(options);
        }
        public static void Quit()
        {
            if (_webDriver == null) return;
            _webDriver.Quit();
            _webDriver = null;
        }
        public static void Navigate(string url)
        {
                WebDriver.Navigate().GoToUrl(url);
        }
        public static IWebDriver WebDriver
        {
            get
            {
                if (!IsStarted)
                    Assert.Fail("Browser is not started");
                return _webDriver;
            }
    }
        public static bool IsStarted { get { return _webDriver != null; } }

        public static void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }
        public static void ClickToLinkWithClass(string text)
        {
            WebDriver.FindElement(By.PartialLinkText("Личный кабинет")).Click(); // first try

            IWebElement button = WebDriver.FindElement(By.PartialLinkText("Личный кабинет")); // second try
            Actions action = new Actions(WebDriver);
            action.MoveToElement(button).Perform(); // move to the button
            button.Click();
        }
        public static void CheckTitle(string title)
        {
            Assert.AreEqual(title, WebDriver.Title);
        }

        public static void SendText(string name, string text)
        {
            //WebDriverWait waitForElement = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(1));
            //waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
            WebDriver.FindElement(By.Name(name)).SendKeys(text);
        }

        public static void ClickButton(string name)
        {
            WebDriver.FindElement(By.XPath("//button[contains(text(), '"+name+"')]")).Click();
        }

        public static void CheckMessage(string text)
        {
            var errorMessage = WebDriver.FindElement(By.XPath("//*[contains(@class, 'form-fieldset__error')]")).Text;
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains(text));
        }
    }
}
