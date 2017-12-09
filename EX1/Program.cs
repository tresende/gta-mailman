using System;

namespace EX1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            var path = graph.Run("WS", "BC");
            Console.WriteLine(path);
            Console.ReadKey();
        }
    }
}