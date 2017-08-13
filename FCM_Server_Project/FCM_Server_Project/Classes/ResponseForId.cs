using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM_Server_Project.Classes
{
    class ResponseForId : CommonResponseProperties
    {
        /// <summary>
        /// Unique ID (number) identifying the multicast message.
        /// </summary>
        public long multicast_id { get; set; }

        /// <summary>
        /// Number of messages that were processed without an error.
        /// </summary>
        public long success { get; set; }

        /// <summary>
        /// Number of messages that could not be processed.
        /// </summary>
        public long failure { get; set; }

        /// <summary>
        /// Number of results that contain a canonical registration token.
        /// </summary>
        public long canonical_ids { get; set; }

        /// <summary>
        /// Objects representing the status of the messages processed. The objects are listed in the same order as the request (i.e., for each registration ID in the request, its result is listed in the same index in the response).
        /// </summary>
        public List<MessageResult> results { get; set; }
    }
}
