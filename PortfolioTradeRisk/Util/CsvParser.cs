using CsvHelper.Configuration;
using CsvHelper;
using PortfolioTradeRisk.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTradeRisk.Util
{
    internal class CsvParser
    {
        public static Task<PortolioTradeLineItem[]> parsePortfolioLineItems(string file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
            };

            return Task.Run(() =>
            {
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<PortolioTradeLineItem>();

                    return records.ToArray<PortolioTradeLineItem>();
                }
            });    
        }
    }
}
