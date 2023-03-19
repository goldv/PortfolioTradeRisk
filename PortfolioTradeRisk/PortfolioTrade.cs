using CsvHelper;
using CsvHelper.Configuration;
using PortfolioTradeRisk.Model;
using PortfolioTradeRisk.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace PortfolioTradeRisk
{
    public partial class PortfolioTrade : Form
    {
        public PortfolioTrade()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(PortfolioTrade_DragEnter);
            this.DragDrop += new DragEventHandler(PortfolioTrade_DragDrop);
        }

        void PortfolioTrade_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        async void PortfolioTrade_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(files.Length == 1)
            {
                string file = files[0];
                PortolioTradeLineItem[] portfolioTradeLineItems = await Util.CsvParser.parsePortfolioLineItems(file);

                PortfolioTradeDetail portolioTradeDetail = new PortfolioTradeDetail(portfolioTradeLineItems);
                portolioTradeDetail.Show();
               
            }
        }
        
    }
}
