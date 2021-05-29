using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace TickerWinFormApplication
{


    public class DataFeedFactory
    {

        public delegate void TradeEventHandler(string msg);
        public static event TradeEventHandler OnNewTrade;

        public delegate void OrderBookEventHandler(string msg);
        public static event OrderBookEventHandler OnNewOrderBook;


        private List<Thread> _tradeThreadList = new List<Thread> { };
        private List<Thread> _orderBookThreadList = new List<Thread> { };
             

        public DataFeedFactory()
        {

        }


        public void CreateTradeDataFeed(string symbol)
        {
            Thread newThread = new Thread(CreateTradeData);
            newThread.Start(symbol);
            _tradeThreadList.Add(newThread);
        }

        public void CreateOrderBookDataFeed(string symbol)
        {
            Thread newThread = new Thread(createOrderbookData);
            newThread.Start(symbol);
            _orderBookThreadList.Add(newThread);
        }


        public void CreateTradeData(object symbol)
        {
            while (true)
            {
                var rand = new Random();
                string volumn = rand.Next(1000, 2000).ToString();
                string price  =  rand.Next(600,700).ToString();
                var timestamp = Convert.ToString((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                
                string msgString = "{0}|{1}|{2}|{3}|{4}";
                msgString = string.Format(msgString, "T", (string) symbol, price, volumn, timestamp);
                OnNewTrade(msgString);
                
                
                Thread.Sleep(1000);
            }
        }

        public void createOrderbookData(object symbol)
        {
            var rand = new Random();
            double bestBid = 600;
            double bestAsk = 600.5;
            while (true)
            {
                string msgString = "{0}|{1}|{2}|{3}|";
                msgString = string.Format(msgString, "Q", (string)symbol, bestBid, bestAsk);
                for (int i = 0; i < 15; i++)
                {
                    string tempBidSize = rand.Next(1000,2000).ToString();
                    string tempAskSize = rand.Next(1000, 2000).ToString();
                    msgString += tempBidSize + "|" + tempAskSize + "|";
                }

                OnNewOrderBook(msgString);

                int upOrDown = rand.Next(0, 4);
                if (upOrDown >= 2)
                {
                    bestBid += 0.5;
                    bestAsk += 0.5;
                }
                else
                {
                    bestBid -= 0.5;
                    bestAsk -= 0.5;
                }
               

                Thread.Sleep(1000);

            }
        }

        public void Start()
        {
            CreateTradeDataFeed("700");
            CreateOrderBookDataFeed("700");
            CreateTradeDataFeed("9988");
            CreateOrderBookDataFeed("9988");

        }
    }
}
