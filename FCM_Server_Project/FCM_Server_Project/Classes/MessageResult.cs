using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM_Server_Project.Classes
{
    class MessageResult
    {
        /// <summary>
        /// String specifying a unique ID for each successfully processed message.
        /// </summary>
        public string message_id { get; set; }

        /// <summary>
        /// Optional string specifying the canonical registration token for the client app that the message was processed and sent to. Sender should use this value as the registration token for future requests. Otherwise, the messages might be rejected.
        /// </summary>
        public string registration_id { get; set; }

        /// <summary>
        /// String specifying the error that occurred when processing the message for the recipient. A list of possible values can be found at https://firebase.google.com/docs/cloud-messaging/http-server-ref?hl=en-us#table9
        /// </summary>
        public string error { get; set; }
    }
}
