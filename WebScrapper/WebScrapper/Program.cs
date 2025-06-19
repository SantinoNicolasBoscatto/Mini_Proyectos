using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

string[] files = Directory.GetFiles("./");

var options = new ChromeOptions();
string extensionPath = "./Adguard.crx";
options.AddExtension(extensionPath);
options.AddArgument("--log-level=3");
IWebDriver driver = new ChromeDriver(options);

Thread.Sleep(5000);
var tabsOriginal = driver.WindowHandles;
((IJavaScriptExecutor)driver).ExecuteScript("window.close();");
driver.SwitchTo().Window(tabsOriginal[1]);

Console.WriteLine("Ingrese la URL de la serie a descargar: ");
var link = Console.ReadLine();
Console.WriteLine("Ingrese la temporada a descargar");
var season = Console.ReadLine();

if (string.IsNullOrEmpty(link))
{
    Console.WriteLine("La URL no puede estar vacía.");
    return;
}
if (string.IsNullOrEmpty(season))
{
    Console.WriteLine("La Temporada no puede ser la 0");
    return;
}
await driver.Navigate().GoToUrlAsync(link);

var selectElement = new SelectElement(driver.FindElement(By.Id("select-season")));
Thread.Sleep(5000);
selectElement.SelectByValue(season);
var result = driver.FindElements(By.CssSelector("li.TPostMv article a"));
var originalTab = driver.CurrentWindowHandle;
var counter = 0;

List<string> links = new List<string>();
foreach (var item in result)
{
    var href = item.GetAttribute("href");
    links.Add(href!);
}


foreach (var href in links)
{
    counter++;
    driver.Navigate().GoToUrl(href!);

    Thread.Sleep(2500);
    var buttons = driver.FindElements(By.ClassName("STPb"));
    var dodoStream = buttons[1];

    var dodoStreamUrl = dodoStream.GetAttribute("href");
    driver.Navigate().GoToUrl(dodoStreamUrl!);

    Thread.Sleep(2500);
    var preDownloadButton = driver.FindElement(By.CssSelector("a.btn.btn-primary.download_vd"));
    if (preDownloadButton == null)
    {
        Console.WriteLine($"No se pudo descargar el capitulo numero {counter}");
        break;
    }
    preDownloadButton.Click();
    Thread.Sleep(6500);
    var downloadButton = driver.FindElements(By.CssSelector("a.btn.btn-primary.d-flex.align-items-center.justify-content-between"));
    if (!downloadButton.Any())
    {
        Console.WriteLine($"No se pudo descargar el capitulo numero {counter}");
        continue;
    }
    downloadButton[0].Click();
    Thread.Sleep(5000);
    var finalDownloadButton = driver.FindElements(By.CssSelector("a.btn.btn-primary.d-flex.align-items-center.justify-content-between"));
    if (!finalDownloadButton.Any())
    {
        Console.WriteLine($"No se pudo descargar el capitulo numero {counter}");
        continue;
    }
    finalDownloadButton[0].Click();

}