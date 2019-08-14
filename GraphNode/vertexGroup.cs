using System;
using System.Collections.Generic;
using System.Text;

namespace GraphNode
{
    class vertexGroup<T> : Node<T>
    {
        private Node<T> next = null;
        private Node<T> firstNode;
        private int num_vertex = 0;

        //Constructor.

        public vertexGroup()
        {
            this.next = null;
            this.firstNode = null;
        }

        //Copy constructor

        public vertexGroup(vertexGroup<T> otherGroup)
        {
            vertexGroup<T> NewSet = new vertexGroup<T>();
            NewSet = otherGroup;
        }

        public bool isEmpty()
        {
            if (num_vertex == 0)
                return true;
            else
                return false;
        }

        //Add the vertex to the group

        public void Insert(T e)
        {
            Node<T> node = new Node<T>(e);
            next = firstNode;

            if (isEmpty() == true)  //If the group is empty => The vertex is the first vertex
            {
                firstNode = node;
                num_vertex++;
            }

            else if (isInside(e) == true)  //Check if it is in the group
                Console.WriteLine("Vertex already in the set.");

            else if (isEmpty() == false)    //If is not in the group => last pos
            {
                while (next.getNext() != null)
                    next = next.getNext();

                next.setNext(node);
                num_vertex++;
            }
        }

        //Delete vertex

        public void delete(T e)
        {

            Node<T> last = new Node<T>();
            Node<T> actual = new Node<T>();

            actual = firstNode;
            last = null;


            if (isEmpty() == true)  //Check vertex number
                Console.WriteLine("There is no vertex.");

            else if (firstNode.getData().Equals(e) == true)     //If we want to delete the first node
            {
                firstNode = firstNode.getNext();
                num_vertex--;
            }

            else if (isEmpty() == false)
            {
                last = firstNode;
                actual = actual.getNext();

                while (actual.getNext() != null)
                {
                    if (actual.getData().Equals(e) == true)  //Data found. Set next value of last to next value of deleted data
                    {
                        last.setNext(actual.getNext());
                        num_vertex--;
                    }

                    actual = actual.getNext();
                    last = last.getNext();

                }

                if (actual.getData().Equals(e) == true)  //If we want to delete the last data we set the next value of last data to null value
                {
                    last.setNext(null);
                    num_vertex--;
                }
            }

            else
                Console.WriteLine("Vertex not found.");

        }

        //Return array with stored values in vertex group.

        public T[] getVertex()
        {
            Node<T> actual = new Node<T>();
            T[] vector;    //Vector with stored vertex
            int i = 0;

            if (isEmpty() == true)
            {
                Console.WriteLine("There is no vertex.");
                return null;
            }

            else
            {
                vector = new T[num_vertex];  //We assign the vector as many positions as there are vertex
                actual = firstNode;

                while (actual.getNext() != null)
                {
                    vector[i] = actual.getData();
                    actual = actual.getNext();
                    i++;
                }

                vector[i] = actual.getData();
                return vector;
            }
        }

        //Return vertex number

        public int getVertexNumber()
        {
            if (isEmpty() == true)
                return 0;

            return num_vertex;
        }

        //Text format {v1, v2, …, vn} 

        public override string ToString()
        {
            int i = 0;
            T[] vector = getVertex();
            string result = null;

            for (i = 0; i < num_vertex; i++)
            {
                if (num_vertex - i == 1)
                    result += vector[i];
                else
                    result += vector[i] + ",";
            }

            return "{" + result + "}";
        }

        //Return 'true' if the vertex is contained 

        public bool isInside(T e)
        {
            Node<T> actual = new Node<T>();
            actual = firstNode;

            while (actual.getNext() != null)
            {
                if (actual.getData().Equals(e) == true)
                    return true;
                actual = actual.getNext();
            }

            if (actual.getData().Equals(e) == true) //Last element
                return true;

            return false;
        }
    }
}
