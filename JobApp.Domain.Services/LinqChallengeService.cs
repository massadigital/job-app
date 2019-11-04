using JobApp.Interfaces.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JobApp.Domain.Services
{
    public class LinqChallengeService : ILinqChallengeService
    {
        public int[][] CollatzRanking(int min, int max)
        {
            min = Math.Max(Math.Abs(min), 1);

            max = Math.Max(Math.Abs(max), min);

            var result = (new int[max - (min - 1)]).Select(e =>
            {
                var value = new List<int>() { max-- };
                while (value.Last() > 1)
                {
                    if (value.Last() % 2 == 0)
                    {
                        value.Add(value.Last() / 2);
                    }
                    else
                    {
                        value.Add((value.Last() * 3) + 1);
                    }
                }
                return value.ToArray();
            }).OrderByDescending(e => e.Length);

            return result.ToArray();
        }

        public void EvenOddSplit(int[] list, out int[] evens, out int[] odds)
        {
            evens = list.Where(e => e % 2 == 0).ToArray();
            odds = list.Where(e => e % 2 != 0).ToArray();
        }

        public int[] NotContainsFilter(int[] list, int[] filterList)
        {
            var result = list.Where(e => !filterList.Any(x => x == e));

            return result.ToArray();
        }
    }
}
