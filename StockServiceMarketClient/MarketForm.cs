using StockServiceContracts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockServiceMarketClient
{
    public partial class MarketForm : Form
    {
        private StockService.StockDirectoryClient proxy;

        public MarketForm()
        {
            this.proxy = new StockService.StockDirectoryClient();
            InitializeComponent();
            initViews();
        }

        public void initViews()
        {
            IEnumerable<StockOrder> orders = proxy.GetAllOrders();

            pendingList.Items.Clear();
            executedList.Items.Clear();

            foreach (StockOrder order in orders)
            {
                if (order.IsPending())
                {
                    ListViewItem item = new ListViewItem(new string[] { order.Id.ToString(), order.Email, order.Type.ToString(), order.Quantity.ToString(), order.Company, order.RequestDate });
                    pendingList.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[] { order.Id.ToString(), order.Email, order.Type.ToString(), order.Quantity.ToString(), order.Company, order.RequestDate, order.RequestDate, order.ExecutionDate, order.StockValue.ToString(), order.GetTotalValue().ToString() });
                    executedList.Items.Add(item);
                }
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (this.pendingList.SelectedIndices.Count > 0)
            {
                int ind = this.pendingList.SelectedIndices[0];
                ListViewItem item = this.pendingList.Items[ind];
                
                //this.proxy.ExecuteOrder();
            }
        }
    }
}
