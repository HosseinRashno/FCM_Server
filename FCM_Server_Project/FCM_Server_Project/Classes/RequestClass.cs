using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM_Server_Project.Classes
{
    class RequestClass
    {
        public string to { get; set; }

        private string _priority = StaticHelper.enm_priority.high.ToString();
        public string priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        private long _time_to_live = 4 * 7 * 24 * 60 * 60; // 4 weeks in seconds
        public long time_to_live
        {
            get
            {
                return _time_to_live;
            }
            set
            {
                _time_to_live = value;
            }
        }

        private NotificationClass _notification;
        public NotificationClass notification
        {
            get
            {
                if (_notification == null)
                    _notification = new NotificationClass();
                return _notification;
            }
            set
            {
                _notification = value;
            }
        }
    }
}
