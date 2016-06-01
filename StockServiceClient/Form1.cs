using StockServiceContracts;
using System;
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
                this.DisableForm();
                Task task = proxy.OrderStockAsync(this.CompanyName, (int)this.Amount.Value, type, this.Email.Text);
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
            this.NameTextBox.Text = "";
            this.Amount.Value = 0;
            this.BuySell.SelectedIndex = 0;
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
