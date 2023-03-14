using CsvHelper;
using CsvHelper.Configuration;
using PortfolioTradeRisk.Model;
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

        private void PortfolioTrade_Load(object sender, EventArgs e)
        {

        }

        void PortfolioTrade_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void PortfolioTrade_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(files.Length == 1)
            {
                string file = files[0];
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",",
                };

                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<PortolioTradeLineItem>();

                    PortfolioTradeDetail portolioTradeDetail = new PortfolioTradeDetail(records.ToArray<PortolioTradeLineItem>());
                    portolioTradeDetail.Show();
                }
            }
        }
    }
}
