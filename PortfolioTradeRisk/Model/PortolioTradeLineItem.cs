using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTradeRisk.Model
{
    public class PortolioTradeLineItem
    {
        [Name("Trade#")]
        public string TradeId { get; set; }

        [Name("Side")]
        public string Side { get; set; }

        [Name("Amount")]
        public double Amount { get; set; }

        [Name("Currency")]
        public string Currency { get; set; }

        [Name("Issue")]
        public string Issue { get; set; }

        [Name("Settle")]
        public string Settle { get; set; }

        [Name("Dlr Comp")]
        public int DlrComp { get; set; }

        [Name("Maturity")]
        public string Maturity { get; set; }

        [Name("Sector")]
        public string Sector { get; set; }

    }
}
