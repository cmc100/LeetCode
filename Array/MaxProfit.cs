using Xunit;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>
    public class MaxProfitTests
    {
        [Theory]
        [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
        public void ShouldPass(int[] prices, int maxProfit)
        {
            var answer = MaxProfitAnswer.MaxProfit(prices);
            Assert.Equal(answer, maxProfit);
        }
    }

    /// <summary>
    /// Walks the list 1 time, considering the max profit from a sale at
    /// each moment. The lowest price previously observed is the critical
    /// factor here. So keep track of that, and also the maximum profit
    /// obtainable so far, so that we can return that number.
    /// </summary>
    public class MaxProfitAnswer
    {
        public static int MaxProfit(int[] prices)
        {
            var lowestPx = prices[0];
            var maxProfit = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                var opportunity = prices[i] - lowestPx;
                if(opportunity < 0)
                {
                    lowestPx = prices[i];
                    continue;
                }
                if(opportunity > maxProfit)
                {
                    maxProfit = opportunity;
                }
            }
            return maxProfit;
        }
    }
}
