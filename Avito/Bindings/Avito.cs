using TechTalk.SpecFlow;

namespace Avito.Bindings
{
    [Binding]
    public class Avito
    {
        [When(@"I start browser")]
        public void WhenIStartBrowser()
        {
            Browser.Start();
        }

        [When(@"I close browser")]
        public void WhenICloseBrowser()
        {
            Browser.Quit();
        }

        [When(@"I refresh browser page")]
        public void ReloadBrowserPage()
        {
            Browser.Refresh();
        }

        [When(@"I navigate to ""(.*)""")]
        public void WhenINavigateTo(string url)
        {
            Browser.Navigate(url);
        }

        [When(@"I navigate to Avito start page")]
        public void WhenINavigateToAvitoStartPage()
        {
            Browser.Navigate("https://www.Avito.ru");
        }

        [Then(@"I see Avito start page")]
        public void ThenISeeAvitoStartPage()
        {
            var title = "Доска объявлений от частных лиц и компаний на Avito";
            Browser.CheckTitle("title");
        }

        [When(@"I open login page")]
        public void WhenIOpenLoginPage()
        {
            Browser.Navigate("https://www.avito.ru/profile");
        }

        [When(@"I enter with ""(.*)"" login and password")]
        public void WhenIEnterWithLoginAndPassword(string type)
        {
            switch (type) { 
                case "wrong":
                    Browser.SendText("login", "mbrigadirenko@mirantis.com");
                    Browser.SendText("password", "123");
                    break;
                case "right":
                    Browser.SendText("login", "mbrigadirenko@mirantis.com");
                    Browser.SendText("password", "123");
                    break;
            }
            Browser.ClickButton("Войти");
        }

        [Then(@"I see ""(.*)"" message")]
        public void ThenISeeMessage(string type)
        {
            switch (type)
            {
                case "wrong credentials":
                    Browser.CheckMessage("Введите код подтверждения");
                    break;
            }
        }

    }
}
