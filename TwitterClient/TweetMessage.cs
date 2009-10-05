using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterClient
{
    class TweetMessage
    {
        private DateTime _dt;
        private String _id;
        private String _text;
        
        public TweetMessage(DateTime dt, String id, String text)
        {
            _dt = dt;
            _id = id;
            _text = text;
        }

        public TweetMessage(String id, String text)
        {
            _id = id;
            _text = text;
        }

        public DateTime DateTime
        {
            get { return _dt; }
        }

        public String Id
        {
            get { return _id; }
        }

        public String Text
        {
            get { return _text; }
        }
    }
}
