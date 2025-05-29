using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _44
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Goods> goods = new List<Goods>();
            while (true)
            {
                Console.WriteLine("Выберите действие:\n" +
                    "1. Добавить товар\n" +
                    "2. Вывести сведения об товарах, выпущенных в текущем году\n" +
                    "3. Вывести наименование товаров с максимальной и минимальной общей стоимостью\n" +
                    "4. Выход\n");

                int choice = Console.ReadKey(true).KeyChar - '0';

                switch(choice)
                {
                    case 1: goods.Add(Goods.Input()); break;
                    case 2: CurrentYearProducts(goods); break;
                    case 3: OutputGoodsWithMaxAndMinCost(goods); break;
                    case 4: return;
                }
                Console.WriteLine();
            }
        }

        static void CurrentYearProducts(List<Goods> goods)
        {
            int currentYear = DateTime.Now.Year;
            List<Goods> goodsOfTheYear = goods.Where(g => g.ReleaseDate.Year == currentYear).ToList();
            int totalCost = goodsOfTheYear.Sum(g => g.Price * g.Quantity);

            OutputGoods(goodsOfTheYear);
            Console.WriteLine($"\nОбщая стоимость всех товаров: {totalCost}");
        }

        static void OutputGoodsWithMaxAndMinCost(List<Goods> goods)
        {
            List<Goods> goodsSortedByCost = goods.OrderBy(g => g.Quantity * g.Price).ToList();
            Goods minCostGoods = goodsSortedByCost.First();
            Goods maxCostGoods = goodsSortedByCost.Last();

            Console.WriteLine($"Наименование товара с минимальной общей стоимостью: {minCostGoods.Name}");
            Console.WriteLine($"Наименование товара с максимальной общей стоимостью: {maxCostGoods.Name}");
        }

        static void OutputGoods(List<Goods> goods)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"Наименование",-20} {"Изготовитель",-20} {"Кол-во",-7} {"Цена", -7} {"Год выпуска", -15}");
            Console.ResetColor();

            foreach (Goods g in goods)
            {
                Console.WriteLine(g);
            }
        }
    }
}
