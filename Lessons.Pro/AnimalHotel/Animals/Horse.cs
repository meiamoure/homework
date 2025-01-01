namespace AnimalHotel.Animals
{
    public class Horse : Animal
    {
        public Horse(string name, Owner owner, int age, string color)
            : base(name, owner, age, color) { }

        public void Neigh()
        {
            Console.WriteLine($"{Name} the horse is neighing!");
        }

        public int CompareTo(Horse? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}