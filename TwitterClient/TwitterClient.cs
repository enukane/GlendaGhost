using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Xml;

namespace TwitterClient
{
    class TwitterClient
    {
        private string _id;
        private string _password;
        private long _lastId;

        private Queue _messageQueue;

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

        public TwitterClient(string id, string password)
        {
            _id = id;
            _password = password;

            _messageQueue = Queue.Synchronized(new Queue());
        }

        public void Start()
        {
            String text;
            String id_text;
            long id;
            String dateString;
            DateTime dt;
            long thisLastId;

            HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create("http://twitter.com/statuses/friends_timeline.xml?count=200");
            webreq.Credentials = new NetworkCredential(_id, _password);

            /** Thread do here **/

            HttpWebResponse webres = (HttpWebResponse)webreq.GetResponse();

            Stream stream = webres.GetResponseStream();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stream);

            XmlNodeList statusList = xmlDocument.SelectNodes("/statuses/status");

            for (int i = statusList.Count; i >= 0; i--)
            {

                TweetMessage tMsg;
                XmlNode statusNode = statusList[i];
                

                id_text = statusNode.SelectSingleNode("id").InnerText;
                id = long.Parse(id_text);
                
                if (_lastId.HasValue)
                {
                    if (_lastId > id) // text with id is older than that with _lastId
                    {
                        continue;
                    }

                    // text with id is newer than that with _lastId -> push in to queue
                    
                    text = statusNode.SelectSingleNode("text").InnerText;
                    tMsg = new TweetMessage(id_text, text);
                    thisLastId = id;
                }
            }



            /** Thread ends here **/

        }

        public string GetMessage()
        {
            (string)_messageQueue.Dequeue();
        }

    }
}
