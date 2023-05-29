using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace yurovskaya_backend.Models
{
    public class order
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int version { get; set; }
        public string client { get; set; }

        public order(int Id, string title, string client, string description, int version)
        {
            this.Id = Id;
            this.title = title;
            this.client = client;
            this.description = description;
            this.version = version;
        }
    }
}
