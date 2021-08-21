using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComparisonTable.Classes;
// using Websocket.Client;
using WebSocketSharp;

namespace ComparisonTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var sites = new object[]
            {
                "loot.farm",
                "swap.gg",
                "itrade.gg",
                "rust.tm",
                "cs.trade",
                "tradeit.gg"
            };
            
            siteToCB.Items.AddRange(sites);
            siteFromCB.Items.AddRange(sites);
        }
        
        private async void loadTable_Click(object sender, EventArgs e)
        {
            // TODO: подключиться к вебсокету RustyTrade
            // WebSocket ws = new WebSocket("wss://rustytrade.com/socket.io/?EIO=3&transport=websocket&sid=f5PX1NBclmhK4g6sACH1");
            //
            // ws.OnMessage += (object2, ev) => MessageBox.Show("answer: " + ev.Data);
            // ws.OnOpen += (sender2, ev) =>
            // {
            //     ws.Send("2probe");
            // };
            // ws.OnError += (sender2, ev) =>
            // {
            //     MessageBox.Show("Error during Websocket Connection: " + ev.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     ws.Close();
            //     ws = null;
            // };
            //
            // ws.Connect();
            // return;
            // var exitEvent = new ManualResetEvent(false);
            // var url = new Uri("wss://rustytrader.com/socket.io/?EIO=3&transport=websocket&sid=Cb5uSSvj1c43Yn8YAAEz");
            //
            // using (var client = new WebsocketClient(url))
            // {
            //     client.ReconnectTimeout = TimeSpan.FromSeconds(30);
            //
            //     client.ReconnectionHappened.Subscribe(info =>
            //         MessageBox.Show($"Reconnection happened, type: {info.Type}"));
            //     client.MessageReceived.Subscribe(msg => MessageBox.Show($"Message received: {msg}"));
            //     
            //     await client.Start();
            //
            //     await Task.Run(() => client.Send("42[\"get bots inv\"]"));
            //
            //     exitEvent.WaitOne();
            // }
            //
            // return;
            var siteFrom = (string) siteFromCB.SelectedItem;
            var siteTo = (string) siteToCB.SelectedItem;
            var minCountHaveFrom = Convert.ToInt16(minCountHaveSiteFrom.Text != "" ? minCountHaveSiteFrom.Text : "0");
            var minCountHaveTo = Convert.ToInt16(minCountHaveSiteTo.Text != "" ? minCountHaveSiteTo.Text : "0");
            var isNonOverstockFrom = isNotOvestockFrom.Checked;
            var isNonOverstockTo = isNotOvestockTo.Checked;

            var loadedDataFrom = await SiteData.LoadData(siteFrom);
            var loadedDataTo = await SiteData.LoadData(siteTo);


            var table = new DataTable();
            table.Columns.Add(new DataColumn("Название", typeof(string)));
            table.Columns.Add(new DataColumn("Цена 1 сервиса, $", typeof(decimal)));
            table.Columns.Add(new DataColumn("На 1 сервисе", typeof(string)));
            table.Columns.Add(new DataColumn("Цена 2 сервиса, $", typeof(decimal)));
            table.Columns.Add(new DataColumn("На 2 сервисе", typeof(string)));
            table.Columns.Add(new DataColumn("Профит 1 -> 2", typeof(decimal)));
            table.Columns.Add(new DataColumn("Профит 2 -> 1", typeof(decimal)));

            // Добавление данных в таблицу
            loadedDataFrom.ForEach((itemFrom) =>
            {
                var findedItemTo = loadedDataTo.Find((itemTo) => itemFrom.Name == itemTo.Name);
                if (findedItemTo != null)
                {
                    var itemTo = findedItemTo;
                    var profit1To2 = Item.CalcProfit(itemFrom, itemTo);
                    var profit2To1 = Item.CalcProfit(itemTo, itemFrom);

                    if (minCountHaveFrom != 0 && itemFrom.Have < minCountHaveFrom)
                    {
                        return;
                    }

                    if (minCountHaveTo != 0 && itemTo.Have < minCountHaveTo)
                    {
                        return;
                    }

                    if (isNonOverstockFrom && itemFrom.Available <= 0)
                    {
                        return;
                    }

                    if (isNonOverstockTo && itemTo.Available <= 0)
                    {
                        return;
                    }

                    table.Rows.Add(itemFrom.Name, itemFrom.PriceFrom,
                        itemFrom.Have + " шт. [" + itemFrom.Available + "]", itemTo.PriceTo,
                        itemTo.Have + " шт. [" + itemTo.Available + "]", profit1To2, profit2To1);
                }
            });

            comparisonTable.DataSource = table;
            comparisonTable.Sort(comparisonTable.Columns[table.Columns.Count - 2], ListSortDirection.Descending);
        }

        private void reverseSites_Click(object sender, EventArgs e)
        {
            var selectedFrom = siteFromCB.SelectedIndex;
            var selectedTo = siteToCB.SelectedIndex;

            siteFromCB.SelectedIndex = selectedTo;
            siteToCB.SelectedIndex = selectedFrom;
        }
    }
}