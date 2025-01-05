namespace SkipList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> skipList = new SkipList<int>(1);
            skipList.Add(6);
            skipList.Add(3);
            Console.WriteLine(skipList.Search(3));
            skipList.Delete(3);
            Console.WriteLine(skipList.Search(3));
            
        }
       
    }
}
