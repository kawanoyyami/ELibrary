using Entity.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System;

namespace Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = ApplicationContextFactory.CreateApplicationContext("DefaultConnection"))
            {
                if (db.Database.CanConnect())
                {
                    Console.WriteLine("Connection with Database - success!");
                }
            }
            Console.Read();
        }
    }
}