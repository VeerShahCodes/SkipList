using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkipList
{
    public class Node<T>
        where T : IComparable<T>
    {
        public T Value; // Value of the node
        public Node<T> Next; // Rightward connection
        public Node<T> Down; // Downward connection
        public int Height => GetHeight(); // Vertical height of the node

        public Node(T value) 
        {
            Value = value;
            Next = null;
            Down = null;
        } // Fill out constructors
        public Node(T value, Node<T> down) 
        {
            Value = value;
            Down = down;
            Next = null;
        }
        public Node(T value, Node<T> down,Node<T> next)
        {
            Value = value;
            Down = down;
            Next = next;
        }
        int GetHeight()
        {
            if (Down == null) return 1;
            return Down.GetHeight() + 1;
        }
    }
}