using Polly;
using Polly.Timeout;



var number = 0;
var policyResult = await Policy.Handle<Exception>()
.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)),
(ex, retryTime, intento, context) => Console.WriteLine("Se va a Ejecutar el Intento: " + intento))
.ExecuteAndCaptureAsync(async () =>
{
    if (number != 4)
    {
        number++;
        throw new Exception("Error masivo");
    }

});
if (policyResult.FinalException != null) Console.WriteLine("Hubo un error: " + policyResult.FinalException.Message);
else Console.WriteLine("Todo OK");



//try
//{
//    await Policy.TimeoutAsync(TimeSpan.FromMilliseconds(500), TimeoutStrategy.Pessimistic).ExecuteAsync(async () =>
//    {
//        var client = new HttpClient();
//        var resp = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
//        var content = await resp.Content.ReadAsStringAsync();
//        Console.WriteLine(content);
//    });
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}