using StockServiceContracts;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StockServiceContracts.StockOrder;

namespace StockServiceClient
{
    public partial class Form1 : Form, StockService.IStockDirectoryCallback
    {
        private StockService.StockDirectoryClient proxy;

        public Form1()
        {
            InitializeComponent();
            this.proxy = new StockService.StockDirectoryClient(new InstanceContext(this));
            this.BuySell.Items.Add(OrderType.Purchase);
            this.BuySell.Items.Add(OrderType.Sale);
            this.BuySell.Text = "Purchase";
        }

        public void OnNewOrder(StockOrder order)
        {
            throw new NotImplementedException();
        }
        public void OnOrderStatusChange(StockOrder order)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockOrder.OrderType type = (StockOrder.OrderType)this.BuySell.SelectedItem;
            try
            {
                this.DisableForm();
                Task task = proxy.OrderStockAsync(this.CompanyTextBox.Text, (int)this.Amount.Value, type, this.Email.Text);
                task.ContinueWith(t =>
                {
                    if (this.InvokeRequired)
                    {
                        Action clearAction = () => { this.ClearForm(); this.EnableForm(); };
                        this.Invoke(clearAction);
                    }
                    else
                    {
                        this.ClearForm();
                        this.EnableForm();
                    }

                    MessageBox.Show("Order created!", "Success");
                });
            }
            catch (Exception exception)
            {
                this.EnableForm();
                MessageBox.Show("Could not process the request! " + exception.Message, "Error");
            }
        }

        private void ClearForm()
        {
            this.Email.Text = "";
            this.CompanyTextBox.Text = "";
            this.Amount.Value = 0;
            this.BuySell.SelectedIndex = 0;
        }

        private void DisableForm()
        {
            this.submit_button.Enabled = false;
            this.Email.Enabled = false;
            this.CompanyTextBox.Enabled = false;
            this.Amount.Enabled = false;
            this.BuySell.Enabled = false;
        }
        private void EnableForm()
        {
            this.submit_button.Enabled = true;
            this.Email.Enabled = true;
            this.CompanyTextBox.Enabled = true;
            this.Amount.Enabled = true;
            this.BuySell.Enabled = true;
        }
    }
}
