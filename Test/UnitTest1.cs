using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EX1;

namespace Test
{
    [TestClass]
    public class UnitGraph
    {
        [TestMethod]
        public void TestGraph()
        {
            Graph graph = new Graph();
            Assert.AreEqual(graph.Run("WS", "BC"), "WS SF LV BC ");

            //graph.Run("SF", "WS");
            ////Console.WriteLine();
            ////graph = new Graph();
            ////graph.Run("LS", "BC");
            ////Console.WriteLine();
            ////graph = new Graph();
            ////graph.Run("WS", "BC");
            //Console.Write("TO:");
            //var to = Console.ReadLine();
            //Console.Write("FROM:");
            //var from = Console.ReadLine();
            //graph.Run(to, from);
            //Console.ReadKey();
        }
    }
}
