﻿using KeyVault;
using System;

namespace Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = ApplicationContextFactory.CreateApplicationContext(GetSecrets.ConnectionString))
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