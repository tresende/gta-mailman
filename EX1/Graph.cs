using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EX1.Models;

namespace EX1
{
    public class Graph
    {

        #region Private Properties

        List<Vertice> Vertices = new List<Vertice>();

        #endregion

        #region Public Methods

        public Graph()
        {
            //Load data
            this.Vertices = new List<Vertice>();
            FileStream fileStream = new FileStream("rotas.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var arr = line.Split(' ');
                    var vertice = this.Vertices.FirstOrDefault(x => x.Name == arr[0]);
                    if (vertice == null)
                    {
                        vertice = new Vertice(arr[0]);
                        this.Vertices.Add(vertice);
                    }
                    vertice.Edges.Add(new Edge(arr[1], int.Parse(arr[2])));
                    line = reader.ReadLine();
                }
            }
            Vertices.SelectMany(x => x.Edges).ToList().ForEach(x => x.Vertice = GetByName(x.Name));
        }

        public string Run(string start, string finish)
        {
            var path = string.Empty;
            var distances = new Dictionary<string, int>();
            var nodes = this.Vertices.ToList();

            foreach (var vertex in Vertices)
            {
                if (vertex.Name == start)
                    distances[vertex.Name] = 0;
                else
                    distances[vertex.Name] = int.MaxValue;
            }

            while (nodes.Any())
            {
                nodes.Sort((x, y) => (distances[x.Name] + NextLevelSearch(x.Name, finish)) - (distances[y.Name] + NextLevelSearch(y.Name, finish)));
                var smallest = nodes[0];
                path += smallest.Name + " ";
                nodes.Remove(smallest);
                if (smallest.Name == finish)
                {
                    return path;
                }
                if (distances[smallest.Name] != int.MaxValue)
                {
                    foreach (var neighbor in smallest.Edges)
                    {
                        var alt = distances[smallest.Name] + neighbor.Distance;
                        if (alt < distances[neighbor.Vertice.Name])
                        {
                            distances[neighbor.Vertice.Name] = alt;
                        }
                    }
                }
            }
            return path;
        }

        #endregion

        #region Private Methods

        private int NextLevelSearch(string start, string finish)
        {
            //is target
            if (start == finish)
                return -1;

            //Check if next is target node
            var nextLevelVertices = GetByName(start).Edges.Select(x => x.Vertice);
            if (nextLevelVertices.Any(x => x.Name == finish))
                return 0;
            return 1;
        }

        /// <summary>
        /// Return Vertice by name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Vertice from list</returns>
        private Vertice GetByName(string name)
        {
            return this.Vertices.FirstOrDefault(x => x.Name == name);
        }

        #endregion

    }
}
