﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
   internal class Json
    {

        public override string ToString()
        {
            return ($"List going to the event:{string.Join("<li> </li>",  Users.ToArray())}");
        }

        public List<string> Users { get; set; }

    }
}
