using System;

namespace EX1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            //graph.Run("SF", "WS");
            //Console.WriteLine();
            //graph = new Graph();
            //graph.Run("LS", "BC");
            //Console.WriteLine();
            //graph = new Graph();
            //graph.Run("WS", "BC");
            Console.Write("TO:");
            var to = Console.ReadLine();
            Console.Write("FROM:");
            var from = Console.ReadLine();
            graph.Run(to, from);
            Console.ReadKey();
        }
    }
}