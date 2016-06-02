namespace StockServiceMarketClient
{
    partial class MarketForm
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
            this.pendingLabel = new System.Windows.Forms.Label();
            this.executedLabel = new System.Windows.Forms.Label();
            this.pendingList = new System.Windows.Forms.ListView();
            this.idPendHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailPendHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typePendHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityPendHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.companyPendHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateReqPendHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.executeButton = new System.Windows.Forms.Button();
            this.executedList = new System.Windows.Forms.ListView();
            this.idExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.companyExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateReqExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateExecExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockValExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalValExecutedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockValInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.stockValInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pendingLabel
            // 
            this.pendingLabel.AutoSize = true;
            this.pendingLabel.Location = new System.Drawing.Point(263, 9);
            this.pendingLabel.Name = "pendingLabel";
            this.pendingLabel.Size = new System.Drawing.Size(46, 13);
            this.pendingLabel.TabIndex = 0;
            this.pendingLabel.Text = "Pending";
            // 
            // executedLabel
            // 
            this.executedLabel.AutoSize = true;
            this.executedLabel.Location = new System.Drawing.Point(263, 209);
            this.executedLabel.Name = "executedLabel";
            this.executedLabel.Size = new System.Drawing.Size(52, 13);
            this.executedLabel.TabIndex = 1;
            this.executedLabel.Text = "Executed";
            // 
            // pendingList
            // 
            this.pendingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idPendHeader,
            this.emailPendHeader,
            this.typePendHeader,
            this.quantityPendHeader,
            this.companyPendHeader,
            this.dateReqPendHeader});
            this.pendingList.FullRowSelect = true;
            this.pendingList.GridLines = true;
            this.pendingList.Location = new System.Drawing.Point(12, 25);
            this.pendingList.Name = "pendingList";
            this.pendingList.Size = new System.Drawing.Size(560, 150);
            this.pendingList.TabIndex = 0;
            this.pendingList.UseCompatibleStateImageBehavior = false;
            this.pendingList.View = System.Windows.Forms.View.Details;
            // 
            // idPendHeader
            // 
            this.idPendHeader.Text = "ID";
            this.idPendHeader.Width = 25;
            // 
            // emailPendHeader
            // 
            this.emailPendHeader.Text = "Email";
            this.emailPendHeader.Width = 120;
            // 
            // typePendHeader
            // 
            this.typePendHeader.Text = "Type";
            this.typePendHeader.Width = 100;
            // 
            // quantityPendHeader
            // 
            this.quantityPendHeader.Text = "Quantity";
            this.quantityPendHeader.Width = 100;
            // 
            // companyPendHeader
            // 
            this.companyPendHeader.Text = "Company";
            this.companyPendHeader.Width = 100;
            // 
            // dateReqPendHeader
            // 
            this.dateReqPendHeader.Text = "Request Date";
            this.dateReqPendHeader.Width = 110;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(497, 181);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 23);
            this.executeButton.TabIndex = 2;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // executedList
            // 
            this.executedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idExecutedHeader,
            this.emailExecutedHeader,
            this.typeExecutedHeader,
            this.quantityExecutedHeader,
            this.companyExecutedHeader,
            this.dateReqExecutedHeader,
            this.dateExecExecutedHeader,
            this.stockValExecutedHeader,
            this.totalValExecutedHeader});
            this.executedList.FullRowSelect = true;
            this.executedList.GridLines = true;
            this.executedList.Location = new System.Drawing.Point(12, 225);
            this.executedList.MultiSelect = false;
            this.executedList.Name = "executedList";
            this.executedList.Size = new System.Drawing.Size(560, 150);
            this.executedList.TabIndex = 4;
            this.executedList.UseCompatibleStateImageBehavior = false;
            this.executedList.View = System.Windows.Forms.View.Details;
            // 
            // idExecutedHeader
            // 
            this.idExecutedHeader.Text = "ID";
            this.idExecutedHeader.Width = 25;
            // 
            // emailExecutedHeader
            // 
            this.emailExecutedHeader.Text = "Email";
            // 
            // typeExecutedHeader
            // 
            this.typeExecutedHeader.Text = "Type";
            // 
            // quantityExecutedHeader
            // 
            this.quantityExecutedHeader.Text = "Quantity";
            // 
            // companyExecutedHeader
            // 
            this.companyExecutedHeader.Text = "Company";
            // 
            // dateReqExecutedHeader
            // 
            this.dateReqExecutedHeader.Text = "Request Date";
            this.dateReqExecutedHeader.Width = 75;
            // 
            // dateExecExecutedHeader
            // 
            this.dateExecExecutedHeader.Text = "Execution Date";
            this.dateExecExecutedHeader.Width = 75;
            // 
            // stockValExecutedHeader
            // 
            this.stockValExecutedHeader.Text = "Stock Value";
            this.stockValExecutedHeader.Width = 70;
            // 
            // totalValExecutedHeader
            // 
            this.totalValExecutedHeader.Text = "Total Value";
            this.totalValExecutedHeader.Width = 70;
            // 
            // stockValInput
            // 
            this.stockValInput.DecimalPlaces = 2;
            this.stockValInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.stockValInput.Location = new System.Drawing.Point(443, 184);
            this.stockValInput.Name = "stockValInput";
            this.stockValInput.Size = new System.Drawing.Size(50, 20);
            this.stockValInput.TabIndex = 1;
            // 
            // MarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 386);
            this.Controls.Add(this.stockValInput);
            this.Controls.Add(this.executedList);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.pendingList);
            this.Controls.Add(this.executedLabel);
            this.Controls.Add(this.pendingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MarketForm";
            this.Text = "Market";
            this.Load += new System.EventHandler(this.MarketForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MarketForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.stockValInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pendingLabel;
        private System.Windows.Forms.Label executedLabel;
        public System.Windows.Forms.ListView pendingList;
        private System.Windows.Forms.ColumnHeader idPendHeader;
        private System.Windows.Forms.ColumnHeader emailPendHeader;
        private System.Windows.Forms.ColumnHeader typePendHeader;
        private System.Windows.Forms.ColumnHeader quantityPendHeader;
        private System.Windows.Forms.ColumnHeader dateReqPendHeader;
        private System.Windows.Forms.Button executeButton;
        public System.Windows.Forms.ListView executedList;
        private System.Windows.Forms.ColumnHeader idExecutedHeader;
        private System.Windows.Forms.ColumnHeader emailExecutedHeader;
        private System.Windows.Forms.ColumnHeader typeExecutedHeader;
        private System.Windows.Forms.ColumnHeader quantityExecutedHeader;
        private System.Windows.Forms.ColumnHeader dateReqExecutedHeader;
        private System.Windows.Forms.ColumnHeader dateExecExecutedHeader;
        private System.Windows.Forms.ColumnHeader totalValExecutedHeader;
        private System.Windows.Forms.ColumnHeader stockValExecutedHeader;
        private System.Windows.Forms.ColumnHeader companyPendHeader;
        private System.Windows.Forms.ColumnHeader companyExecutedHeader;
        private System.Windows.Forms.NumericUpDown stockValInput;
    }
}

