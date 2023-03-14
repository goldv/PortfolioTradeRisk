using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortfolioTradeRisk.Model
{
 
    internal class Model
    {
        private DataGridView lineItemsDataGridView;
        private DataTable lineItemsDataTable;
        private PortolioTradeLineItem[] portfolioTradeLineItems;

        public Model(DataGridView lineItemsDataGridView, PortolioTradeLineItem[] portfolioTradeLineItems)
        {
            this.lineItemsDataGridView = lineItemsDataGridView;
            this.portfolioTradeLineItems = portfolioTradeLineItems;
            this.lineItemsDataTable = new DataTable();

            BindingSource lineItemsBindingSource = new BindingSource();
            lineItemsBindingSource.DataSource = this.lineItemsDataTable;
            this.lineItemsDataGridView.DataSource = lineItemsBindingSource;

            Initialise();
        }

        private void Initialise()
        {
            this.lineItemsDataTable.Columns.Add("Trade#", typeof(string));
            this.lineItemsDataTable.Columns.Add("Side", typeof(string));
            this.lineItemsDataTable.Columns.Add("Amount", typeof(double));
            this.lineItemsDataTable.Columns.Add("Currency", typeof(string));
            this.lineItemsDataTable.Columns.Add("Issue", typeof(string));
            this.lineItemsDataTable.Columns.Add("Settle", typeof(string));
            this.lineItemsDataTable.Columns.Add("Dlr Comp", typeof(Int32));
            this.lineItemsDataTable.Columns.Add("Maturity", typeof(DateTime));
            this.lineItemsDataTable.Columns.Add("Sector", typeof(string));
            this.lineItemsDataTable.Columns.Add("DV01", typeof(double));
            this.lineItemsDataTable.Columns.Add("Book", typeof(string));
            this.lineItemsDataTable.Columns.Add("Tiestamp", typeof(DateTime));
            this.lineItemsDataTable.Columns.Add("Status", typeof(string));
            this.lineItemsDataTable.Columns.Add("Trader", typeof(string));
            this.lineItemsDataTable.Columns.Add("Type", typeof(string));
            this.lineItemsDataTable.Columns.Add("Internal Spr", typeof(double));
            this.lineItemsDataTable.Columns.Add("Internal Px", typeof(double));
            this.lineItemsDataTable.Columns.Add("Internal Proceeds", typeof(double));
            this.lineItemsDataTable.Columns.Add("Internal Type", typeof(string));
            this.lineItemsDataTable.Columns.Add("Allocated Spr", typeof(double));
            this.lineItemsDataTable.Columns.Add("Allocated Px", typeof(double));
            this.lineItemsDataTable.Columns.Add("Allocated Proceeds", typeof(string));
            this.lineItemsDataTable.Columns.Add("Quote Type", typeof(string));
            this.lineItemsDataTable.Columns.Add("Quote", typeof(double));
            this.lineItemsDataTable.Columns.Add("Quote Proceeds", typeof(double));
            this.lineItemsDataTable.Columns.Add("TW Spr", typeof(double));
            this.lineItemsDataTable.Columns.Add("TW Px", typeof(double));
            this.lineItemsDataTable.Columns.Add("TW Proceeds", typeof(double));
            this.lineItemsDataTable.Columns.Add("TW DV01", typeof(double));
            this.lineItemsDataTable.Columns.Add("BVAL Spr", typeof(double));
            this.lineItemsDataTable.Columns.Add("BVAL Px", typeof(double));
            this.lineItemsDataTable.Columns.Add("BVAL Proceeds", typeof(double));
            
            foreach(PortolioTradeLineItem ptItem in portfolioTradeLineItems)
            {
                DataRow row = lineItemsDataTable.NewRow();
                row[lineItemsDataTable.Columns.IndexOf("Trade#")] = ptItem.TradeId;
                row[lineItemsDataTable.Columns.IndexOf("Side")] = ptItem.Side;
                row[lineItemsDataTable.Columns.IndexOf("Amount")] = ptItem.Amount;
                row[lineItemsDataTable.Columns.IndexOf("Currency")] = ptItem.Currency;
                row[lineItemsDataTable.Columns.IndexOf("Issue")] = ptItem.Issue;
                row[lineItemsDataTable.Columns.IndexOf("Settle")] = ptItem.Settle;

                Console.Write(row.ToString());
            }

        }
    }
}
