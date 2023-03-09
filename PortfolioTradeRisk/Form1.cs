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


namespace PortfolioTradeRisk
{
    public partial class Form1 : Form
    {
        Session session = null;
        public Form1()
        {
            InitializeComponent();
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
            session.Subscribe(subscriptions);

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
    }
}
