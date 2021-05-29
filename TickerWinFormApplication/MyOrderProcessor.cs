using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickerWinFormApplication
{
    class MyOrderProcessor
    {
        private OrderProcessor _orderProcessor;

        public double ReturnTotalPnl()
        {
            double totalPnl = 0;
            foreach (var tradeInfo in _orderProcessor.ReturnS2TradInfo().Values){
                totalPnl += tradeInfo.PnL;
            }
            return totalPnl;
        }
    }
}
