using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

class Program
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            // 10 saniye boyunca elementi bekle
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement emailField = wait.Until(drv => drv.FindElement(By.Name("username")));
            IWebElement passwordField = wait.Until(drv => drv.FindElement(By.Name("password")));
            IWebElement loginButton = wait.Until(drv => drv.FindElement(By.ClassName("radius")));

            emailField.SendKeys("tomsmith");
            passwordField.SendKeys("SuperSecretPassword!");
            loginButton.Click();

            // Başarılı giriş kontrolü
            Thread.Sleep(3000);
            if (driver.Url.Contains("secure"))
            {
                Console.WriteLine("✅ Test Geçti: Kullanıcı başarıyla giriş yaptı!");
            }
            else
            {
                Console.WriteLine("❌ Test Başarısız: Kullanıcı giriş yapamadı!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("⚠️ Hata oluştu: " + e.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
