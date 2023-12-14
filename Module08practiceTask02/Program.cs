using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module08practiceTask02
{
    class Program
    {
        static void Main()
        {
            var products = new Dictionary<string, decimal>
        {
            { "Хлеб", 2.00M },
            { "Молоко", 1.50M },
            { "Яйца", 2.20M },
            { "Сок", 3.00M },
            { "Яблоки", 1.80M }
        };
            DateTime currentTime = DateTime.Now;
            // Проверка на скидку (с 8:00 до 12:00)
            bool hasDiscount = currentTime.Hour >= 8 && currentTime.Hour < 12;
            Console.WriteLine("Доступные продукты:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key}: {product.Value:C}");
            }
            var cart = new List<string>();
            while (true)
            {
                Console.Write("Введите продукт : ");
                string productChoice = Console.ReadLine();
                if (productChoice.ToLower() == "конец")
                    break;
                if (products.ContainsKey(productChoice))
                {
                    cart.Add(productChoice);
                }
                else
                {
                    Console.WriteLine("Продукт не найден. Попробуйте снова.");
                }
            }
            decimal totalAmount = 0;
            foreach (var product in cart)
            {
                totalAmount += products[product];
            }
            if (hasDiscount)
            {
                decimal discount = totalAmount * 0.05M; // 5% скидка
                totalAmount -= discount;
            }
            Console.WriteLine("Сумма покупки: " + totalAmount.ToString("C"));
        }
    }

}
