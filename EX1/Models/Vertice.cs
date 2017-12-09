using System.Collections.Generic;

namespace EX1.Models
{
    public class Vertice
    {
        public Vertice(string name)
        {
            this.Name = name;
            this.Edges = new List<Edge>();
        }

        public string Name { get; set; }
        public List<Edge> Edges { get; set; }
    }
}
