using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using WebServer.Controllers;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            string index = "http://*:8881/";
            listener.Prefixes.Add(index);            
            IndexConroller homeconroller = new IndexConroller();
            VoteConroller voteConroller = new VoteConroller();
            ParticipantsConroller participantsConroller = new ParticipantsConroller();

            while (true)
            {
                Console.WriteLine("Ожидание подключений...");
                listener.Start();

                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                if (request.RawUrl.Contains("/participants.html"))
                {
                    participantsConroller.Handle(response);
                   
                }
                else if (request.RawUrl.Contains("/vote.html"))
                {
                    voteConroller.Handle(response,request);                  
                }
                else
                {
                    homeconroller.Handle(response);
                }
                listener.Stop();
                Console.WriteLine("Обработка подключений завершена");
            }
        }
    }
}
