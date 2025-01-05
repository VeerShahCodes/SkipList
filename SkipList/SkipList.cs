using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{

    public class SkipList<T> where T : IComparable<T>
    {
        Random random = new Random();
        Node<T> Head;

        public SkipList(T val)
        {
            Head = new Node<T>(val);
        }
        public int ChooseRandomHeight(Random rand)
        {
            int height = 1;
            while (true)
            {
                int randNum = rand.Next(2);
                if (randNum == 0) break;
                else
                {
                    height++;
                }
            }
            return height;

        }

        public void Add(T val)
        {
            int height = ChooseRandomHeight(random);
            //make head taller if needed

            if (height - Head.Height > 1)
            {
                height = Head.Height + 1;
                Head = new Node<T>(val, Head);
            }

            RecAdd(Head, val, height);
        }

        Node<T> RecAdd(Node<T> Current, T val, int height)
        {
            //Base case
            if (Current == null) return null;

            //Down            
            if (Current.Next == null || Current.Next.Value.CompareTo(Current.Value) > 0)
            {
                //Rec Case
                var temp = RecAdd(Current.Down, val, height);
                //Up
                Node<T> addNode = new Node<T>(val, temp, Current.Next);
                if (addNode.Height <= height)
                {
                    Current.Next = addNode;
                    return addNode;
                }
                else
                {
                    return temp;
                }


            }
            else
            {
                //Rec Case
                var temp = RecAdd(Current.Next, val, height);
                //Up
                return temp;

            }


        }

        public bool Search(T val)
        {
            return RecSearch(Head, val);
        }

        bool RecSearch(Node<T> Current, T val)
        {
            if (Current == null) return false;
            if (Current.Value.Equals(val)) return true;
            if (Current.Next == null || Current.Next.Value.CompareTo(val) > 0)
            {
                return RecSearch(Current.Down, val);
            }
            else
            {
                return RecSearch(Current.Next, val);
            }
        }

        
    }
}
