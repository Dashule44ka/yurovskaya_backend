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
    public class Diz
    {
        public int id { get; set; }
        public IList<client>? client { get; set; }
        public IList<order>? order { get; set; }

        public Diz()
        {
            order = new List<order>();
            client = new List<client>();
        }

        public Diz(IList<client>? client, IList<order>? order)
        {
            this.id = id;
            this.client = client;
            order = order;
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