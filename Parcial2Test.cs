// Gregorio Javier Corcio Flores
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

[TestFixture]
public class Parcial2Test
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;

    [SetUp]
    public void SetUp()
    {
        driver = new FirefoxDriver(); // Inicializa Firefox
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }

    [TearDown]
    protected void TearDown()
    {
        driver.Quit(); // Cierra el navegador después de la prueba
    }

    [Test]
    public void parcial2()
    {
        driver.Navigate().GoToUrl("http://localhost/Login-Sites-Index/");
        driver.Manage().Window.Size = new System.Drawing.Size(550, 691);

        // Repetir las acciones 100 veces
        for (int i = 0; i < 100; i++)
        {
            // Acción 1: Hacer clic en el campo UserMailLogin y escribir el correo
            driver.FindElement(By.Name("UserMailLogin")).Click();
            driver.FindElement(By.Name("UserMailLogin")).SendKeys("gregcorcio@gmail.com");

            // Acción 2: Hacer clic en el campo UserPasswordLogin y escribir la contraseña
            driver.FindElement(By.Name("UserPasswordLogin")).Click();
            driver.FindElement(By.Name("UserPasswordLogin")).SendKeys("hola12345");

            // Acción 3: Hacer clic en el botón de envío (el que está en la posición 9 del selector CSS)
            driver.FindElement(By.CssSelector("input:nth-child(9)")).Click();

            // Esperar un segundo entre las iteraciones (si es necesario para que las acciones sean visibles)
            Thread.Sleep(1000); // Ajusta el tiempo si es necesario
        }
    }
}
