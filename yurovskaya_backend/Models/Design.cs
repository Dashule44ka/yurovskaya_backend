using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace yurovskaya_backend.Models
{
    public class Design
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int version { get; set; }
        //public string client { get; set; }
        List<Order>? orders;

        public Design()
        {
            this.orders = new List<Order>();
        }
    }
}
