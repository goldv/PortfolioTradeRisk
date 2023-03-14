using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTradeRisk.Bloomberg
{
    public class BloombergData
    {
        private string symbol { get; }
        private string benchmark { get; }

        private double bvalBidPrice { get; }
        private double bvalAskPrice { get; }
        private double bvalBidSpread { get; }
        private double bvalAskSpread { get; }

        private double cbbtBidPrice { get; }
        private double cbbtAskPrice { get; }
        private double cbbtBidSpread { get; }
        private double cbbtAskSpread { get; }

        public BloombergData(string symbol, string benchmark, double bvalBidPrice, double bvalAskPrice, double bvalBidSpread, double bvalAskSpread, double cbbtBidPrice, double cbbtAskPrice, double cbbtBidSpread, double cbbtAskSpread)
        {
            this.symbol = symbol;
            this.benchmark = benchmark;
            this.bvalBidPrice = bvalBidPrice;
            this.bvalAskPrice = bvalAskPrice;
            this.bvalBidSpread = bvalBidSpread;
            this.bvalAskSpread = bvalAskSpread;
            this.cbbtBidPrice = cbbtBidPrice;
            this.cbbtAskPrice = cbbtAskPrice;
            this.cbbtBidSpread = cbbtBidSpread;
            this.cbbtAskSpread = cbbtAskSpread;
        }
    }
}
