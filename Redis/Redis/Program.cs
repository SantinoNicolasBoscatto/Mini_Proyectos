using StackExchange.Redis;


// Obtengo la BD
var redisDB = RedisBD.Connection.GetDatabase();
redisDB.StringSet("1", "Dato1"); // Guardo un valor

var value = redisDB.StringGet("1");
Console.WriteLine(value);
redisDB.KeyDelete("1");








// Esta clase se encargara de crear y conectarse a la BD de redis
public class RedisBD
{
    // Se usa para cuando se sabe que la creacion/generacion de un objeto tardara mucho
    private static Lazy<ConnectionMultiplexer> _lazyConnection;
    public static ConnectionMultiplexer Connection {get { return _lazyConnection.Value; }}

    static RedisBD()
    {
        _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            ConnectionMultiplexer.Connect("localhost")
        );
    }
}