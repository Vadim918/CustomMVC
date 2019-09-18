using System;
using System.IO;
using System.Net;
using System.Text;


namespace WebServer
{
    class Vote
    {
        public static void Post(HttpListener listener, HttpListenerRequest request,HttpListenerContext context)
        {
            if (request.HttpMethod == "POST")
            {   
                Stream body = request.InputStream;
                Encoding encoding = request.ContentEncoding;
               StreamReader reader = new StreamReader(body, encoding);
                Console.WriteLine("Start of client data:");
                // Convert the data to a string and display it on the console.
                string s = reader.ReadToEnd();
                Console.WriteLine(s);
                Console.WriteLine("End of client data:");
                body.Close();
                reader.Close();
            }
        }
    }
}
