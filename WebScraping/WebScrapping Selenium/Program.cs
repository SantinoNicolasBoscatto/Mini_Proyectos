using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


// Esto lo que hara sera ejecutar y abrir el navegador. Luego ponemos la URL a la que queremos ir
IWebDriver driver = new ChromeDriver();
await driver.Navigate().GoToUrlAsync("https://www.promiedos.com.ar/");

// Busco los elementos que quiero capturar
var result = driver.FindElements(By.ClassName("command_title__sMlhS"));

foreach (var element in result)
{
    Console.WriteLine(element.Text);
}