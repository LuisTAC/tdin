using StockServiceContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                    ListViewItem item = new ListViewItem(new string[] { order.Id.ToString(), order.Email, order.Type.ToString(), order.Quantity.ToString(), order.Company, order.RequestDate, order.ExecutionDate, order.StockValue.ToString(), order.GetTotalValue().ToString() });
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
                int id = int.Parse(item.Text);
                float stockVal = (float)this.stockValInput.Value;
                
                try
                {
                    this.DisableForm();
                    Task task = proxy.ExecuteOrderAsync(id, stockVal);
                    task.ContinueWith(t =>
                    {
                        if (this.InvokeRequired)
                        {
                            Action onSuccess = () => {
                                this.pendingList.Items.RemoveAt(ind);

                                int quantity = int.Parse(item.SubItems[3].Text);
                                ListViewItem newItem = new ListViewItem(new string[] { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text, item.SubItems[5].Text, DateTime.UtcNow.ToString(), stockVal.ToString(), (quantity*stockVal).ToString() });
                                this.executedList.Items.Add(newItem);

                                this.stockValInput.Value = 0;
                                this.EnableForm();
                            };
                            this.Invoke(onSuccess);
                        }
                        else
                        {
                            this.stockValInput.Value = 0;
                            this.EnableForm();
                        }

                        MessageBox.Show("Order executed!", "Success");
                    });
                }
                catch (Exception exception)
                {
                    this.EnableForm();
                    MessageBox.Show("Could not execute the order! " + exception.Message, "Error");
                }
            }            
        }

        private void DisableForm()
        {
            this.pendingList.Enabled = false;
            this.executedList.Enabled = false;
            this.stockValInput.Enabled = false;
            this.executeButton.Enabled = false;
        }
        private void EnableForm()
        {
            this.pendingList.Enabled = true;
            this.executedList.Enabled = true;
            this.stockValInput.Enabled = true;
            this.executeButton.Enabled = true;
        }

    }
}
