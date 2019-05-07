using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.BAL
{
    public class Class1
    {
        public int add(int a,int b)
        {
            return a + b;
        }
        public int add(int a, int b, int c=10)
        {
            return a + b + c;
        }

    }
}
