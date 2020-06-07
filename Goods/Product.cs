using System;
using System.Threading;
using Laba11;

namespace Laba11

{
    public class Product: Goods
    {
        private const string department = "Food Department";

        private DateTime productionDate;            //дата изготовления 
        private int shelfLife;                     //срок годности в часах
        private static int countProducts;                 //кол-во продуктов
        private Random random = new Random();

        private string[] namesOfProducts = {"Bread", "Sosiski", "Kolbasa", "Ketchup", "Beer", "Eggs", "Oil"};

        private DateTime[] randomDate =
        {
            new DateTime(2020, 1, 12), new DateTime(2019, 12, 30),
            new DateTime(2020, 2, 23), new DateTime(2020, 2, 14),
        };
        
        public DateTime ProductionDate
        {
            get => productionDate;
            set
            {
                if (value < DateTime.Now)
                {
                    productionDate = value;
                }
            }
        }

        public int ShelfLife
        {
            get => shelfLife;
            set
            {
                if (value >= 0)
                {
                    shelfLife = value;
                }
            }
        }
        
        public Goods BaseGood
        {
            get { return new Goods{Name = "KeyName" + countProducts}; }
        }

        public int CountProducts => countProducts;

        public Product()
        {
            Thread.Sleep(50);
            int numberOfname = random.Next(1, namesOfProducts.Length) - 1;
            int cost = random.Next(40, 500);
            int numberOfDate = random.Next(1, randomDate.Length) - 1;
            int randomShelfLife = random.Next(8, 72);

            Name = namesOfProducts[numberOfname];
            Cost = cost;
            ProductionDate = randomDate[numberOfDate];
            ShelfLife = randomShelfLife;
            Department = department;
        }

        public Product(string name, int cost, DateTime productionDate, int shelfLife, string department = department)
            : base(name, cost, department)
        {
            ProductionDate = productionDate;
            ShelfLife = shelfLife;
            countProducts++;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += $"\nProduction Date: {ProductionDate.ToString()} \nExpiration Date: {ShelfLife} hours";
            return result;
        }
        
        public override object Clone()
        {
            return new Product(Name + "(clone)", Cost, ProductionDate, ShelfLife, Department);
        }

        public override void Execute()
        {
            Cost = 0;
            Name = "Unknown";
            Department = "Unknown";
            ProductionDate = new DateTime(0,0,0);
            ShelfLife = 0;
        }
    }
}