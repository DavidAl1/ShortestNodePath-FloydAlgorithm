using System;
using System.Collections.Generic;
using System.Text;

namespace GraphNode
{
    class Edge<T>
    {
        T origin;
        T destiny;
        double weight;


        public Edge()
        {
        }

        //Create Edge

        public Edge(T origin, T destiny)
        {
            this.origin = origin;
            this.destiny = destiny;
            this.weight = 0;  //Si no se indica weight se pone a cero.
        }

        public Edge(T origin, T destiny, double weight)
        {
            this.origin = origin;
            this.destiny = destiny;
            this.weight = weight;
        }

        public bool Equals(Edge<T> obj)
        {

            if (this.origin.Equals(obj.origin) && this.destiny.Equals(obj.destiny))
                return true;

            else
                return false;
        }

        //Change format

        public override string ToString()
        {
            return "(" +
                this.origin + "," + this.destiny + "," + this.weight + ")";
        }
    }
}
