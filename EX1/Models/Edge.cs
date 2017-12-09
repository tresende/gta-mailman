using System;

namespace EX1.Models
{
    public class Edge
    {
        public Edge(string name, int distance)
        {
            this.Distance = distance;
            this.Name = name;
        }

        public int Distance { get; set; }
        public string Name { get; set; }
        public Vertice Vertice { get; set; }
    }
}
