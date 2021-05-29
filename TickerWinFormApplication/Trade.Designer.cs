namespace TickerWinFormApplication
{
    partial class Trade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BestBidLabel = new System.Windows.Forms.Label();
            this.BestAskLabel = new System.Windows.Forms.Label();
            this.BidDataGridView = new System.Windows.Forms.DataGridView();
            this.AskDataGridView = new System.Windows.Forms.DataGridView();
            this.BidAskBarGroupBoxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.BidAskBarSplitContainer = new System.Windows.Forms.SplitContainer();
            this.BidSizeLabel = new System.Windows.Forms.Label();
            this.AskSizeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SellButton = new System.Windows.Forms.Button();
            this.BuyButton = new System.Windows.Forms.Button();
            this.OrderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.SymbolTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TradeRecordDataGridView = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.TradedOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.OrderDataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BidDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AskDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BidAskBarGroupBoxSplitContainer)).BeginInit();
            this.BidAskBarGroupBoxSplitContainer.Panel1.SuspendLayout();
            this.BidAskBarGroupBoxSplitContainer.Panel2.SuspendLayout();
            this.BidAskBarGroupBoxSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BidAskBarSplitContainer)).BeginInit();
            this.BidAskBarSplitContainer.Panel1.SuspendLayout();
            this.BidAskBarSplitContainer.Panel2.SuspendLayout();
            this.BidAskBarSplitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeRecordDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradedOrderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(505, 561);
            this.splitContainer1.SplitterDistance = 536;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TradeRecordDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(505, 561);
            this.splitContainer2.SplitterDistance = 376;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.BidAskBarGroupBoxSplitContainer);
            this.splitContainer3.Size = new System.Drawing.Size(376, 561);
            this.splitContainer3.SplitterDistance = 400;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BestBidLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BestAskLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BidDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AskDataGridView, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.66265F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.33735F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 398);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BestBidLabel
            // 
            this.BestBidLabel.AutoSize = true;
            this.BestBidLabel.BackColor = System.Drawing.Color.Wheat;
            this.BestBidLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BestBidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BestBidLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestBidLabel.ForeColor = System.Drawing.Color.Blue;
            this.BestBidLabel.Location = new System.Drawing.Point(0, 0);
            this.BestBidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BestBidLabel.Name = "BestBidLabel";
            this.BestBidLabel.Size = new System.Drawing.Size(187, 62);
            this.BestBidLabel.TabIndex = 0;
            this.BestBidLabel.Text = "Best Bid";
            this.BestBidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BestAskLabel
            // 
            this.BestAskLabel.AutoSize = true;
            this.BestAskLabel.BackColor = System.Drawing.Color.Wheat;
            this.BestAskLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BestAskLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BestAskLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestAskLabel.ForeColor = System.Drawing.Color.Red;
            this.BestAskLabel.Location = new System.Drawing.Point(187, 0);
            this.BestAskLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BestAskLabel.Name = "BestAskLabel";
            this.BestAskLabel.Size = new System.Drawing.Size(187, 62);
            this.BestAskLabel.TabIndex = 1;
            this.BestAskLabel.Text = "Best Ask";
            this.BestAskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BidDataGridView
            // 
            this.BidDataGridView.AllowUserToAddRows = false;
            this.BidDataGridView.AllowUserToDeleteRows = false;
            this.BidDataGridView.AllowUserToResizeColumns = false;
            this.BidDataGridView.AllowUserToResizeRows = false;
            this.BidDataGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.BidDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BidDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle55.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BidDataGridView.DefaultCellStyle = dataGridViewCellStyle55;
            this.BidDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BidDataGridView.Location = new System.Drawing.Point(0, 62);
            this.BidDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.BidDataGridView.MultiSelect = false;
            this.BidDataGridView.Name = "BidDataGridView";
            this.BidDataGridView.RowHeadersVisible = false;
            this.BidDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.BidDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BidDataGridView.ShowCellErrors = false;
            this.BidDataGridView.ShowCellToolTips = false;
            this.BidDataGridView.ShowEditingIcon = false;
            this.BidDataGridView.ShowRowErrors = false;
            this.BidDataGridView.Size = new System.Drawing.Size(187, 336);
            this.BidDataGridView.TabIndex = 2;
            this.BidDataGridView.DataSourceChanged += new System.EventHandler(this.BidDataGridView_DataSourceChanged);
            // 
            // AskDataGridView
            // 
            this.AskDataGridView.AllowUserToAddRows = false;
            this.AskDataGridView.AllowUserToDeleteRows = false;
            this.AskDataGridView.AllowUserToResizeColumns = false;
            this.AskDataGridView.AllowUserToResizeRows = false;
            this.AskDataGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.AskDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AskDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle56.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AskDataGridView.DefaultCellStyle = dataGridViewCellStyle56;
            this.AskDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AskDataGridView.Location = new System.Drawing.Point(187, 62);
            this.AskDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.AskDataGridView.MultiSelect = false;
            this.AskDataGridView.Name = "AskDataGridView";
            this.AskDataGridView.RowHeadersVisible = false;
            this.AskDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AskDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AskDataGridView.ShowCellErrors = false;
            this.AskDataGridView.ShowCellToolTips = false;
            this.AskDataGridView.ShowEditingIcon = false;
            this.AskDataGridView.ShowRowErrors = false;
            this.AskDataGridView.Size = new System.Drawing.Size(187, 336);
            this.AskDataGridView.TabIndex = 3;
            this.AskDataGridView.DataSourceChanged += new System.EventHandler(this.AskDataGridView_DataSourceChanged);
            // 
            // BidAskBarGroupBoxSplitContainer
            // 
            this.BidAskBarGroupBoxSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BidAskBarGroupBoxSplitContainer.IsSplitterFixed = true;
            this.BidAskBarGroupBoxSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BidAskBarGroupBoxSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.BidAskBarGroupBoxSplitContainer.Name = "BidAskBarGroupBoxSplitContainer";
            this.BidAskBarGroupBoxSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BidAskBarGroupBoxSplitContainer.Panel1
            // 
            this.BidAskBarGroupBoxSplitContainer.Panel1.Controls.Add(this.BidAskBarSplitContainer);
            // 
            // BidAskBarGroupBoxSplitContainer.Panel2
            // 
            this.BidAskBarGroupBoxSplitContainer.Panel2.Controls.Add(this.groupBox1);
            this.BidAskBarGroupBoxSplitContainer.Size = new System.Drawing.Size(374, 155);
            this.BidAskBarGroupBoxSplitContainer.SplitterDistance = 25;
            this.BidAskBarGroupBoxSplitContainer.SplitterWidth = 1;
            this.BidAskBarGroupBoxSplitContainer.TabIndex = 0;
            // 
            // BidAskBarSplitContainer
            // 
            this.BidAskBarSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BidAskBarSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BidAskBarSplitContainer.Name = "BidAskBarSplitContainer";
            // 
            // BidAskBarSplitContainer.Panel1
            // 
            this.BidAskBarSplitContainer.Panel1.BackColor = System.Drawing.Color.Blue;
            this.BidAskBarSplitContainer.Panel1.Controls.Add(this.BidSizeLabel);
            this.BidAskBarSplitContainer.Panel1.ForeColor = System.Drawing.SystemColors.Window;
            // 
            // BidAskBarSplitContainer.Panel2
            // 
            this.BidAskBarSplitContainer.Panel2.BackColor = System.Drawing.Color.Red;
            this.BidAskBarSplitContainer.Panel2.Controls.Add(this.AskSizeLabel);
            this.BidAskBarSplitContainer.Panel2.ForeColor = System.Drawing.SystemColors.Window;
            this.BidAskBarSplitContainer.Size = new System.Drawing.Size(374, 25);
            this.BidAskBarSplitContainer.SplitterDistance = 185;
            this.BidAskBarSplitContainer.TabIndex = 0;
            // 
            // BidSizeLabel
            // 
            this.BidSizeLabel.AutoSize = true;
            this.BidSizeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BidSizeLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.BidSizeLabel.Location = new System.Drawing.Point(0, 0);
            this.BidSizeLabel.Name = "BidSizeLabel";
            this.BidSizeLabel.Size = new System.Drawing.Size(21, 13);
            this.BidSizeLabel.TabIndex = 0;
            this.BidSizeLabel.Text = "0%";
            // 
            // AskSizeLabel
            // 
            this.AskSizeLabel.AutoSize = true;
            this.AskSizeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.AskSizeLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.AskSizeLabel.Location = new System.Drawing.Point(164, 0);
            this.AskSizeLabel.Name = "AskSizeLabel";
            this.AskSizeLabel.Size = new System.Drawing.Size(21, 13);
            this.AskSizeLabel.TabIndex = 0;
            this.AskSizeLabel.Text = "0%";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Wheat;
            this.groupBox1.Controls.Add(this.SellButton);
            this.groupBox1.Controls.Add(this.BuyButton);
            this.groupBox1.Controls.Add(this.OrderTypeComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.QuantityTextBox);
            this.groupBox1.Controls.Add(this.PriceTextBox);
            this.groupBox1.Controls.Add(this.SymbolTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // SellButton
            // 
            this.SellButton.BackColor = System.Drawing.Color.Orange;
            this.SellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SellButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SellButton.Location = new System.Drawing.Point(287, 53);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(81, 32);
            this.SellButton.TabIndex = 9;
            this.SellButton.Text = "SELL";
            this.SellButton.UseVisualStyleBackColor = false;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // BuyButton
            // 
            this.BuyButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BuyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuyButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BuyButton.Location = new System.Drawing.Point(205, 54);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BuyButton.Size = new System.Drawing.Size(76, 31);
            this.BuyButton.TabIndex = 8;
            this.BuyButton.Text = "BUY";
            this.BuyButton.UseVisualStyleBackColor = false;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // OrderTypeComboBox
            // 
            this.OrderTypeComboBox.FormattingEnabled = true;
            this.OrderTypeComboBox.Location = new System.Drawing.Point(268, 16);
            this.OrderTypeComboBox.Name = "OrderTypeComboBox";
            this.OrderTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.OrderTypeComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Order Type";
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(74, 89);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(100, 20);
            this.QuantityTextBox.TabIndex = 5;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(74, 54);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.PriceTextBox.TabIndex = 4;
            // 
            // SymbolTextBox
            // 
            this.SymbolTextBox.Location = new System.Drawing.Point(74, 16);
            this.SymbolTextBox.Name = "SymbolTextBox";
            this.SymbolTextBox.Size = new System.Drawing.Size(100, 20);
            this.SymbolTextBox.TabIndex = 3;
            this.SymbolTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SymbolTextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol";
            // 
            // TradeRecordDataGridView
            // 
            this.TradeRecordDataGridView.AllowUserToAddRows = false;
            this.TradeRecordDataGridView.AllowUserToDeleteRows = false;
            this.TradeRecordDataGridView.AllowUserToResizeColumns = false;
            this.TradeRecordDataGridView.AllowUserToResizeRows = false;
            this.TradeRecordDataGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.TradeRecordDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TradeRecordDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TradeRecordDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.TradeRecordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TradeRecordDataGridView.DefaultCellStyle = dataGridViewCellStyle50;
            this.TradeRecordDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TradeRecordDataGridView.Enabled = false;
            this.TradeRecordDataGridView.EnableHeadersVisualStyles = false;
            this.TradeRecordDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TradeRecordDataGridView.MultiSelect = false;
            this.TradeRecordDataGridView.Name = "TradeRecordDataGridView";
            this.TradeRecordDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TradeRecordDataGridView.RowHeadersVisible = false;
            this.TradeRecordDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TradeRecordDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TradeRecordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TradeRecordDataGridView.ShowCellErrors = false;
            this.TradeRecordDataGridView.ShowCellToolTips = false;
            this.TradeRecordDataGridView.ShowEditingIcon = false;
            this.TradeRecordDataGridView.ShowRowErrors = false;
            this.TradeRecordDataGridView.Size = new System.Drawing.Size(125, 561);
            this.TradeRecordDataGridView.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.TradedOrderDataGridView);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.OrderDataGridView);
            this.splitContainer4.Size = new System.Drawing.Size(150, 46);
            this.splitContainer4.SplitterDistance = 76;
            this.splitContainer4.TabIndex = 0;
            // 
            // TradedOrderDataGridView
            // 
            this.TradedOrderDataGridView.BackgroundColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TradedOrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle51;
            this.TradedOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TradedOrderDataGridView.DefaultCellStyle = dataGridViewCellStyle52;
            this.TradedOrderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TradedOrderDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TradedOrderDataGridView.Name = "TradedOrderDataGridView";
            this.TradedOrderDataGridView.Size = new System.Drawing.Size(76, 46);
            this.TradedOrderDataGridView.TabIndex = 0;
            this.TradedOrderDataGridView.Visible = false;
            // 
            // OrderDataGridView
            // 
            this.OrderDataGridView.BackgroundColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle53;
            this.OrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderDataGridView.DefaultCellStyle = dataGridViewCellStyle54;
            this.OrderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderDataGridView.Location = new System.Drawing.Point(0, 0);
            this.OrderDataGridView.Name = "OrderDataGridView";
            this.OrderDataGridView.Size = new System.Drawing.Size(70, 46);
            this.OrderDataGridView.TabIndex = 0;
            this.OrderDataGridView.Visible = false;
            // 
            // Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(505, 561);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Trade";
            this.Text = "Trade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Trade_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BidDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AskDataGridView)).EndInit();
            this.BidAskBarGroupBoxSplitContainer.Panel1.ResumeLayout(false);
            this.BidAskBarGroupBoxSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BidAskBarGroupBoxSplitContainer)).EndInit();
            this.BidAskBarGroupBoxSplitContainer.ResumeLayout(false);
            this.BidAskBarSplitContainer.Panel1.ResumeLayout(false);
            this.BidAskBarSplitContainer.Panel1.PerformLayout();
            this.BidAskBarSplitContainer.Panel2.ResumeLayout(false);
            this.BidAskBarSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BidAskBarSplitContainer)).EndInit();
            this.BidAskBarSplitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeRecordDataGridView)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TradedOrderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label BestBidLabel;
        private System.Windows.Forms.Label BestAskLabel;
        private System.Windows.Forms.DataGridView TradeRecordDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView OrderDataGridView;
        private System.Windows.Forms.DataGridView TradedOrderDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView BidDataGridView;
        private System.Windows.Forms.DataGridView AskDataGridView;
        private System.Windows.Forms.SplitContainer BidAskBarGroupBoxSplitContainer;
        private System.Windows.Forms.SplitContainer BidAskBarSplitContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.TextBox SymbolTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.ComboBox OrderTypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label BidSizeLabel;
        private System.Windows.Forms.Label AskSizeLabel;
    }
}