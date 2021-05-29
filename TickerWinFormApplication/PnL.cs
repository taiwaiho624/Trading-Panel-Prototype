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
    public partial class PnL : Form
    {
        public PnL()
        {
            InitializeComponent();
            PnlDataGridView.Columns.Add("symbol", "Symbol");
            PnlDataGridView.Columns.Add("size", "Size");
            PnlDataGridView.Columns.Add("cost", "Cost");
            PnlDataGridView.Columns.Add("realized_pnl", "Realized PnL");
            PnlDataGridView.Columns.Add("unrealized_pnl", "UnRealized PnL");
            PnlDataGridView.Columns.Add("turnover", "Turnover");

            PnlDataGridView.Columns[0].Width = (int)(splitContainer1.Panel1.Width * 0.1);
            PnlDataGridView.Columns[1].Width = (int)(splitContainer1.Panel1.Width * 0.1);
            PnlDataGridView.Columns[2].Width = (int)(splitContainer1.Panel1.Width * 0.1);
            PnlDataGridView.Columns[3].Width = (int)(splitContainer1.Panel1.Width * 0.23);
            PnlDataGridView.Columns[4].Width = (int)(splitContainer1.Panel1.Width * 0.25);
            PnlDataGridView.Columns[5].Width = (int)(splitContainer1.Panel1.Width * 0.23);

            TradeOrderDataGridView.Columns.Add("datetime", "Date");
            TradeOrderDataGridView.Columns.Add("action", "Action");
            TradeOrderDataGridView.Columns.Add("symbol", "Symbol");
            TradeOrderDataGridView.Columns.Add("price&quantity", "Price@Qty");
            TradeOrderDataGridView.Columns.Add("status", "Status");

            TradeOrderDataGridView.Columns[0].Width = (int)(splitContainer1.Panel1.Width * 0.25);
            TradeOrderDataGridView.Columns[1].Width = (int)(splitContainer1.Panel1.Width * 0.16);
            TradeOrderDataGridView.Columns[2].Width = (int)(splitContainer1.Panel1.Width * 0.16);
            TradeOrderDataGridView.Columns[3].Width = (int)(splitContainer1.Panel1.Width * 0.25);
            TradeOrderDataGridView.Columns[4].Width = (int)(splitContainer1.Panel1.Width * 0.18);

            PnlDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            TradeOrderDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

        }

        public void UpdatePnlDataGridView()
        {
            PnlDataGridView.BeginInvoke(new Action(() =>
            {
                PnlDataGridView.Rows.Clear();
            }));
            foreach (var entry in Main.MyOrderProcessor.ReturnS2TradInfo()) 
            {
                string symbol = entry.Value.Symbol;
                int size = entry.Value.PtsSize;
                double avgCost = entry.Value.AvgCost;
                double realizedPnL = entry.Value.PnL;
                double unrealizedPnL = (double)0;
                double turnover = entry.Value.Turnover;

                PnlDataGridView.BeginInvoke(new Action(() =>
                {
                    PnlDataGridView.Rows.Add(symbol, size, avgCost, realizedPnL, unrealizedPnL, turnover);
                }));
                

            }
        }

        public void UpdateTradeOrderDataGridView()
        {
            TradeOrderDataGridView.BeginInvoke(new Action(() =>
            {
                TradeOrderDataGridView.Rows.Clear();
            }));
            foreach (var order in Main.MyOrderProcessor.ReturnOrderBlocks())
            {
                string date = order.OrderTime.ToString("yyyy-MM-dd");
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

                TradeOrderDataGridView.BeginInvoke(new Action(() =>
                {
                    TradeOrderDataGridView.Rows.Add(date, action, symbol, priceAndQty, orderStatus);
                }));
            }

        }

        public void UpdateUnRealizedPnl(string msg)
        {
            string[] tokens = msg.Split('|');
            string symbol = tokens[1];
            foreach (DataGridViewRow row in PnlDataGridView.Rows)
            {
                if ( (string)row.Cells[0].Value == symbol)
                {
                    TradInfo tragetInfo = Main.MyOrderProcessor.ReturnS2TradInfo()[symbol];
                    double bid = Convert.ToDouble(tokens[2]);
                    double ask = Convert.ToDouble(tokens[3]);
                    double unrealizedPnl = Main.MyOrderProcessor.CompUnrealized(bid, ask, tragetInfo);
                    row.Cells[4].Value = unrealizedPnl;
                }
            }

        }


        private void PnL_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.PnlForm = null;
        }

        private void PnL_Shown(object sender, EventArgs e)
        {

            UpdatePnlDataGridView();
            UpdateTradeOrderDataGridView();
        }


    }
}
