using System;
using System.Collections.Generic;
using System.Text;

namespace GraphNode
{
    class Node<T>
    {
        private Node<T> next = null;
        private T data;


        public Node()
        {
        }

        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public Node<T> getNext()
        {
            return this.next;
        }

        public T getData()
        {
            return this.data;
        }

        public void setNext(Node<T> next)
        {
            this.next = next;
        }

        public override string ToString()
        {
            return "[Node value: " +
                this.data + "]";
        }
    }
}
