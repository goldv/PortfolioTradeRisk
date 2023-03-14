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

using Session = Bloomberglp.Blpapi.Session;
using Subscription = Bloomberglp.Blpapi.Subscription;
using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Event = Bloomberglp.Blpapi.Event;
using Message = Bloomberglp.Blpapi.Message;
using SessionOptions = Bloomberglp.Blpapi.SessionOptions;
using PortfolioTradeRisk.Model;

namespace PortfolioTradeRisk
{
    public partial class PortfolioTradeDetail : Form
    {
        private Session session = null;
        private Model.Model model = null;

        public PortfolioTradeDetail(PortolioTradeLineItem[] portfolioTradeLineItems)
        {
            InitializeComponent();
            this.model = new Model.Model(this.lineItemsDataGridView, portfolioTradeLineItems);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const String apimktdata = "//blp/mktdata";

            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;

            session = new Session(sessionOptions);
            
            session.Start();



            string security = "US037833EP10@BMRK CORP";

            CorrelationID cid = new CorrelationID(security);
            Subscription subscription = new Subscription(security, "BID", "ASK", cid);
            List<Subscription> subscriptions = new List<Subscription>();  
            subscriptions.Add(subscription);
            //session.Subscribe(subscriptions);

            Task eventLoopTask = new Task(() => eventLoop());
            eventLoopTask.Start();

        }

        private void eventLoop()
        {
            while (true)
            {
                try
                {
                    Event eventObj = session.NextEvent();
                    if(eventObj.Type == Event.EventType.SUBSCRIPTION_DATA)
                    {
                        Console.WriteLine(eventObj);
                    }
                    
                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
    }
}
