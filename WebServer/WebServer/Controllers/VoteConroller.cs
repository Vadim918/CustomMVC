using System.IO;
using System.Net;
using System.Text;


namespace WebServer.Controllers
{
    class VoteConroller
    {
        public void Handle(HttpListenerResponse response)
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
    }
}
