using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace web_api_forecast.Models
{
    public class MustDoItem
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }

    }
}
