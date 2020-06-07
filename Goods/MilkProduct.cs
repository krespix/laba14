using System;
using System.Threading;

namespace Laba11
{
    public class MilkProduct : Product
    {
        private const string department = "Milk Products";
        private static int countMilkProducts;
        private int fats;
        private Random random = new Random();

        public static int CountMilkProducts => countMilkProducts;

        private string[] namesOfMilk = {"Milk", "Tvorog", "Cheese", "Gauda cheese", "Rokphor cheese", "Yogurt", "Kefir"};

        public int Fats
        {
            get => fats;
            set
            {
                if (value > -1 && value < 100)
                {
                    fats = value;
                }
            }
        }
        
        public Product BaseGood
        {
            get { return new Product{Name = "KeyName" + countMilkProducts}; }
        }

        public MilkProduct() : base()
        {
            Thread.Sleep(50);
            int numberOfName = random.Next(1, namesOfMilk.Length) - 1;
            int fats = random.Next(0, 99);

            Name = namesOfMilk[numberOfName];
            Fats = fats;
            countMilkProducts++;
        }

        public MilkProduct(string name, int cost, DateTime productionDate, int shelfLife, int fats,
            string department = department)
            : base(name, cost, productionDate, shelfLife, department)
        {
            Fats = fats;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += $"\nShare of fats: {Fats}%";
            return result;
        }
        
        public override object Clone()
        {
            return new MilkProduct(Name + "(clone)", Cost, ProductionDate, ShelfLife, Fats, Department);
        }

        public override void Execute()
        {
            base.Execute();
            Fats = 0;
        }
    }
}