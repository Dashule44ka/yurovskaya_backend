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


        public client(int Id, string surname, string name, string email)
        {
            this.Id = Id;
            this.surname = surname;
            this.name = name;
            this.email = email;
        }

    }
}
