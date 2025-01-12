namespace SkipListTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1,2,3,4,6,7,7)]
        [InlineData(1,1,1,1,1,1)]
        public void BasicMathTest(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.True(arr[i] < 10);
            }
            
        }
    }
}