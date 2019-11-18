using System;
using System.IO;
using System.Net;
using System.Text;
using WebServer.Model;

namespace WebServer.Controllers
{
    class VoteConroller
    {
        JsonData VoteJson = new JsonData();

        public void Handle(HttpListenerResponse response,HttpListenerRequest request)
        {
            string pairs;
                if (request.HttpMethod == "GET")
                {
                    using (StreamReader fstream = new StreamReader(@"vote.html"))
                    {
                        string content = fstream.ReadToEnd();
                        byte[] buffer = Encoding.UTF8.GetBytes(content);
                        response.ContentLength64 = buffer.Length;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        output.Close();
                    }
                }
                else
                {
                    var stream = request.InputStream;
                    var enc = Encoding.UTF8;
                    using (var reader = new StreamReader(stream, enc))
                        pairs = reader.ReadToEnd();
                   
                    pairs = pairs.Remove(0, 5);
                    int ind = pairs.Length - 10;
                    pairs = pairs.Remove(ind);
                   VoteJson.Save(pairs);
                 

            }   
           
        }
        
    }
}
