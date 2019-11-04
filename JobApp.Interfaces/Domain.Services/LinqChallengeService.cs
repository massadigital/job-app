using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Interfaces.Domain.Services
{
    public interface ILinqChallengeService
    {
        int[][] CollatzRanking(int min, int max);
        void EvenOddSplit(int[] list, out int[] evens, out int[] odds);
        int[] NotContainsFilter(int[] list, int[] filterList);
    }
}
