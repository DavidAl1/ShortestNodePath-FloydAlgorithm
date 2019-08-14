using System;
using System.Collections.Generic;
using System.Text;

namespace GraphNode
{
    class Graph
    {
        //Edges and vertex sets creation.
        edgeGroup<string> edgesGraph = new edgeGroup<string>();
        vertexGroup<string> vertexGraph = new vertexGroup<string>();

        public Graph()
        {
        }

        //Return graph edges

        public edgeGroup<string> getEdges()
        {
            return edgesGraph;
        }

        //Return graph vertex

        public vertexGroup<string> getVertex()
        {
            return vertexGraph;
        }

        //Add new edge in edge set graph

        public void Insert(string v1, string v2)
        {
            Edge<string> newEdge = new Edge<string>(v1, v2);
            edgesGraph.Insert(newEdge);

            vertexGraph.Insert(v1);
            vertexGraph.Insert(v2);
        }

        //Add bew edge in edge set graph with weight 

        public void Insert(string v1, string v2, double weight)
        {
            Edge<string> newEdge = new Edge<string>(v1, v2, weight); 
            edgesGraph.Insert(newEdge);

            vertexGraph.Insert(v1);
            vertexGraph.Insert(v2);
        }

        //Delete specfic edge

        public void deleteEdge(string v1, string v2)
        {
            Edge<string> edge_to_remove = new Edge<string>(v1, v2);
            edgesGraph.Delete(edge_to_remove);         
        }
        
        //Method to calculate the shortest path => Path with lower cost cosidering the weights between origin and destiny.

        public List<string> ShortestPath(string origin, string destiny)
        {
            List<string> list = new List<string>();
            double[,] AdjacencyMatrix;
            double[,] DistanceMatrix;
            int cicle = 0;   //Round number
            int row = 0, col = 0, cont = 0, i = 0;
            string edge = null;

            //Variables used to obtain the edge weight
            Char charRange1 = ',', charRange2 = ')';
            int startIndex = 0;
            int endIndex = 0;
            int length = 0;
            double weight = 0;

            string[] vertexVector;    
            vertexVector = vertexGraph.getVertex();

            Edge<string>[] edgeVector;
            edgeVector = edgesGraph.getEdges();

            AdjacencyMatrix = new double[vertexGraph.getVertexNumber(), vertexGraph.getVertexNumber()];

            //ADJACECY MATRIX CREATION
            Console.WriteLine("ADJACENCY MATRIX");
            for (row = 0; row < vertexGraph.getVertexNumber(); row++)    
            {
                for (col = 0; col < vertexGraph.getVertexNumber(); col++)
                {

                    Node<Edge<string>> edg = new Node<Edge<string>>();

                    Edge<string> actualEdge = new Edge<string>(vertexVector[row], vertexVector[col]);  //We create the edge to see if they are paired

                    if (row == col)    //Set the diagonal to zero because they are the equal vertex
                    {
                        AdjacencyMatrix[row, col] = 0;
                        Console.Write(" " + AdjacencyMatrix[row, col] + " ");
                    }

                    else if (edgesGraph.isInside(actualEdge) == true)   //If the vertex are paired set the weight
                    {
                        i = 0;
                        cont = 0;
                        while (cont == 0)
                        {
                            if (actualEdge.Equals(edgeVector[i]) == true) //Edge found
                            {
                                edge = edgeVector[i].ToString();   //Edge string of the edge extracted from the vector of edges
                                cont = 1;
                            }
                            i++;
                        }

                        //Get weight using last extracted string
                        //Subtracting between the positions of the last comma and the last parenthesis. And writing the positions between them.

                        startIndex = edge.LastIndexOf(charRange1) + 1;
                        endIndex = edge.LastIndexOf(charRange2);
                        length = endIndex - startIndex;
                        weight = Convert.ToDouble((edge.Substring(startIndex, length).ToString())); //Weight between paired vertex

                        AdjacencyMatrix[row, col] = weight; //If they are paired we put the weight of the edge in the position.
                        Console.Write(" " + AdjacencyMatrix[row, col] + " ");

                    }

                    else if (edgesGraph.isInside(actualEdge) == false)
                    {
                        AdjacencyMatrix[row, col] = 500;  //High value that indicates that there is no relationship between vertex.
                        Console.Write(" " + AdjacencyMatrix[row, col] + " ");
                    }



                }
                Console.WriteLine();
            }

            DistanceMatrix = Floyd(AdjacencyMatrix);  //Floyd Calculate distance matrix using Floyd algorithm
            cicle++;

            Console.WriteLine(); Console.WriteLine();

            //Print the distance matrix
            Console.WriteLine("DISTANCE MATRIX");

            for (row = 0; row < vertexGraph.getVertexNumber(); row++)
            {
                for (col = 0; col < vertexGraph.getVertexNumber(); col++)
                {
                    Console.Write(" " + DistanceMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            int org = 0, dest = 0;

            if (vertexGraph.isInside(origin) == false || vertexGraph.isInside(destiny) == false)
                Console.WriteLine("One of the vertex does not belong to the graph.");

            else
            {
                for (i = 0; i < vertexGraph.getVertexNumber(); i++)  //We see the position of each vertex in the vector of vertices to be able to obtain the desired weight.
                {
                    if (vertexVector[i] == origin)
                        org = i;

                    else if (vertexVector[i] == destiny)
                        dest = i;
                }

                Console.WriteLine();
                Console.WriteLine();

                if (DistanceMatrix[org, dest] != 500 && origin != destiny) //Enter if there is a path and also the vertices are not the same.
                {
                    Console.WriteLine("The distance from " + origin + " to " + destiny + " is " + DistanceMatrix[org, dest]);
                    list.Add(DistanceMatrix[org, dest].ToString());
                }

                else if (origin == destiny)  //Enter if origin=destiny
                {
                    Console.WriteLine("Path: " + origin + ". Distance: 0");
                    list.Add(origin);
                }


                else    //Enter if there is no possible path
                {
                    Console.WriteLine("There is no possible path to go from " + origin + " to " + destiny);
                    list.Add(null);
                }
            }

            return list;
        }

        //Floyd-Warshall algorithm.

        public double[,] Floyd(double[,] MatrizAd)
        {
            double[,] DistanceMatrix = MatrizAd;   //We match the distance matrix to the adjacency matrix.
            int i = 0, j = 0;   // Origin/destiny points
            int k = 0;          //Middle point
            string[] vec = vertexGraph.getVertex(); //Vector of vertices

            for (k = 0; k < vertexGraph.getVertexNumber(); k++)
            {
                for (i = 0; i < vertexGraph.getVertexNumber(); i++)
                {
                    for (j = 2; j < vertexGraph.getVertexNumber(); j++)
                    {
                        if (DistanceMatrix[i, j] > DistanceMatrix[i, k] + DistanceMatrix[k, j]) //If we use k as an intermediate point and arrive before we update dist       
                            DistanceMatrix[i, j] = DistanceMatrix[i, k] + DistanceMatrix[k, j];
                    }
                }
            }
            return DistanceMatrix;
        }
    }
}
