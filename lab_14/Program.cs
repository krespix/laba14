using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Laba11;

namespace lab_14
{
    public class Program
    {
        public static TestCollection col;

        public static void Main(string[] args)
        {
            col = new TestCollection(20);
            ShowCollection(col);
            Select("Gun");
            Count("Gun");
            Sum("Gun");
            GroupBy(5000);
            MaxMin();
            Console.ReadLine();
        }


        public static void Select(string name)
        {
            Console.WriteLine($"Выборка всех товаров с заданным именем: {name}");
            
            //linq
            var linq = from toy in col.collection_1TKey where toy.Name.Equals(name) select toy;

            foreach (var item in linq)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            
            //expansion
            var expansion = col.collection_1TKey.Where(toy => toy.Name.Equals(name)).Select(toy => toy);
            foreach (var item in expansion)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine($"Одно и тоже : {expansion.Count() == linq.Count()}");
            Console.WriteLine();
        }

        public static void Count(string name)
        {
            Console.WriteLine($"Количество товара заданного именования: {name}");
            
            //linq
            var linq = (from toy in col.collection_1TKey where toy.Name.Equals(name) select toy).Count<Goods>();
            Console.WriteLine($"count by linq: {linq}");
            
            var expansion = (col.collection_1TKey.Where(toy => toy.Name.Equals(name)).Select(toy => toy)).Count<Goods>();
            Console.WriteLine($"Count by expansion : {expansion}");
            Console.WriteLine();
        }

        public static void Sum(string name)
        {
            Goods subSum(Goods a, Goods b)
            {
                b.Cost += a.Cost;
                return b;
            }
            
            Console.WriteLine($"Суммарная стоимость товара с заданным именем: {name}");

            var linq = (from toy in col.collection_1TKey where toy.Name.Equals(name) select toy.Cost).Sum();
            Console.WriteLine($"Сумма товара по линку {linq}");

            var expansion = col.collection_1TKey.Aggregate(subSum).Cost;
            Console.WriteLine($"Сумма товара по расширению {expansion}");
            Console.WriteLine();
        }

        public static void GroupBy(int lessCost)
        {
            Console.WriteLine($"Группировка по цене больше чем {lessCost}");

            var linq = from toy in col.collection_1TKey group toy by toy.Cost > lessCost;

            var expansion = col.collection_1TKey.GroupBy(toy => toy.Cost > lessCost);

            foreach (var item in linq)
            {
                Console.WriteLine(item.Key ? $"toy.cost > {lessCost} " : $"toy.Cost < {lessCost}");
                foreach (var t in item)
                {
                    Console.WriteLine(t.ToString());
                }
            }
            
            Console.WriteLine($"same {linq.Count() == expansion.Count()}");
            Console.WriteLine();
        }

        public static void MaxMin()
        {
            Console.WriteLine("Самая дешевая и самая дорогая игрушка");

            var linq = (from toy in col.collection_1TKey select toy).Max();
            var expansion = col.collection_1TKey.Select(toy => toy).Min();
            
            Console.WriteLine($"Min cost : {expansion}, \nmax cost : {linq}");
            Console.WriteLine();
        }

        public static void ShowCollection(TestCollection col)
        {
            Console.WriteLine("Collection: ");
            foreach (var item in col.collection_1TKey)
            {
                item.ToString();
            }

            Console.WriteLine();
        }
    }
    

    public class TestCollection
    {
        public List<string> collection_1Int;
        public List<Goods> collection_1TKey;
            
        public SortedDictionary<Goods, Toy> collection_2TKeyTValue;
        public SortedDictionary<string, Toy> collection_2StringTValue;
            
        public int Length;
             
        public TestCollection(int length)
        {
            // init collections 
            collection_1Int = new List<string>();
            collection_1TKey = new List<Goods>();
            collection_2StringTValue = new SortedDictionary<string, Toy>();
            collection_2TKeyTValue = new SortedDictionary<Goods, Toy>();
            
            Length = length;
            for (int i = 0; i < Length; i++)
            {
                // generate for keys collections
                Toy value = new Toy();

                Goods keyG = value.BaseGood;
                string tmpKey = keyG.ToString();
                     
                collection_1Int.Add(tmpKey);
                collection_1TKey.Add(keyG);
                collection_2StringTValue.Add(tmpKey, value);
                collection_2TKeyTValue.Add(keyG, value);
            }
        }
    }
}