using System;
using System.Collections.Generic;


//INFO:
//All classes are generic except "Graph.cs" because the implementation and process made inside it.
//The program does not return the exact path followed but it says the shortest path

namespace GraphNode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();  //List which contains shortestPath result
            Graph graph = new Graph();  
            edgeGroup<string> edges = new edgeGroup<string>(); //edge
            vertexGroup<string> vertex = new vertexGroup<string>(); //Vertex


            //INSERT THE EDGES
            graph.Insert("Lisbon", "London", 6);
            graph.Insert("London", "Paris", 8);
            graph.Insert("Paris", "Morroco", 4);
            graph.Insert("Galicia", "Madrid", 7);

            //SET THE EDGES AND VERTEX INSIDE EACH SET
            edges = graph.getEdges();
            vertex = graph.getVertex();

            //PRINT ALL SETS
            Console.Clear();
            Console.WriteLine("Edge: " + edges.ToString());
            Console.WriteLine("Vertex: " + vertex.ToString());
            Console.WriteLine();
            Console.WriteLine();

            //GET SHORTEST PATH. ONLY ONE AT THE SAME TIME

            list = graph.ShortestPath("Lisbon", "Paris");       // PATH
            //list = graph.ShortestPath("Paris","Paris");       // ORIGIN=DESTINY.
            //list = graph.ShortestPath("London","Madrid");     // NO PATH

            Console.WriteLine();
            Console.Write("List of elements: ");
            list.ForEach(Print); //Print the list content. If the content is null = No path

            Console.ReadKey();
        }

        private static void Print(string s) //Used to print the shortest path list
        {
            Console.WriteLine(s);
        }
    }
}
