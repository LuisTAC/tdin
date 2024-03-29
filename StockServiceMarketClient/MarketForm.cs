﻿using StockServiceContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockServiceMarketClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public partial class MarketForm : Form, StockService.IStockDirectoryCallback
    {
        private int onNewId;
        private Dictionary<int, int> onChangedIds = new Dictionary<int, int>(); //orderId, callbackId

        private StockService.StockDirectoryClient proxy;

        public MarketForm()
        {
            this.proxy = new StockService.StockDirectoryClient(new InstanceContext(this));
            InitializeComponent();
        }

        private void MarketForm_Load(object sender, EventArgs e)
        {
            initViews();
            this.onNewId = proxy.RegisterOnNewOrder();
            foreach (KeyValuePair<int, int> entry in onChangedIds)
            {
                proxy.UnregisterOnOrderStatusChange(entry.Key,entry.Value);
            }
        }

        private void MarketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxy.UnregisterOnNewOrder(this.onNewId);

            proxy.Close();
        }

        private void initViews()
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
                    this.onChangedIds.Add(order.Id, proxy.RegisterOnOrderStatusChange(order.Id));
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

        public void OnNewOrder(StockOrder order)
        {
            ListViewItem item = new ListViewItem(new string[] { order.Id.ToString(), order.Email, order.Type.ToString(), order.Quantity.ToString(), order.Company, order.RequestDate });
            this.pendingList.Items.Add(item);
            this.onChangedIds.Add(order.Id, proxy.RegisterOnOrderStatusChange(order.Id));
        }

        public void OnOrderStatusChange(StockOrder order)
        {
            foreach (ListViewItem item in ((MarketForm)this).pendingList.Items)
            {
                if(item.Text.Equals(order.Id.ToString()))
                    ((MarketForm)this).pendingList.Items.Remove(item);
            }
            ListViewItem newItem = new ListViewItem(new string[] { order.Id.ToString(), order.Email, order.Type.ToString(), order.Quantity.ToString(), order.Company, order.RequestDate, order.ExecutionDate, order.StockValue.ToString(), order.GetTotalValue().ToString() });
            ((MarketForm)this).executedList.Items.Add(newItem);
        }
    }
}
