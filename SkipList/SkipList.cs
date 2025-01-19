using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{

    public class SkipList<T> : ICollection where T : IComparable<T>
    {
        Random random = new Random(100);
        Node<T> Head;
        int count;
        public int Count => count;

        public bool IsSynchronized => true;

        public object SyncRoot => Head;


        public SkipList()
        {
            Head = new Node<T>(default(T));
            count = 0;
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
                Head = new Node<T>(Head.Value, Head);
            }


            RecAdd(Head, val, height);
            count++;
        }

        Node<T> RecAdd(Node<T> Current, T val, int height)
        {
            //Base case
            if (Current == null) return null;

            //Down            
            if (Current.Next == null || Current.Next.Value.CompareTo(val) > 0)
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

        public bool Delete(T val)
        {
            return Delete(Head, val);
        }

        bool Delete(Node<T> Current, T val)
        {
            //basecase
            if (Current == null) return false;

            if (Current.Next == null || Current.Next.Value.CompareTo(val) >= 0)
            {
                if (Current.Next.Value.CompareTo(val) == 0)
                {
                    count--;
                    Current.Next = Current.Next.Next;
                    return Delete(Current.Down, val) || true;
                }
                return Delete(Current.Down, val);
            }
            else
            {

                return Delete(Current.Next, val);
            }
        }


        //

        public void CopyTo(Array array, int index)
        {
            List<Node<T>> list= new List<Node<T>>();
            //Go Down
            Node<T> Current = Head;
            while(Current.Down != null)
            {
                Current = Current.Down;
            }
            Current = Current.Next;
            // Go Right until index
            for(int i = 0; i < index; i++)
            {
                Current = Current.Next;
            }
            // Go Right until null add for each value
            for (Node<T> i=Current;i!=null;i=i.Next)
            {
                list.Add(Current);
            }           
            array = list.ToArray();
              
        }

        public IEnumerator GetEnumerator()
        {
            //Go Down
            Node<T> Current = Head;
            while (Current.Down != null)
            {
                Current = Current.Down;
            }
            Current = Current.Next;
            //goes right
            for (Node<T> i = Current; i != null; i = i.Next)
            {
                yield return i;
            }
        }
    }
}
