using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlendaGhost
{
    public class TweetMessage
    {
        private DateTime _dt;
        private String _userName;
        private String _id;
        private String _text;
        
        public TweetMessage(String userName, String dt_string, String id, String text)
        {
            _dt = DateTime.ParseExact(dt_string,
                "ddd MMM d HH':'mm':'ss zzz yyyy",
                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                System.Globalization.DateTimeStyles.None);
            _userName = userName;
            _id = id;
            _text = text;
        }

        public DateTime DateTime
        {
            get { return _dt; }
        }

        public String UserName
        {
            get { return _userName; }
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
