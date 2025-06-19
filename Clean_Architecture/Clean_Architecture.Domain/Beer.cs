namespace Clean_Architecture.Domain
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Style { get; set; }
        public decimal Alcohol { get; set; }

        public bool IsStrongBeer() => Alcohol >= strongBeer; 
        private const decimal strongBeer = 7.5m;
    }
}
