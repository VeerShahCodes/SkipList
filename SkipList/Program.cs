namespace SkipList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> skipList = new SkipList<int>();
            skipList.Add(6);
            skipList.Add(3);
            Console.WriteLine(skipList.Search(3));
            //skipList.Delete(3);
            Console.WriteLine(skipList.Search(3));
            skipList.Add(3);
            skipList.Add(9);
            //skipList.Add(10);
            //skipList.Add(2);
            Console.WriteLine(skipList.Search(3));
            Node<int>[] arr = new Node<int>[3];
            //skipList.CopyTo(arr, 0);
          //  for(int i = 0; i < arr.Length; i++)
            //{
              ///  Console.WriteLine(arr[i].Value);
           // }
           // foreach(Node<int> i in skipList)
           // {
                //Console.WriteLine(i.Value);
           // }
        }
       
    }
}
