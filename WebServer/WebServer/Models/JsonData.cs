using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace WebServer.Model
{
  class JsonData
    {
       public override string ToString()
        {
            return ($"Приглашённые на вееринку:{string.Join("\n", Users.ToArray())}");
        }

        public List<string> Users { get;  set; }
     
        private object DataObject()
        {
            JsonData json = new JsonData()
            {
                Users = new List<string>
                {
                    "Oleg",
                    "Vadim",
                    "Sasha",
                    "Dima",
                    "James",
                }
            };
            return json;
        }
        public string JsonALL()
        {
            var json = DataObject();
            string create = JsonConvert.SerializeObject(json);
            File.WriteAllText(@"participants.json", create);
           var jsonFile = File.ReadAllText(@"participants.json");
            JsonData resultJson = JsonConvert.DeserializeObject<JsonData>(jsonFile);
            string content = resultJson.ToString();
            return content;
        }
    }
}
