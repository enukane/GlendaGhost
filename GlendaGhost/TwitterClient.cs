using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Xml;
using System.Threading;
using System.Diagnostics;

namespace GlendaGhost
{
    public class TwitterClient
    {
        private string _id;
        private string _password;
        private long? _lastId;
        private int _span = 30000;
        private int _tweetCount = 120;

        private readonly object lockObject = new object();

        private Queue _messageQueue;

        TimerCallback _timerDelegate;
        Timer _timer;



        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Pass
        {
            get { return _id; }
            set { _id = value; }
        }

        public int TweetCount(int? tweetCount)
        {
            int currentTweetCount;

            lock (lockObject)
            {
                if (tweetCount.HasValue)
                {
                    _tweetCount = (int)tweetCount;
                }
                currentTweetCount = _tweetCount;
            }

            return currentTweetCount;
        }

        public TwitterClient(string id, string password, int tweetCount)
        {
            _id = id;
            _password = password;
            _tweetCount = tweetCount;

            _messageQueue = Queue.Synchronized(new Queue());


        }

        public void _UpdateQueue(object o)
        {
            try
            {
                String text = "";
                String userName = "";
                String id_text = "";
                long id;
                String date_text = "";
                long? thisLastId = null;

                Debug.WriteLine("_UpdateQueue called");

                HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create("http://twitter.com/statuses/friends_timeline.xml?count=120");
                webreq.Credentials = new NetworkCredential(_id, _password);

                HttpWebResponse webres = (HttpWebResponse)webreq.GetResponse();

                Stream stream = webres.GetResponseStream();

                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.Load(stream);


                XmlNodeList statusList = xmlDocument.SelectNodes("/statuses/status");

                Debug.WriteLine("_UpdateQueue : node set done");

                for (int i = statusList.Count - 1; i >= 0; i--)
                {

                    TweetMessage tMsg;
                    XmlNode statusNode = statusList[i];

                    id_text = statusNode.SelectSingleNode("id").InnerText;
                    id = long.Parse(id_text);

                    if (_lastId.HasValue)
                    {
                        if (_lastId >= id) // text with id is older than that with _lastId
                        {
                            continue;
                        }
                    }

                    // if text with id is newer than that with _lastId
                    // or no _lastId is set
                    // -> push in to queue
                    date_text = statusNode.SelectSingleNode("created_at").InnerText;
                    text = statusNode.SelectSingleNode("text").InnerText;
                    userName = statusNode.SelectSingleNode("user/screen_name").InnerText;

                    tMsg = new TweetMessage(userName, date_text, id_text, text);

                    Debug.WriteLine("Enqueued {0}", id.ToString());
                    _messageQueue.Enqueue(tMsg);

                    thisLastId = id;
                }


                if (thisLastId.HasValue)
                {
                    _lastId = thisLastId;
                }

                Debug.WriteLine("_UpdateQueue : node in queue done");

                Debug.WriteLine("Last one : " + date_text + " " + id_text + " " + text);

            }
            catch (XmlException ex)
            {
                Debug.WriteLine("XML Exception : " + ex.Message);
            }
            catch (SystemException ex)
            {
                Debug.WriteLine("Unhandled exception : " + ex.Message);
            }
                return;
        }

        public void Start(int second)
        {
            _span = second * 1000;

            _timerDelegate = new TimerCallback(_UpdateQueue);
            _timer = new Timer(_timerDelegate, null, 0, _span);



        }

        public TweetMessage GetMessage()
        {
            if (_messageQueue.Count == 0)
            {
                return null;
            }
            else
            {
                return (TweetMessage)_messageQueue.Dequeue();
            }
        }

    }
}
