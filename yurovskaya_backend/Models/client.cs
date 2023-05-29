using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace yurovskaya_backend.Models
{
    public class client
    {
        public int Id    { get; set; }

        //[Required]//поле ниже является обязательным для заполнения
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        internal void Addclient(client? client)
        {
            throw new NotImplementedException();
        }

        List<Order>? orders;
        


        public client()
        {
            this.orders = new List<Order>();
        }

    }
}
