using PuppeteerSharp;

// Guardamos la URL a consultar y la ubicacion de nuestro navegador
string url = "https://www.promiedos.com.ar/";
string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

// Configuramos el navegador que usara Puppeter para realizar las consultas a las URL
var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = true,
    ExecutablePath = chromePath,
});


// Creamos la pagina que realizara la consulta desde el navegador y Realizamos la navegacion
var page = await browser.NewPageAsync();
await page.GoToAsync(url);

// Aqui ejecutaremos codigo JS para seleccionar la data que necesitemos de la pagina
var result = await page.EvaluateFunctionAsync(@"()=> 
    {
        const titles = document.querySelectorAll('.command_title__sMlhS');
        const titleArray = [];
        for(let i=0; i < titles.length; i++)
        {
            titleArray.push(titles[i].innerHTML);
        } 
        return titleArray;
    }");

for (int i = 0; i < result.Value.GetArrayLength(); i++)
{
    Console.WriteLine(result.Value[i]);
}