namespace TickerWinFormApplication
{
    partial class Main
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
            this.TradePanelButton = new System.Windows.Forms.Button();
            this.PnLPanelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TradePanelButton
            // 
            this.TradePanelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.TradePanelButton.Location = new System.Drawing.Point(0, 0);
            this.TradePanelButton.Name = "TradePanelButton";
            this.TradePanelButton.Size = new System.Drawing.Size(284, 23);
            this.TradePanelButton.TabIndex = 0;
            this.TradePanelButton.Text = "New Trade Panel";
            this.TradePanelButton.UseVisualStyleBackColor = true;
            this.TradePanelButton.Click += new System.EventHandler(this.TradePanel_Click);
            // 
            // PnLPanelButton
            // 
            this.PnLPanelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnLPanelButton.Location = new System.Drawing.Point(0, 23);
            this.PnLPanelButton.Name = "PnLPanelButton";
            this.PnLPanelButton.Size = new System.Drawing.Size(284, 23);
            this.PnLPanelButton.TabIndex = 1;
            this.PnLPanelButton.Text = "New PnL Panel";
            this.PnLPanelButton.UseVisualStyleBackColor = true;
            this.PnLPanelButton.Click += new System.EventHandler(this.PnLPanelButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.PnLPanelButton);
            this.Controls.Add(this.TradePanelButton);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TradePanelButton;
        private System.Windows.Forms.Button PnLPanelButton;
    }
}