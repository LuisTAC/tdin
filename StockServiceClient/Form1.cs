using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockServiceClient
{
    public partial class Form1 : Form
    {
        private StockService.StockDirectoryClient proxy;

        public Form1()
        {
            InitializeComponent();
            this.BuySell.Items.Add(StockService.StockOrder.OrderType.Purchase);
            this.BuySell.Items.Add(StockService.StockOrder.OrderType.Sale);
            //this.proxy = new StockService.StockDirectoryClient();
            //this.proxy.ExecuteOrder(1, 3f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.submit_button.InvokeRequired)
            {
                StockService.StockOrder.OrderType type = (StockService.StockOrder.OrderType)this.BuySell.SelectedItem;
               proxy.OrderStockAsync(this.CompanyName, (int)this.Amount.Value, type, this.Email.Text);
            }
            else
            {

            }
        }
    }
}
