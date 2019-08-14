using System;
using System.Collections.Generic;
using System.Text;

namespace GraphNode
{
    class edgeGroup<T> : Node<Edge<T>>
    {
        Node<Edge<T>> firstNode = new Node<Edge<T>>();
        int num_Edges = 0;


        //Constructors

        public edgeGroup()
        {
            this.firstNode = null;
        }

        public edgeGroup(edgeGroup<T> anotherGroup)
        {
            edgeGroup<T> NewGroup = new edgeGroup<T>();
            NewGroup = anotherGroup;
        }

        public bool isEmpty()
        {
            if (firstNode == null)
                return true;
            else
                return false;
        }

        //Insert edge in group of edges

        public void Insert(Edge<T> e)
        {

            Node<Edge<T>> Edge = new Node<Edge<T>>(e);  //New edge to insert
            Node<Edge<T>> actual = new Node<Edge<T>>();   //Aux node
            actual = firstNode;

            if (isEmpty() == true)
            {
                firstNode = Edge;
                num_Edges++;
            }

            else if (isInside(e) == true)
                Console.WriteLine("Edge alredy inside the group.");

            else if (isEmpty() == false)
            {
                while (actual.getNext() != null)
                {
                    actual = actual.getNext();
                }

                actual.setNext(Edge);
                num_Edges++;
            }
        }

        // Delete Edge in the group

        public void Delete(Edge<T> e)
        {
            Node<Edge<T>> actual = new Node<Edge<T>>();
            Node<Edge<T>> anterior = new Node<Edge<T>>();
            actual = firstNode;
            anterior = actual;

            if (isEmpty() == true)
                Console.WriteLine("There is no edge.");

            else
            {

                if (isInside(e) == false)
                    Console.WriteLine("Edge is not inside in the group.");

                else if (firstNode.getData().Equals(e) == true)
                {
                    firstNode = firstNode.getNext();
                    num_Edges--;
                }

                else
                {
                    while (actual.getNext() != null)
                    {
                        if (actual.getData().Equals(e) == true)
                        {
                            anterior.setNext(actual.getNext());
                            num_Edges--;
                        }
                        anterior = actual;
                        actual = actual.getNext();
                    }

                    if (actual.getData().Equals(e) == true)
                    {
                        anterior.setNext(actual.getNext());
                        num_Edges--;
                    }

                }

            }
        }

        //Return array with all edges

        public Edge<T>[] getEdges()
        {
            Node<Edge<T>> actual = new Node<Edge<T>>();
            Edge<T>[] vector;
            int i = 0;


            if (isEmpty() == true)
            {
                Console.WriteLine("There is no edge.");
                return null;
            }

            else
            {
                vector = new Edge<T>[num_Edges];
                actual = firstNode;

                while (actual.getNext() != null)
                {
                    vector[i] = actual.getData();
                    i++;
                    actual = actual.getNext();
                }

                vector[i] = actual.getData();

                return vector;
            }

        }

        //Return number of edges 

        public int GetNumeroEdges()
        {
            if (isEmpty() == true)
                return 0;
            return num_Edges;
        }

        //Return 'true' if 'e' is inside the edge group

        public bool isInside(Edge<T> e)
        {
            Node<Edge<T>> actual = new Node<Edge<T>>();
            actual = firstNode;

            while (actual.getNext() != null)
            {
                if (actual.getData().Equals(e) == true)
                    return true;
                actual = actual.getNext();
            }

            if (actual.getData().Equals(e) == true)
                return true;

            return false;
        }

        //Return the text in format {(o1, d1, p1), (o2, d2, p2), …, (on, dn, pn)}.

        public override string ToString()
        {
            int i = 0;
            Edge<T>[] vector = getEdges();
            string result = null;

            for (i = 0; i < num_Edges; i++)
            {
                if (num_Edges - i == 1)
                    result += vector[i];
                else
                    result += vector[i] + ",";
            }

            return "{" + result + "}";
        }
    }
}
