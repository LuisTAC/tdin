using StockServiceContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StockServiceContracts.StockOrder;

namespace StockServiceClient
{
    public partial class Form1 : Form
    {
        private StockService.StockDirectoryClient proxy;

        public Form1()
        {
            InitializeComponent();
            this.proxy = new StockService.StockDirectoryClient();
            this.BuySell.Items.Add(OrderType.Purchase);
            this.BuySell.Items.Add(OrderType.Sale);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockOrder.OrderType type = (StockOrder.OrderType)this.BuySell.SelectedItem;
            try
            {
                proxy.OrderStock(this.CompanyName, (int)this.Amount.Value, type, this.Email.Text);
                MessageBox.Show("Order created!", "Success");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Could not process the request! " + exception.Message, "Error");
            }

            /*
            if(this.submit_button.InvokeRequired)
            {

            }
            else
            {

            }
            */
        }

        private void DisableForm()
        {
            this.submit_button.Enabled = false;
            this.Email.Enabled = false;
            this.NameTextBox.Enabled = false;
            this.Amount.Enabled = false;
            this.BuySell.Enabled = false;
        }
        private void EnableForm()
        {
            this.submit_button.Enabled = true;
            this.Email.Enabled = true;
            this.NameTextBox.Enabled = true;
            this.Amount.Enabled = true;
            this.BuySell.Enabled = true;
        }
    }
}
