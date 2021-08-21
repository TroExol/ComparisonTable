using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComparisonTable.Classes
{
    public class SiteData
    {
        /// <summary>
        /// Загрузка предметов
        /// </summary>
        /// <returns>Список предметов</returns>
        public static async Task<List<Item>> LoadData(string site)
        {
            var isConfigExists = File.Exists("ComparisonTable.exe.config");
            var items = new List<Item>();
            NameValueCollection config;
            site = site.ToLower();
            List<JToken> loadedItems;
            decimal commission;
            decimal discount;

            switch (site)
            {
                case "loot.farm":
                    config = isConfigExists
                        ? (NameValueCollection) ConfigurationManager.GetSection("SitesGroup/LootFarm")
                        : new NameValueCollection();

                    if (config["Commission"] == null)
                    {
                        MessageBox.Show(@"Не удалось получить комиссию сайта LOOT.Farm", @"Ошибка");
                        break;
                    }

                    commission = Convert.ToDecimal(config["Commission"]);
                    discount = Convert.ToDecimal(config["Discount"]);

                    try
                    {
                        loadedItems = JArray.Parse(await HttpRequest.GetAsync("https://loot.farm/fullpriceRUST.json"))
                            .Children()
                            .ToList();
                    }
                    catch
                    {
                        MessageBox.Show(@"Не удалось получить предметы сайта LOOT.Farm", @"Ошибка");
                        break;
                    }

                    items = loadedItems.Select((item) =>
                    {
                        var name = item["name"].ToString();
                        var price = Convert.ToDecimal(item["price"]) / 100;
                        var priceTo = price * (1 - commission / 100);
                        var priceFrom = price * (1 - discount / 100);
                        var have = Convert.ToInt16(item["have"]);
                        var max = Convert.ToInt16(item["max"]);
                        var available = max - have;
                        return new Item(name, priceTo, priceFrom, commission, discount, have, max, available);
                    }).ToList();

                    break;

                case "swap.gg":
                    config = isConfigExists
                        ? (NameValueCollection) ConfigurationManager.GetSection("SitesGroup/SwapGG")
                        : new NameValueCollection();

                    if (config["Commission"] == null)
                    {
                        MessageBox.Show(@"Не удалось получить комиссию сайта Swap.gg", @"Ошибка");
                        break;
                    }

                    commission = Convert.ToDecimal(config["Commission"]);
                    discount = Convert.ToDecimal(config["Discount"]);

                    try
                    {
                        var result = JObject.Parse(await HttpRequest.GetAsync("https://api.swap.gg/prices/252490"));
                        if (result["status"]?.ToString() == "OK" && result["result"] != null)
                        {
                            loadedItems = result["result"].Children().ToList();
                        }
                        else
                        {
                            throw new Exception("Не удалось получить предметы сайта Swap.GG");
                        }
                    }
                    catch
                    {
                        MessageBox.Show(@"Не удалось получить предметы сайта Swap.GG", @"Ошибка");
                        break;
                    }

                    items = loadedItems.Select((item) =>
                    {
                        var name = item["marketName"].ToString();
                        var priceTo = Convert.ToDecimal(item["price"]?["sides"]?["user"]) / 100;
                        var priceFrom = Convert.ToDecimal(item["price"]?["sides"]?["bot"]) / 100;
                        var have = Convert.ToInt16(item["stock"]?["have"]);
                        var max = Convert.ToInt16(item["stock"]?["max"]);
                        var available = max - have;
                        return new Item(name, priceTo, priceFrom, commission, discount, have, max, available);
                    }).ToList();

                    break;

                case "itrade.gg":
                    config = isConfigExists
                        ? (NameValueCollection) ConfigurationManager.GetSection("SitesGroup/Itrade")
                        : new NameValueCollection();

                    if (config["Commission"] == null)
                    {
                        MessageBox.Show(@"Не удалось получить комиссию сайта ITrade.gg", @"Ошибка");
                        break;
                    }

                    commission = Convert.ToDecimal(config["Commission"]);
                    discount = Convert.ToDecimal(config["Discount"]);

                    try
                    {
                        var result =
                            JObject.Parse(
                                await HttpRequest.GetAsync("https://itrade.gg/ajax/getInventory?game=252490&type=bot"));
                        if (result["status"]?.ToString() == "success" && result["inventory"]?["items"] != null)
                        {
                            loadedItems = result["inventory"]?["items"].Children().Select(item => item.First).ToList();
                        }
                        else
                        {
                            throw new Exception("Не удалось получить предметы сайта ITrade.gg");
                        }
                    }
                    catch
                    {
                        MessageBox.Show(@"Не удалось получить предметы сайта ITrade.gg", @"Ошибка");
                        break;
                    }

                    items = loadedItems.Select((item) =>
                    {
                        List<Overstock> overstocks;
                        using (var sr = new StreamReader("../../OverstockData/ITradeOverstock.json"))
                        {
                            var json = sr.ReadToEnd();
                            overstocks = JsonConvert.DeserializeObject<List<Overstock>>(json);
                        }

                        var name = item?["displayName"]?.ToString();
                        var overstock = overstocks?.Find((itemOverstock) => itemOverstock.Name == name);
                        var price = Convert.ToDecimal(item?["price"]);
                        var priceTo = price * (1 - commission / 100);
                        var priceFrom = price * (1 - discount / 100);
                        var have = Convert.ToInt16(item?["same"]);
                        int? max = overstock?.Max;
                        int? available = max - have;
                        return new Item(name, priceTo, priceFrom, commission, discount, have, max, available);
                    }).ToList();

                    break;

                case "tradeit.gg":
                    config = isConfigExists
                        ? (NameValueCollection) ConfigurationManager.GetSection("SitesGroup/TradeIt")
                        : new NameValueCollection();

                    if (config["Commission"] == null)
                    {
                        MessageBox.Show(@"Не удалось получить комиссию сайта tradeit.gg", @"Ошибка");
                        break;
                    }

                    commission = Convert.ToDecimal(config["Commission"]);
                    discount = Convert.ToDecimal(config["Discount"]);

                    try
                    {
                        var result =
                            JObject.Parse(
                                await HttpRequest.GetAsync(
                                    "https://beta.tradeit.gg/api/v2/inventory/data?gameId=252490&fresh=false"));
                        if (result?["items"] != null)
                        {
                            loadedItems = result["items"].Children().ToList();
                        }
                        else
                        {
                            Console.WriteLine("Нет предметов на tradeit.gg");
                            throw new Exception("Не удалось получить предметы сайта tradeit.gg");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(@"Не удалось получить предметы сайта tradeit.gg", @"Ошибка");
                        MessageBox.Show(e.Message);
                        break;
                    }

                    items = loadedItems.Select((item) =>
                    {
                        var have = item.First().Count();
                        item = item.First().First;
                        
                        var name = item?["name"]?.ToString();
                        var price = Convert.ToDecimal((decimal?) item?["price"] / 100);
                        var priceTo = price * (1 - commission / 100);
                        var priceFrom = price * (1 - discount / 100);
                        // var have = Convert.ToInt16(item?["currentStock"]);
                        // int? max = Convert.ToInt16(item?["wantedStock"]);
                        // int? available = max - have;
                        return new Item(name, priceTo, priceFrom, commission, discount, have/*, max, available*/);
                    }).ToList();

                    break;

                case "cs.trade":
                    config = isConfigExists
                        ? (NameValueCollection) ConfigurationManager.GetSection("SitesGroup/CsTrade")
                        : new NameValueCollection();

                    if (config["Commission"] == null)
                    {
                        MessageBox.Show(@"Не удалось получить комиссию сайта cs.trade", @"Ошибка");
                        break;
                    }

                    commission = Convert.ToDecimal(config["Commission"]);
                    discount = Convert.ToDecimal(config["Discount"]);

                    try
                    {
                        var result =
                            JObject.Parse(await HttpRequest.GetAsync("https://cdn.cs.trade:8443/api/getInventory"));
                        if (result["status"]?.ToString() == "ok" && result["inventory"] != null)
                        {
                            loadedItems = result["inventory"].Children().ToList();
                        }
                        else
                        {
                            throw new Exception("Не удалось получить предметы сайта cs.trade");
                        }
                    }
                    catch
                    {
                        MessageBox.Show(@"Не удалось получить предметы сайта cs.trade", @"Ошибка");
                        break;
                    }

                    items = loadedItems.Where(item => item?["app_id"]?.ToString() == "252490")
                        .GroupBy(item => item?["market_hash_name"])
                        .Select((groupedItem) =>
                        {
                            var item = groupedItem.First();

                            List<Overstock> overstocks;
                            using (var sr = new StreamReader("../../OverstockData/CsTradeOverstock.json"))
                            {
                                var json = sr.ReadToEnd();
                                overstocks = JsonConvert.DeserializeObject<List<Overstock>>(json);
                            }

                            var name = item?["market_hash_name"]?.ToString();
                            var overstock = overstocks?.Find((itemOverstock) => itemOverstock.Name == name);
                            var price = Convert.ToDecimal((decimal?) item?["price"]);
                            var priceTo = price * (1 - commission / 100);
                            var priceFrom = price * (1 - discount / 100);
                            var have = groupedItem.Count();
                            int? max = overstock?.Max;
                            int? available = max - have;
                            return new Item(name, priceTo, priceFrom, commission, discount, have, max, available);
                        }).ToList();

                    break;

                case "rust.tm":
                    config = isConfigExists
                        ? (NameValueCollection) ConfigurationManager.GetSection("SitesGroup/RustTm")
                        : new NameValueCollection();

                    if (config["Commission"] == null)
                    {
                        MessageBox.Show(@"Не удалось получить комиссию сайта Rust.TM", @"Ошибка");
                        break;
                    }

                    commission = Convert.ToDecimal(config["Commission"]);
                    discount = Convert.ToDecimal(config["Discount"]);

                    try
                    {
                        var result =
                            JObject.Parse(
                                await HttpRequest.GetAsync("https://rust.tm/api/v2/prices/class_instance/USD.json"));
                        if (Convert.ToBoolean(result["success"]))
                        {
                            loadedItems = result["items"]?.Children().Children().ToList();
                        }
                        else
                        {
                            throw new Exception("Не удалось получить предметы сайта Rust.TM");
                        }
                    }
                    catch
                    {
                        MessageBox.Show(@"Не удалось получить предметы сайта Rust.TM", @"Ошибка");
                        break;
                    }

                    items = loadedItems?.Select((item) =>
                    {
                        var name = item["market_hash_name"].ToString();
                        var priceTo = Convert.ToDecimal(item["buy_order"]) * (1 - commission / 100);
                        var priceFrom = Convert.ToDecimal(item["price"]) * (1 - discount / 100);
                        return new Item(name, priceTo, priceFrom, commission, discount);
                    }).ToList();

                    break;
            }

            return items;
        }
    }

    internal class Overstock
    {
        /// <summary>
        /// Название предмета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Максимальное количество на боте
        /// </summary>
        public int Max { get; set; }

        public Overstock(string name, int max)
        {
            Name = name;
            Max = max;
        }
    }
}