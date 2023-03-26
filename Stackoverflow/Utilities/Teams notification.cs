using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace StackOverflow.Utilities
{
    public class Teams_notification
    {
        public static void sendMessagetoTeams(string name, string receiverType, string message)
        {
            string url = @"https://bda.micron.com/teams/message";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Create Web Request
            HttpWebRequest Request = WebRequest.Create(url) as HttpWebRequest;
            Request.Method = "POST";
            Request.Timeout = int.MaxValue;
            string headers = "<header><header name=\"Content-Type\" value=\"application/json\"/></header>";
            // Add Headers
            if (!string.IsNullOrEmpty(headers))
            {
                XmlDocument Headers = new XmlDocument();
                Headers.LoadXml(headers);
                foreach (XmlNode Node in Headers.SelectSingleNode("header").ChildNodes)
                {
                    if (Node.Attributes[0].Value == "Content-Type")
                    {
                        Request.ContentType = Node.Attributes[1].Value;
                    }
                    else
                    {
                        Request.Headers.Add(Node.Attributes[0].Value, Node.Attributes[1].Value);
                    }
                }
            }
            string body = "{\"Receivers\":[ {\"Type\":\"" + receiverType + "\",\"Name\":\"" + name + "\"}],\"Message\":{\"body\":{\"contentType\":\"html\",\"content\":\"" + message + "\"                }         }        }";
            // Set Request Body
            if (!string.IsNullOrEmpty(body))
            {
                byte[] Data = System.Text.Encoding.UTF8.GetBytes(body);
                Request.ContentLength = Data.Length;
                Stream RequestStream = Request.GetRequestStream();
                RequestStream.Write(Data, 0, Data.Length);
                RequestStream.Close();
            }

            // Make Call
            int RetryCount = 1;
            int Interval = 500;
            HttpWebResponse Response = null;
            while (RetryCount > 0)
            {
                try
                {
                    Response = Request.GetResponse() as HttpWebResponse;
                    if (Response.StatusCode == HttpStatusCode.OK ||
                        Response.StatusCode == HttpStatusCode.Accepted ||
                        Response.StatusCode == HttpStatusCode.Created ||
                        Response.StatusCode == HttpStatusCode.NoContent)
                        break;
                    else
                        throw new Exception(Response.StatusDescription);
                }
                catch (Exception)
                {
                    RetryCount--;
                    if (RetryCount == 0)
                        throw;
                    else
                        System.Threading.Thread.Sleep(Interval);
                }
            }
        }
    }
}
