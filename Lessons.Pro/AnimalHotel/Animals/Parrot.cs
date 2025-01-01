namespace AnimalHotel.Animals
{
    public class Parrot : Animal
    {
        public Parrot(string name, Owner owner, int age, string color)
            : base(name, owner, age, color) { }

        public void Speak()
        {
            Console.WriteLine($"{Name} the parrot is speaking!");
        }

        public int CompareTo(Parrot? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}