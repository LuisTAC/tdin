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
            this.proxy = new StockService.StockDirectoryClient();
            this.proxy.ExecuteOrder(1, 3f);
        }
    }
}
