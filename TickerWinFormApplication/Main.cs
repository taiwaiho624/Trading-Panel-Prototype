using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;





namespace TickerWinFormApplication
{
    public partial class Main : Form
    {

        public static List<Trade> TradeList = new List<Trade>();
        public static PnL PnlForm = null;

        public BlockingCollection<string> TradeResponseCollection = new BlockingCollection<string>();
        public BlockingCollection<string> OrderResonseCollection = new BlockingCollection<string>();
        private Thread updateThread;
        private Thread updateThread2;
        private Thread recvThread;

        public static TCPConn TcpClient;

        public static List<OrderBlock> FilledOrders = new List<OrderBlock> { };
        public static OrderProcessor MyOrderProcessor = new OrderProcessor();

        public Main()
        {
            InitializeComponent();

            StartVirtualDataFeed();

            TcpClient = new TCPConn("127.0.0.1", 9999, "VirtualDatafeed");


            updateThread = new Thread(UpdateUI);
            updateThread2 = new Thread(UpdateUI2);

            recvThread = new Thread(RecvData);

            updateThread.Start();
            updateThread2.Start();

            recvThread.Start();


            Trade tradeForm = new Trade("700");
            TradeList.Add(tradeForm);
            tradeForm.Show();

            PnlForm = new PnL();
            PnlForm.Show();
        }


        public void StartVirtualDataFeed()
        {
            DataFeedFactory factory;
            TCPServer tcpServer;

            Thread datafeedThread;
            Thread tcpServerThread;

            factory = new DataFeedFactory();
            tcpServer = new TCPServer();

            datafeedThread = new Thread(factory.Start);
            tcpServerThread = new Thread(tcpServer.Start);

            datafeedThread.Start();
            tcpServerThread.Start();
        }

     



        public void RecvData()
        {
            byte[] bytes = new byte[4096];

            while (true)
            {
                try
                {
                    string data = TcpClient.GettingDataStream();
                    string[] tokens = data.Split('|');
                    if (tokens[0] == "T" || tokens[0] == "Q")
                    {
                        TradeResponseCollection.Add(data);
                        if (PnlForm != null)
                            PnlForm.UpdateUnRealizedPnl(data);
                    }
                    else
                    {
                        OrderResonseCollection.Add(data);
                    }
                }
                catch (Exception ex)
                {
                    TcpClient.Close();
                    TcpClient = null;
                    break;
                }
            }
        }



        public void UpdateUI(){
            while (true)
            {
                string msg = TradeResponseCollection.Take();
                string[] tokens = msg.Split('|');
                foreach (Trade component in TradeList)
                {
                    if (component.Symbol == tokens[1])
                    {
                        if (tokens[0] == "T")
                        {
                            component.UpdateTradeRecordDataGridView(msg);
                        }
                        else if (tokens[0] == "Q")
                        {
                            component.UpdateOrderBook(msg);
                            component.UpdateBidAskLabel(msg);
                        }
                    }
                }                
            }
        }

        public void UpdateUI2()
        {
            while (true)
            {
                string msg = OrderResonseCollection.Take();
                List<OrderBlock> orders = OrderBlock.Parsing(msg);
                foreach (OrderBlock order in orders)
                {
                    FilledOrders.Add(order);
                    MyOrderProcessor.PlaceOrder(order);
                }
                foreach (Trade component in TradeList)
                {
                    component.UpdateTradedOrderDataGridView();
                }
                if (PnlForm != null)
                {
                    PnlForm.UpdatePnlDataGridView();
                    PnlForm.UpdateTradeOrderDataGridView();
                }


            }
        }




        private void TradePanel_Click(object sender, EventArgs e)
        {
            Trade tradeForm = new Trade("700");
            TradeList.Add(tradeForm);
            tradeForm.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                recvThread.Abort();
                updateThread.Abort();
            }
            catch (Exception)
            {
                Environment.Exit(0);

            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

        private void PnLPanelButton_Click(object sender, EventArgs e)
        {
            if (PnlForm == null)
            {
                PnlForm = new PnL();
                PnlForm.Show();
            }

        }


    }
}
