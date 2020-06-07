using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Laba11
{
    public class Goods : IComparable, ICloneable, IExecutable
    {
        private int cost;
        private string name;
        private string department;
        private static int count;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Cost
        {
            get => cost;
            set
            {
                if (value >= 0)
                    cost = value;
            }
            
        }

        public string Department
        {
            get => department;
            set => department = value;
        }

        public Goods()
        {
            Random rnd = new Random();
            Name = "Unknown" + count.ToString();
            Cost =rnd.Next(1000000000);
            Department = "Shop";
            count++;
        }

        public Goods(string name, int cost, string department)
        {
            Name = name;
            Cost = cost;
            Department = department;
            count++;
        }
        
        public override string ToString()
        {
            string result = $"Name of product: {Name} \nCost: {Cost} rubles \nDepartment: {department}";
            return result;
        }

        public static void ShowGoodsByDepartment(Goods[] data, string Department)
        {
            int counter = 0;
            bool isDepartExcist = false;
            foreach (Goods good in data)
            {
                if (Department.Equals(good.Department))
                {
                    counter++;
                    Console.WriteLine($"{counter}) {good.Name}");
                    isDepartExcist = true;
                }
            }

            if (!isDepartExcist)
            {
                Console.WriteLine($"{Department} doesn't excist");
            }
        }

        public static int CountByName(Goods[] data, string name)
        {
            int result = 0;

            foreach (Goods good in data)
            {
                if (good.Name.Equals(name))
                    result++;
            }
            
            return result;
        }

        public static bool operator >(Goods good1, Goods good2)
        {
            return good1.Cost > good2.Cost;
        }
        
        public static bool operator <(Goods good1, Goods good2)
        {
            return good1.Cost < good2.Cost;
        }
        
        public static bool operator ==(Goods good1, Goods good2)
        {
            return good1.Cost == good2.Cost && good1.Name.Equals(good2.Name);
        }
        
        public static bool operator !=(Goods good1, Goods good2) 
        {
            return good1.Cost != good2.Cost && !good1.Name.Equals(good2.Name);
        }

        public int CompareTo(object obj)
        {
            Goods good1 = (Goods) this;
            Goods goods2 = (Goods) obj;
            if (good1 < goods2)
                return -1;
            if (good1 > goods2)
                return 1;
            return 0;
        }

        public virtual object Clone()
        {
            return null;
        }

        public virtual void Execute()
        {
        }

    }
}