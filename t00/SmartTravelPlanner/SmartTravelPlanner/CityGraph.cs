using System;
using System.Collections.Generic;
using System.IO;

namespace Travelling {
    public class Edge
    {
        public string City { get; set; }
        public int Distance { get; set; }

        public Edge(string city, int distance)
        {
            City = city;
            Distance = distance;
        }
    }

    public class CityGraph
    {
        private Dictionary<string, List<Edge>> adjacencyList;
        private List<(string A, string B, int Distance)> edges = new List<(string, string, int)>();


        private CityGraph()
        {
            adjacencyList = new Dictionary<string, List<Edge>>();
        }

        public static CityGraph LoadFromFile(string filePath)
        {
            CityGraph graph = new CityGraph();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string[] cities = parts[0].Split('-');

                string cityA = cities[0];
                string cityB = cities[1];
                int distance = int.Parse(parts[1]);

                graph.edges.Add((cityA, cityB, distance));

                graph.AddConnection(cityA, cityB, distance);
                graph.AddConnection(cityB, cityA, distance);
            }

            return graph;
        }

        private void AddConnection(string from, string to, int distance)
        {
            if (!adjacencyList.ContainsKey(from))
            {
                adjacencyList[from] = new List<Edge>();
            }

            adjacencyList[from].Add(new Edge(to, distance));
        }

        public List<string> FindShortestPath(string from, string to)
        {

            Dictionary <string, int> distance = new Dictionary<string, int>(); 

            foreach (string city in adjacencyList.Keys)
                distance[city] = 2000000000;
            distance[from] = 0;

            var previous = new Dictionary<string, string>();

            foreach (string city in adjacencyList.Keys)
                previous[city] = null;

            var unvisited = new List<string>(); 
            
            foreach (string city in adjacencyList.Keys)
                unvisited.Add(city);
 
            string current; 

            while (unvisited.Count != 0)
            {
                current = null;
                int min = int.MaxValue;

                foreach (string city in unvisited)
                {
                    if (distance[city] < min) {
                        min = distance[city];
                        current = city;
                    }
                }

                if (current == null || distance[current] == int.MaxValue)
                    break;

                if (current == to)
                    {
                        break;
                    }

                foreach (var edge in adjacencyList[current]) 
                {
                    var neighbour = edge.City;
                    
                    int newDistance = distance[current] + edge.Distance;

                    if (newDistance < distance[neighbour])
                    {
                        distance[neighbour] = newDistance;
                        previous[neighbour] = current;
                    }
                }

                unvisited.Remove(current);

            }

            List<string> path = new List<string>();
            current = to;
            while (current != from)
            {
                path.Insert(0, current);
                current = previous[current];
            }
            path.Insert(0, from);
            return path;
        }

        public int GetPathDistance (List<string> path)
        {
            int distance = 0;
            for (int i = 0; i < path.Count-1; i++)
            {
                string from = path[i];
                string to = path[i+1];

                int cost = 0;
                foreach(var edge in adjacencyList[from])
                {
                    if (edge.City == to)
                    {
                        cost = edge.Distance;
                        break;
                    }
                }

                distance += cost;


            }
            
            return distance;
        }

        
        public override string ToString()
        {
            string result = "";

            foreach (var e in edges)
            {
                result += $"{e.A}-{e.B},{e.Distance}\n";
                result += $"{e.B}-{e.A},{e.Distance}\n";
            }

            return result;
        }

    }
}