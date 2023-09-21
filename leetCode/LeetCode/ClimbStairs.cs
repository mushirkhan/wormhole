using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ClimbStairs
    {
        public int ClimbStair(int n)
        {
            int one = 1;
            int two = 1;

            for (int i = 0; i < n - 1; i++)
            {
                int temp = one;
                one = one + two;
                two = temp;
            }

            return one;
        }
    }
}
