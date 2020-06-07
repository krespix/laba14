using System;
using System.Threading;

namespace Laba11
{
    public class Toy : Goods
    {
        private const string department = "Toy Department";

        private int recommendedAge;
        private static int countToys;
        private Random random = new Random();

        private string[] namesOfToys = {"Toy car", "Gun", "Sniper riffle", "Cube", "Lego", "Bear", "Transformer"};
        private int[] randomAge = {0, 4, 6, 12, 16, 18, 99};

        public int RecommendedAge
        {
            get => recommendedAge;
            set
            {
                if (value > -1)
                {
                    recommendedAge = value;
                }
            }
        }

        public int CountToys => countToys;

        public Goods BaseGood
        {
            get { return new Goods{Name = this.Name, Cost = Cost, Department = department}; }
        }

        public Toy()
        {
            Thread.Sleep(50);
            int numberOfName = random.Next(1, namesOfToys.Length) - 1;
            int numberOfage = random.Next(1, randomAge.Length) - 1;
            int randomCost = random.Next(100, 10000);

            Name = namesOfToys[numberOfName];
            Cost = randomCost;
            RecommendedAge = randomAge[numberOfage];
            Department = department;
        }

        public Toy(string name, int cost, int recommendedAge, string department = department)
        : base(name, cost, department)
        {
            RecommendedAge = recommendedAge;
            countToys++;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += $"\nRecommended age: {RecommendedAge}+";
            return result;
        }

        public static Toy findCheapest(Goods[] data)
        {
            Toy cheapestToy = new Toy("", 999999999, 12);

            foreach (Goods good in data)
            {
                try
                {
                    Toy temp = good as Toy;
                    if (temp != null && temp < cheapestToy)
                    {
                        cheapestToy = (Toy) good;
                    }
                }
                catch (NullReferenceException){ }
            }

            return cheapestToy;
        }
        
        public static Toy findExpensive(Goods[] data)
        {
            Toy expensiveToy = new Toy();

            foreach (Goods good in data)
            {
                if (good is Toy && good > expensiveToy)
                {
                    expensiveToy = (Toy) good;
                }
            }

            return expensiveToy;
        }

        public override object Clone()
        {
            return new Toy(Name + "(clone)", Cost, RecommendedAge, Department);
        }
        
        public override void Execute()
        {
            Cost = 0;
            Name = "Unknown";
            Department = "Unknown";
            RecommendedAge = 0;
        }
    }
}