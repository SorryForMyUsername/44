using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _44
{
    internal struct Goods
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Goods(string name, string manufacturer, int quantity, int price, DateTime releaseDate)
        {
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public static Goods Input()
        {
            Console.Write("Наименование: ");
            string name = Console.ReadLine();
            Console.Write("Изготовитель: ");
            string manufacturer = Console.ReadLine();
            Console.Write("Количество: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Цена: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Дата выпуска: ");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());
            return new Goods(name, manufacturer, quantity, price, releaseDate);
        }

        public override string ToString()
        {
            return $"{Name, -20} {Manufacturer,-20} {Quantity,7} {Price,7} {ReleaseDate,10:dd.MM.yyyy}";
        }
    }
}
