namespace FootballAdministrationApp.Model
{
    public class Player
    {
        private static int currentId;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int WeightInKg { get; set; }
        public int SizeInCm { get; set; }
        public double MarketValue { get; set; }
        public bool IsActive { get; set; } = true;
        public int Fk_TeamId { get; set; } = 0;

        public Team Team;

        public Player()
        {
            FirstName = "Max";
            LastName = "Mustermann";
            Age = 0;
            WeightInKg = 0;
            SizeInCm = 0;
            MarketValue = 0;
            Id = currentId;
            currentId++;
        }

        public Player(string firstName, string lastName, int age, int weightInKg, int sizeInCm, double marketValue)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            WeightInKg = weightInKg;
            SizeInCm = sizeInCm;
            MarketValue = marketValue;
            Id = currentId;
            currentId++;
        }
    }
}
