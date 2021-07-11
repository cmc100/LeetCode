using System;
using System.Collections.Generic;
using Xunit;
namespace LeetCode.Array
{
    public class ContainsDuplicateTests
    {
        [Theory]
        [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, false)]
        [InlineData(new[] { 7, 3, 4, 3, 1 }, true)]
        public void ShouldPass(int[] nums, bool dupe)
        {
            var answer = ContainsDuplicateAnswer.ContainsDuplicate(nums);
            Assert.Equal(answer, dupe);
        }
    }

    public class ContainsDuplicateAnswer
    {
        public static bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                    return true;

                set.Add(nums[i]);
            }
            return false;
        }
    }
}
