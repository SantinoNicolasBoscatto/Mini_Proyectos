namespace Libreria
{
    public class Operacion
    {
        public List<int> NumerosImpares { get; set; } = new();
        public int Sumar(int n1, int n2)
        {
            return n1 + n2;
        }

        public bool IsPar(int n1)
        {
            return n1 % 2 == 0;
        }

        public double SumarDecimal(double n1, double n2)
        {
            return n1 + n2;
        }

        public List<int> GetListaNumerosImpares(int minValue, int maxValue)
        {
            NumerosImpares.Clear();
            for(int i = minValue; i <= maxValue; i++)
            {
                if(i % 2 != 0)
                {
                    NumerosImpares.Add(i);
                }
            }
            return NumerosImpares;
        }
    }
}
