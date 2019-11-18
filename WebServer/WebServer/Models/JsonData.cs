using Newtonsoft.Json;
using System.IO;
using WebServer.Models;

namespace WebServer.Model
{
   class JsonData : Json
  {    
        public string JsonALL()
        {   
            Json resultJson = JsonConvert.DeserializeObject<Json>(File.ReadAllText(@"participants.json"));
            string content = resultJson.ToString();
            return content;
        }
        public void Save(string newUser)
        {
            var json =  JsonConvert.DeserializeObject<Json>(File.ReadAllText("participants.json"));
            json.Users.Add(newUser);
            File.WriteAllText(@"participants.json", JsonConvert.SerializeObject(json));  
           
        }
    }
}
