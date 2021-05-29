using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace TickerWinFormApplication
{
    public partial class Trade : Form
    {

        public double LastTradedPrice{get;set;}

        private List<int> _lowestAskSize;
        private List<int> _lowestBidSize;

        private string _symbol;
        public string Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
                this.Text = _symbol;
                SymbolTextBox.Text = _symbol;

            }
        }

        public Trade(string symbol)
        {
            InitializeComponent();

            this.Symbol = symbol;
            SymbolTextBox.Text = symbol;

            TradeRecordDataGridView.Columns.Add("price", "Price");
            TradeRecordDataGridView.Columns.Add("quantity", "Qty");
            TradeRecordDataGridView.Columns.Add("chanel", "C");
            TradeRecordDataGridView.Columns.Add("time", "Time");

            TradeRecordDataGridView.Columns[0].Width = (int)(splitContainer2.Panel2.Width * 0.2);
            TradeRecordDataGridView.Columns[1].Width = (int)(splitContainer2.Panel2.Width * 0.3);
            TradeRecordDataGridView.Columns[2].Width = (int)(splitContainer2.Panel2.Width * 0.1);
            TradeRecordDataGridView.Columns[3].Width = (int)(splitContainer2.Panel2.Width * 0.4);

            TradedOrderDataGridView.Columns.Add("datetime", "Date");
            TradedOrderDataGridView.Columns.Add("action", "Action");
            TradedOrderDataGridView.Columns.Add("symbol", "Symbol");
            TradedOrderDataGridView.Columns.Add("price&quantity", "Price@Qty");
            TradedOrderDataGridView.Columns.Add("status", "Status");


            OrderTypeComboBox.Items.Add("Limit");
            OrderTypeComboBox.Items.Add("Market");
            OrderTypeComboBox.SelectedIndex = OrderTypeComboBox.Items.IndexOf("Limit");

            TradedOrderDataGridView.Columns[0].Width = (int)(splitContainer4.Panel1.Width * 0.25);
            TradedOrderDataGridView.Columns[1].Width = (int)(splitContainer4.Panel1.Width * 0.16);
            TradedOrderDataGridView.Columns[2].Width = (int)(splitContainer4.Panel1.Width * 0.16);
            TradedOrderDataGridView.Columns[3].Width = (int)(splitContainer4.Panel1.Width * 0.25);
            TradedOrderDataGridView.Columns[4].Width = (int)(splitContainer4.Panel1.Width * 0.18);

            TradedOrderDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public void UpdateTradeRecordDataGridView(string msg)
        {
            var rand = new Random();
            string[] tokens = msg.Split('|');
            var time = Helper.UnixTimeStampToDateTime(Convert.ToDouble(tokens[4])).ToString("HH:mm:ss");
            String[] row = new String[] { tokens[2], tokens[3], "H", time };
            TradeRecordDataGridView.BeginInvoke(new Action(() =>
            {
                TradeRecordDataGridView.Rows.Insert(0, row);
                var randNum = rand.Next(0, 2);

                if (randNum > 0)
                {
                    TradeRecordDataGridView.Rows[0].DefaultCellStyle.ForeColor = Color.Green;
                }
                else
                {
                    TradeRecordDataGridView.Rows[0].DefaultCellStyle.ForeColor = Color.Red;

                }
            }));

            LastTradedPrice = Convert.ToDouble(tokens[2]);
        }

        public void UpdateOrderBook(string msg){


            string[] tokens = msg.Split('|');

            double upSpread = SpreadTable.ReturnUpSpread(LastTradedPrice);
            double downSpread = SpreadTable.ReturnDownSpread(LastTradedPrice);

            double BidPrice1 = Math.Round(Convert.ToDouble(tokens[2]), 4);
            double AskPrice1 = Math.Round(Convert.ToDouble(tokens[3]), 4);

            List<double> BidPrice = new List<double> { };
            List<double> AskPrice = new List<double> { };
            List<int> BidSize = new List<int> { };
            List<int> AskSize = new List<int> { };

            int BidSizeSum = 0;
            int AskSizeSum = 0;


            for (int i = 0; i < 15; i++)
            {
                double tempBid = Math.Round( (BidPrice1 - downSpread * i), 4);
                double tempAsk = Math.Round( (AskPrice1 + upSpread * i), 4);
                int tempBidSize = Convert.ToInt32(tokens[4 + 2 * i]);
                int tempAskSize = Convert.ToInt32(tokens[5 + 2 * i]);
                BidPrice.Add(tempBid);
                AskPrice.Add(tempAsk);
                BidSize.Add(tempBidSize);
                AskSize.Add(tempAskSize);
                BidSizeSum += tempBidSize;
                AskSizeSum += tempAskSize;
            }

            UpdateBidAskBar(BidSizeSum, AskSizeSum);



            DataTable AskTable = new DataTable();
            DataTable BidTable = new DataTable();

            AskTable.Columns.Add("Price", typeof(double));
            AskTable.Columns.Add("Qty", typeof(int));

            BidTable.Columns.Add("Price", typeof(double));
            BidTable.Columns.Add("Qty", typeof(int));

            for (int i= 0 ; i<15; i++){
                AskTable.Rows.Add(AskPrice[i], AskSize[i]);
                BidTable.Rows.Add(BidPrice[i], BidSize[i]);
            }


            AskDataGridView.BeginInvoke(new Action(() =>
            {
                AskDataGridView.DataSource = AskTable;
            }));

            BidDataGridView.BeginInvoke(new Action(() =>
            {
                BidDataGridView.DataSource = BidTable;
            }));

            AskSize.Sort();
            BidSize.Sort();
            _lowestAskSize = new List<int> { AskSize[0], AskSize[1], AskSize[2]};
            _lowestBidSize = new List<int> { BidSize[0], BidSize[1], BidSize[2] };
        }

        public void UpdateBidAskBar(int BidSize, int AskSize)
        {
            int containerWidth = BidAskBarSplitContainer.Width;
            double BidPercentage = (double)BidSize / (double)( BidSize + AskSize);
            int BidSizeString = (int) (BidPercentage * 100);
            int AskSizeString = (int)(100 - BidSizeString);
            int barLength = (int)(containerWidth * BidPercentage);

            BidAskBarSplitContainer.BeginInvoke(new Action(() =>
            {
                BidAskBarSplitContainer.SplitterDistance = barLength;
                BidAskBarSplitContainer.IsSplitterFixed = true;
                BidSizeLabel.Text = BidSizeString.ToString() + "%";
                AskSizeLabel.Text = AskSizeString.ToString() + "%";

            }));
        }





        public void UpdateBidAskLabel(string msg)
        {
            string[] tokens = msg.Split('|');

            double bestBid = Convert.ToDouble(tokens[2]);
            double bestAsk = Convert.ToDouble(tokens[3]);
            string bestBidString = String.Format("{0:0.##}", bestBid);
            string bestAskString = String.Format("{0:0.##}", bestAsk);

            BestBidLabel.BeginInvoke(new Action(() =>
            {
                BestBidLabel.Text = bestBidString;
            }));
            BestAskLabel.BeginInvoke(new Action(() =>
            {
                BestAskLabel.Text = bestAskString;
            }));

        }

        public void UpdateTradedOrderDataGridView()
        {
            TradedOrderDataGridView.BeginInvoke(new Action(() =>
            {
                TradedOrderDataGridView.Rows.Clear();
            }));
            for (int i = Main.FilledOrders.Count -1 ; i >= 0; i--)
            {
                OrderBlock order = Main.FilledOrders[i];
                string time = order.OrderTime.ToString("yyyy-MM-dd");
                OrderSide direction = order.OSide;
                string symbol = order.Symbol;
                OrderStatus status = order.Status;
                double price = order.Cost;
                int qty = order.Shares;


                string action = "";
                if (direction == OrderSide.Short)
                {
                    action = "S";
                }
                else
                {
                    action = "B";
                }

                string priceAndQty = Convert.ToString(price) + "@" + Convert.ToString(qty);

                string orderStatus = "";
                if (status == OrderStatus.Full)
                {
                    orderStatus = "FILLED";
                }

                TradedOrderDataGridView.BeginInvoke(new Action(() =>
                {
                    TradedOrderDataGridView.Rows.Add(time, action, symbol, priceAndQty, orderStatus);
                }));
            }
            //TradedOrderDataGridView.BeginInvoke(new Action(() =>
            //{
            //    TradedOrderDataGridView.AutoResizeColumns();

            //}));
        }



        public void Reset()
        {
            TradeRecordDataGridView.Rows.Clear();
            AskDataGridView.DataSource = null;
            BidDataGridView.DataSource = null;
            BestAskLabel.Text = "";
            BestBidLabel.Text = "";
            PriceTextBox.Text = "";
            QuantityTextBox.Text = "";
        }

        public void ResetPriceAndQuantity()
        {
            PriceTextBox.Text = "";
            QuantityTextBox.Text = "";
        }

        private void Trade_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.TradeList.Remove(this);
        }

        private void SymbolTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                Reset();
                Symbol = SymbolTextBox.Text;
            }
        }


        private void BuyButton_Click(object sender, EventArgs e)
        {
            string symbol = SymbolTextBox.Text;
            string orderType = OrderTypeComboBox.Text;
            string price = PriceTextBox.Text;
            string quantity = QuantityTextBox.Text;

            string msgString = "{0}|{1}|{2}|{3}|{4}|{5}|{6}";

            Debug.WriteLine("hi");
            if (symbol != "" && orderType != "" && price != "" && quantity != "" && Helper.IsNumeric(price) && Helper.IsNumeric(quantity))
            {
                string requestMsg = string.Format(msgString, "0", symbol, "1", "1", price, quantity, "0");
                Main.TcpClient.SendMsg(requestMsg);
            }
            ResetPriceAndQuantity();
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            string symbol = SymbolTextBox.Text;
            string orderType = OrderTypeComboBox.Text;
            string price = PriceTextBox.Text;
            string quantity = QuantityTextBox.Text;

            string msgString = "{0}|{1}|{2}|{3}|{4}|{5}|{6}";

            if (symbol != "" && orderType != "" && price != "" && quantity != "")
            {
                string requestMsg = string.Format(msgString, "0", symbol, "1", "2", price, quantity, "0");
                Main.TcpClient.SendMsg(requestMsg);
            }
            ResetPriceAndQuantity();

        }

        private void BidDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            BidDataGridView.ClearSelection();
            for (int i = 0; i < BidDataGridView.Rows.Count; i++)
            {
                int size = (int) BidDataGridView.Rows[i].Cells[1].Value;
                if (_lowestBidSize.Contains(size))
                {
                    BidDataGridView.Rows[i].Cells[1].Style.BackColor = Color.LightBlue;
                }
            }
        }

        private void AskDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            AskDataGridView.ClearSelection();

            for (int i = 0; i < AskDataGridView.Rows.Count; i++)
            {
                int size = (int)AskDataGridView.Rows[i].Cells[1].Value;
                if (_lowestAskSize.Contains(size))
                {
                    AskDataGridView.Rows[i].Cells[1].Style.BackColor = Color.Coral;
                }
            }
        }




    }
}
