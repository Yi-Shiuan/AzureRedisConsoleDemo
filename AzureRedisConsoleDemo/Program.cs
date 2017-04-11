using StackExchange.Redis;
using System;

namespace AzureRedisConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var redis = ConnectionMultiplexer.Connect("localhost:6379, defaultdatabase=0");

            redis.GetSubscriber().Subscribe("AzureRedisPub", (channel, value) =>
            {
                Console.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss} - {value}");
            });

            while (true)
            {
                Console.ReadLine();
            }            
        }
    }
}