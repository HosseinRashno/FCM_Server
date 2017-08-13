using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FCM_Server_Project.Classes
{
    class StaticHelper
    {
        public const string TOPIC_NAME_FORMAT = "/topics/";
        public enum enm_priority
        {
            normal = 0,
            high = 1
        }

        public static ResponseForId SendMessageToFCMId(RequestClass req)
        {
            ResponseForId response = null;

            CommonResponseProperties result = SendMessage(req);
            if (result.ErrorCode == null)
            {
                response = new JavaScriptSerializer().Deserialize<ResponseForId>(result.RawResponse);
                response.ErrorCode = result.ErrorCode;
                response.RawResponse = result.RawResponse;
            }

            return response;
        }

        public static ResponseForTopic SendMessageToTopic(RequestClass req)
        {
            ResponseForTopic response = null;

            CommonResponseProperties result = SendMessage(req);
            if (result.ErrorCode == null)
            {
                response = new JavaScriptSerializer().Deserialize<ResponseForTopic>(result.RawResponse);
                response.ErrorCode = result.ErrorCode;
                response.RawResponse = result.RawResponse;
            }

            return response;
        }

        public static CommonResponseProperties SendMessage(RequestClass req)
        {
            CommonResponseProperties result = new CommonResponseProperties();

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["Authorization"] = "key=" + Program.SERVER_KEY;

            string json = new JavaScriptSerializer().Serialize(req); ;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result.RawResponse = streamReader.ReadToEnd();
            }

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                result.ErrorCode = (int)httpResponse.StatusCode;
            }

            return result;
        }
    }
}
