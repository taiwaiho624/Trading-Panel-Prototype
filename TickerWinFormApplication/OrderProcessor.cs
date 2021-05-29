using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class TradInfo
{
    public string Symbol;
    public double PnL;
    public double UnrealPnL;
    public int PtsSize;
    public double AvgCost;
    public double Turnover;
}


// O(1) Complexity in Updating
public class OrderProcessor
{
    private Dictionary<string, List<OrderBlock>> m_s2Orders = new Dictionary<string, List<OrderBlock>>();
    private Dictionary<string, TradInfo> m_s2TradInfo = new Dictionary<string, TradInfo>();
    private Dictionary<string, int> m_s2LastRecordIndex = new Dictionary<string, int>();

    public TradInfo PlaceOrder(OrderBlock order)
    {
        if (m_s2Orders.ContainsKey(order.Symbol))
            m_s2Orders[order.Symbol].Add(order);
        else
            m_s2Orders.Add(order.Symbol, new List<OrderBlock>() { order });
        return ProcessOrders(order.Symbol);
    }

    public Dictionary<string, TradInfo> ReturnS2TradInfo()
    {
        return m_s2TradInfo;
    }

    public Dictionary<string, List<OrderBlock>> ReturnS2OrderBlocks()
    {
        return m_s2Orders;
    }

    public List<OrderBlock> ReturnOrderBlocks()
    {
        List<OrderBlock> orderblocks = new List<OrderBlock>();
        foreach (KeyValuePair<string, List<OrderBlock>> i in m_s2Orders)
            orderblocks.AddRange(i.Value);
        return orderblocks;
    }

    public double CompUnrealized(double bid, double ask, TradInfo info)
    {
        if (bid.Equals(double.NaN) || ask.Equals(double.NaN))
            return double.NaN;
        if (info.PtsSize == 0)
            return 0;

        double unrealized = double.NaN;
        if (info.PtsSize > 0)
            unrealized = (bid - info.AvgCost) * info.PtsSize;
        else if (info.PtsSize < 0)
            unrealized = (info.AvgCost - ask) * info.PtsSize;
        return unrealized;
    }

    public TradInfo CheckTradingInfo(string symbol)
    {
        if (!m_s2TradInfo.ContainsKey(symbol))
            m_s2TradInfo.Add(symbol, new TradInfo());
        return m_s2TradInfo[symbol];
    }

    private TradInfo ProcessOrders(string symbol)
    {
        List<OrderBlock> orders = m_s2Orders[symbol];
        TradInfo info = CheckTradingInfo(symbol);
        info.Symbol = symbol;
        double avgCost = info.AvgCost;
        int curPtsSize = info.PtsSize;

        if (!m_s2LastRecordIndex.ContainsKey(symbol))
            m_s2LastRecordIndex.Add(symbol, 0);
        int lastRecordIndex = m_s2LastRecordIndex[symbol];
        for (int i = lastRecordIndex; i < orders.Count; ++i)
        {
            if (orders[i].OSide.Equals(OrderSide.Long))
            {
                if (curPtsSize >= 0)
                {
                    avgCost = ((avgCost * Math.Abs(curPtsSize) +
                        orders[i].Cost * orders[i].Shares) / (Math.Abs(curPtsSize) + orders[i].Shares));
                    curPtsSize += orders[i].Shares;
                }
                else
                {
                    int originalShares = Math.Abs(curPtsSize);
                    curPtsSize += orders[i].Shares;
                    orders[i].DealPnL = Math.Min(originalShares, orders[i].Shares) * (avgCost - orders[i].Cost) * 1.0;

                    if (curPtsSize == 0)
                        avgCost = 0;
                    else if (originalShares < Math.Abs(orders[i].Shares))
                        avgCost = orders[i].Cost;
                }
            }
            else if (orders[i].OSide.Equals(OrderSide.Short))
            {
                if (curPtsSize <= 0)
                {
                    avgCost = ((avgCost * Math.Abs(curPtsSize) +
                        orders[i].Cost * orders[i].Shares) / (Math.Abs(curPtsSize) + orders[i].Shares));
                    curPtsSize -= orders[i].Shares;
                }
                else
                {
                    int originalShares = Math.Abs(curPtsSize);
                    curPtsSize -= orders[i].Shares;
                    orders[i].DealPnL = Math.Min(originalShares, orders[i].Shares) * (orders[i].Cost - avgCost) * 1.0;

                    if (curPtsSize == 0)
                        avgCost = 0;
                    else if (originalShares < Math.Abs(orders[i].Shares))
                        avgCost = orders[i].Cost;
                }
            }
            info.PnL += Math.Round(orders[i].DealPnL, 3);
            if (orders[i].OrderTime.Hour != 0)
                info.Turnover += orders[i].Cost * orders[i].Shares;
        }

        m_s2LastRecordIndex[symbol] = orders.Count;
        info.AvgCost = avgCost;
        info.PtsSize = curPtsSize;
        return info;
    }

}