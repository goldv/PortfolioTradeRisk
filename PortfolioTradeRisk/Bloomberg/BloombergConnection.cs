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
using Bloomberglp.Blpapi;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Concurrent;

namespace PortfolioTradeRisk.Bloomberg
{
    internal class BloombergConnection
    {
        public delegate void BloombergCallback(BloombergData data);

        private const String API_MKDATA = "//blp/mktdata";

        private ConcurrentDictionary<string, ConcurrentDictionary<string, BloombergCallback>> subscriptions;
        private ConcurrentDictionary<string, BloombergData> currentValues;
        private ConcurrentDictionary<string, byte> newSubscriptions;

        private volatile Session session;
        private volatile bool running = false;

        public BloombergConnection()
        {
            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;
            this.session = new Session(sessionOptions);
            this.subscriptions = new ConcurrentDictionary<string, ConcurrentDictionary<string, BloombergCallback>>();
            this.currentValues = new ConcurrentDictionary<string, BloombergData>();
            this.newSubscriptions = new ConcurrentDictionary<string, byte>();
        }

        public void Start()
        {
            session.Start();
            running = true;
            Task eventLoopTask = new Task(() => eventLoop());
            eventLoopTask.Start();
        }

        public void Subscribe(string id, List<string> symbols,  BloombergCallback callback)
        {
            foreach(string symbol in symbols)
            {
                ConcurrentDictionary<string, BloombergCallback> symbolSubscriptions = this.subscriptions.GetOrAdd(symbol, k => new ConcurrentDictionary<string, BloombergCallback>());
                symbolSubscriptions.TryAdd(id, callback);
            }
            
            this.newSubscriptions.TryAdd(id, 1);
        }

        private void eventLoop()
        {
            while (running)
            {
                foreach(KeyValuePair<string, byte> pair in this.newSubscriptions){

                    newSubscriptions.TryRemove(pair.Key, out _);
                    publishForId(pair.Key);
                }
                try
                {
                    Event eventObj = session.NextEvent();
                    if (eventObj.Type == Event.EventType.SUBSCRIPTION_DATA)
                    {
                        Console.WriteLine(eventObj);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }

        private void publishForId(string id)
        {
            foreach (KeyValuePair<string, ConcurrentDictionary<string, BloombergCallback>> pair in this.subscriptions)
            {
                ConcurrentDictionary<string, BloombergCallback> symbolDict = pair.Value;

                BloombergCallback callback;
                BloombergData data;
                if(symbolDict.TryGetValue(id, out callback))
                {
                    currentValues.TryGetValue(pair.Key, out data);
                    callback(data);
                }
            }
        }
    }
}
