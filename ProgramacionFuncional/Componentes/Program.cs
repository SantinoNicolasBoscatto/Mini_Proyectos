




public interface IA
{

}

public class A // Componente A
{
    private readonly B _b;
    public A(B b)
    {
        _b = b;
    }
}
public class B // Componente B
{
    private readonly C _c;
    public B(C c)
    {
        _c = c;
    }
}

public class C // Componente C
{
    private readonly IA _a;
    public C(IA a)
    {
        _a = a;
    }
}