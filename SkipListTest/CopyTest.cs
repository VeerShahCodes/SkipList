using SkipList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipListTest
{
    public class CopyTest
    {
        [Theory]
        [InlineData(1, 2, 3, 4, 5, 6, 7)]
        [InlineData(1, 1, 1, 1, 1, 1)]
        public void CopyToTest(params int[] arr)
        {
            SkipList<int> list = new SkipList<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
            Node<int>[] array = new Node<int>[list.Count];
            list.CopyTo(array, 0);
            int j = 0;
            foreach (SkipList.Node<int> item in list)
            {
                Assert.True(item.Value == array[j].Value);
                j++;
            }
        }
    }
}
