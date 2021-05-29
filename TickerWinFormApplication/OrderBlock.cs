using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum OrderStatus { Partial = 2, Full = 3, Cancel = 4, Inactive = 5, Reject = -1, None = -2 }
public enum OrderSide { Long, Short };

public class OrderBlock
{
    public string AcctID;
    public string RawMsg;
    public int PID;
    public bool IsChecked = false;
    public DateTime OrderTime;
    public DateTime TransTime;
    public double Latency;
    public string Symbol;
    public string Broker;
    public OrderSide OSide;
    public double Cost;
    public int Shares;
    public OrderStatus Status = OrderStatus.None;
    public int OrderType;
    public double DealPnL;
    public double DealTurnover;
    public string Reason = "";

    public static List<OrderBlock> Parsing(string rawMessage)
    {
        //return new List<OrderBlock>();
        List<OrderBlock> orderBlocks = new List<OrderBlock>();
        string[] rawMsgs = rawMessage.Split("\r\n".ToCharArray());

        foreach (string i in rawMsgs)
        {
            if (i.Equals(""))
                continue;
            OrderBlock orderBlock = new OrderBlock();
            string[] splitArray = i.Split('|');
            for (int j = 0; j < splitArray.Length; ++j)
            {
                if (splitArray[j].StartsWith("1="))
                    orderBlock.AcctID = splitArray[j].Split('=')[1];
                //getting symbol
                if (splitArray[j].StartsWith("48="))
                    orderBlock.Symbol = splitArray[j].Split('=')[1];
                //getting order status
                else if (splitArray[j].StartsWith("39="))
                {
                    int orderStatus = int.Parse(splitArray[j].Split('=')[1]);
                    if (orderStatus == 1)
                        orderBlock.Status = OrderStatus.Partial;
                    else if (orderStatus == 2)
                        orderBlock.Status = OrderStatus.Full;
                    else if (orderStatus == 4)
                        orderBlock.Status = OrderStatus.Cancel;
                    else if (orderStatus == 8)
                        orderBlock.Status = OrderStatus.Reject;
                    else
                    {
                        orderBlock.Status = OrderStatus.None;
                        goto Skip;
                    }
                }
                //getting filled price
                else if (splitArray[j].StartsWith("31="))
                    orderBlock.Cost = double.Parse(splitArray[j].Split('=')[1]);
                //getting filled qty
                else if (splitArray[j].StartsWith("32="))
                    orderBlock.Shares = int.Parse(splitArray[j].Split('=')[1]);
                //getting order side
                else if (splitArray[j].StartsWith("54="))
                {
                    int orderSide = Int32.Parse(splitArray[j].Split('=')[1]);
                    if (orderSide == 1)
                        orderBlock.OSide = OrderSide.Long;
                    else if (orderSide == 2)
                        orderBlock.OSide = OrderSide.Short;
                }
                else if (splitArray[j].StartsWith("58="))
                    orderBlock.Reason = splitArray[j].Split('=')[1];
                else if (splitArray[j].StartsWith("60="))
                {
                    if (!splitArray[j].Equals("60="))
                        orderBlock.OrderTime = DateTime.ParseExact(splitArray[j].Split('=')[1],
                            "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                //getting user info
                else if (splitArray[j].StartsWith("URef="))
                {
                    if (!splitArray[j].Equals("URef="))
                        orderBlock.PID = int.Parse(splitArray[j].Split('=')[1]);
                    else
                        orderBlock.PID = 0;
                    if (orderBlock.Symbol != null && orderBlock.PID < 10000) // set symbol
                    {
                        orderBlock.PID = int.Parse(orderBlock.Symbol);
                    }

                }
                else if (splitArray[j].Equals("ERROR"))
                {
                    //orderBlock.Symbol = "N/A";
                    orderBlock.Reason = splitArray[j + 1];
                    if (orderBlock.Reason.Contains("INVALID_INPUT"))
                        orderBlock.Reason = "Reason: Invalid Order Size or Price";
                    if (orderBlock.Reason.Contains("DAILY_LOSS_LIMIT"))
                        orderBlock.Reason = "Reason: Daily Loss Limit";
                    if (orderBlock.Reason.Contains("MAX_ORDER_AMOUNT"))
                        orderBlock.Reason = "Reason: Max Order Amount";
                    if (orderBlock.Reason.Contains("CREDIT_CHECK_FAILURE"))
                        orderBlock.Reason = "Reason: Not Enough Credit | Inventory | DailyLimit";
                    if (orderBlock.Reason.Contains("THROTTLE"))
                        orderBlock.Reason = "Reason: Not Enough Throttle";
                    if (orderBlock.Reason.Contains("ACCT"))
                        orderBlock.Reason = "Reason: Acct Not Yet Login";
                    orderBlock.Status = OrderStatus.Reject;
                    orderBlock.Cost = double.NaN;
                    orderBlock.Shares = 0;
                }
            }
            //orderBlock.OrderTime = DateTime.Now;
            orderBlock.RawMsg = i;

        Skip:
            if (!orderBlock.Status.Equals(OrderStatus.None))
                orderBlocks.Add(orderBlock);
        }
        return orderBlocks;
    }
}