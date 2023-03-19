using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PortfolioTradeRisk.Model;

namespace PortfolioTradeRisk
{
    public partial class PortfolioTradeDetail : Form
    {
        private Model.Model model = null;

        public PortfolioTradeDetail(PortolioTradeLineItem[] portfolioTradeLineItems)
        {
            InitializeComponent();
            this.model = new Model.Model(this.lineItemsDataGridView, portfolioTradeLineItems);
            
        }

    }
}
