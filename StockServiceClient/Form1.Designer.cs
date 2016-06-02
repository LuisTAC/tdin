namespace StockServiceClient
{
    partial class Form1
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
            this.CompanyTextBox = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BuySell = new System.Windows.Forms.ComboBox();
            this.submit_button = new System.Windows.Forms.Button();
            this.Amount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
            this.SuspendLayout();
            // 
            // CompanyTextBox
            // 
            this.CompanyTextBox.Location = new System.Drawing.Point(115, 55);
            this.CompanyTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyTextBox.Name = "CompanyTextBox";
            this.CompanyTextBox.Size = new System.Drawing.Size(367, 22);
            this.CompanyTextBox.TabIndex = 0;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(115, 95);
            this.Email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(367, 22);
            this.Email.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Company";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "E-mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Buy/Sell";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 9;
            // 
            // BuySell
            // 
            this.BuySell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuySell.FormattingEnabled = true;
            this.BuySell.Location = new System.Drawing.Point(115, 134);
            this.BuySell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BuySell.Name = "BuySell";
            this.BuySell.Size = new System.Drawing.Size(121, 24);
            this.BuySell.TabIndex = 10;
            // 
            // submit_button
            // 
            this.submit_button.Location = new System.Drawing.Point(140, 223);
            this.submit_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(271, 23);
            this.submit_button.TabIndex = 11;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Amount
            // 
            this.Amount.Location = new System.Drawing.Point(116, 178);
            this.Amount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(120, 22);
            this.Amount.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 364);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.BuySell);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.CompanyTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Counter";
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompanyTextBox;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox BuySell;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.NumericUpDown Amount;
    }
}

