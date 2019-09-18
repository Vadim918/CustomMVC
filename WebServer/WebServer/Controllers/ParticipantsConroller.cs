using System.IO;
using System.Net;
using System.Text;
using WebServer.Model;

namespace WebServer.Controllers
{
    class ParticipantsConroller
    {
        JsonData json = new JsonData();
        public void Handle(HttpListenerResponse response)            
        {            
            byte[] buffer = Encoding.Default.GetBytes(json.JsonALL());
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            
        }
    }
}
