using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM_Server_Project.Classes
{
    class ResponseForTopic : CommonResponseProperties
    {
        /// <summary>
        /// The topic message ID when FCM has successfully received the request and will attempt to deliver to all subscribed devices.
        /// </summary>
        public long? message_id { get; set; }

        /// <summary>
        /// Error that occurred when processing the message. A list of possible values can be found at https://firebase.google.com/docs/cloud-messaging/http-server-ref?hl=en-us#table9.
        /// </summary>
        public string error { get; set; }
    }
}
