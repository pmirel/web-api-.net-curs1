using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace web_api_forecast.Models
{
    public class MustDoItem
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public bool isAvailable { get; set; }

    }
}
