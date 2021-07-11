using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace LeetCode
{
    /// <summary>
    ///     https://leetcode.com/problems/two-sum/
    /// </summary>
    public class TwoSumTests
    {
        [Theory]       
        [InlineData(new[] { 2, 7, 11, 15 },     9,      new[] { 0, 1 })]
        [InlineData(new[] { 3,2,4 },            6,      new[] { 1, 2 })]
        [InlineData(new[] { 3,3 },              6,      new[] { 0, 1 })]
        [InlineData(new[] { 2, 8, 3, 45, 4 },   49,     new[] { 3, 4 })]
        public void ShouldPass(int[] nums, int target, int[] result)
        {
            var answer = TwoSumAnswer.TwoSum(nums, target);

            Assert.True(answer.OrderBy(i => i).SequenceEqual(result));
        }
    }

    /// <summary>
    /// My O(N) solution walks the list once, adding each to a dict (as the KEY).
    /// For each item, we check the dict for the matching 'needed' item
    /// ...if it's there, just grab the index which was stored as the dict value.
    /// </summary>
    public class TwoSumAnswer
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var lookup = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var needed = target - nums[i];

                if (lookup.TryGetValue(needed, out int index))
                    return new[] { index, i };

                lookup.Add(nums[i], i);
            }
            return Array.Empty<int>();
        }
    }
}
