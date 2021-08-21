using System;
using static System.Decimal;

namespace ComparisonTable.Classes
{
    /// <summary>
    /// Предмет с сайта
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Название предмета
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена, если вносить на сайт
        /// </summary>
        public decimal PriceTo { get; set; }
        /// <summary>
        /// Цена, если выводить с сайта
        /// </summary>
        public decimal PriceFrom { get; set; }
        /// <summary>
        /// Комиссия сервиса
        /// </summary>
        public decimal Commission { get; set; }
        /// <summary>
        /// Скидка сервиса
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// Сколько имеется копий на боте
        /// </summary>
        public int? Have { get; set; }
        /// <summary>
        /// Максимальное количество предметов на боте
        /// </summary>
        public int? Max { get; set; }
        /// <summary>
        /// Доступно для занесения на сайт
        /// </summary>
        public int? Available { get; set; }
        
        public Item(string name, decimal priceTo, decimal priceFrom, decimal commission, decimal discount, int? have = null,
            int? max = null, int? available = null)
        {
            Name = name;
            PriceTo = Round(priceTo, 2);
            PriceFrom = Round(priceFrom, 2);
            Commission = Round(commission, 2);
            Discount = Round(discount, 2);
            Have = have;
            Max = max;
            Available = available;
        }

        /// <summary>
        /// Вычисление профита
        /// </summary>
        /// <param name="itemFrom">Предмет для вывода</param>
        /// <param name="itemTo">Предмет для депозита</param>
        /// <returns>Профит</returns>
        public static decimal CalcProfit(Item itemFrom, Item itemTo)
        {
            decimal profit;
            decimal priceFrom = itemFrom.PriceFrom;
            decimal priceTo = itemTo.PriceTo;
            /*price1 = 1.16 // сайт 1
            price1_1 = 1.16 // сайт 1 со скидкой
            price2 = 1.33 // сайт 2
            price2_2 = 1.33 // сайт 2 со скидкой
            dif1 = 5 // комиссия сайт 2
            dif2 = 3*/ // Комиссия сайт 1
                // Math.round(((1 - dif1 / 100) * price2 - price1_1) / Math.max(price1_1, (1 - dif1 / 100) * price2) * 10000) / 100;
            profit = Math.Round((priceTo - priceFrom) / Math.Max(priceFrom, priceTo) * 10000) / 100;

            return Round(profit, 2);
        }

        public override string ToString()
        {
            return Name + ", Цена: " + PriceTo;
        }
    }
}