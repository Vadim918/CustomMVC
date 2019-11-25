using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using WebServer.Model;

namespace WebServer.Controllers
{
    class ParticipantsConroller
    {
        JsonData json = new JsonData();
        public string GetView(string viewName)
        {
            string rootPath = @"D:\ASP.NET\CustomMVC\WebServer\WebServer\Files\";
            if (File.Exists(rootPath + viewName))
            {
                return File.ReadAllText(rootPath + viewName);
            }
            return string.Empty;
        }

        public static void Render(string html, HttpListenerResponse response)
        {
            Stream output;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);
            response.ContentLength64 = buffer.Length;
            output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        public void Handle(HttpListenerContext context)
        {
            string userList = json.JsonALL();

            var html = GetView("participants.html");
            html = html.Replace("{{participants}}", userList);
            Render(html, context.Response);
        }
    }
}
