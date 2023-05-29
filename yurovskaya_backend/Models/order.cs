using yurovskaya_backend.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text.Json;

namespace yurovskaya_backend.Models
{
    public class Order
    {
        public int id { get; set; }
        public int clientid { get; set; }
        public int designid { get; set; }
        public client? client { get; set; }
        public Design? design { get; set; }

        public Order() { }
        public Order(OrderDTO dto)
        {
            clientid = dto.clientid;
            designid = dto.designid;
        }

        //public Diz(int id, IList<client>? client, IList<order>? order)
        //{
        //    this.id = id;
        //    client = client;
        //    order = order;
        //}


        //public void Addclient(client client)
        //{
        //    client.Add(client);
        //}

        //public void Deleteclient(client client)
        //{
        //    client.Remove(client);client
        //}
    }
}