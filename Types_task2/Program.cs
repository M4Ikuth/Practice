using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.Task.Two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            DrawDiamond(N);
        }
        static void DrawDiamond(int N)
        {

            int center = N / 2;
            for (int i = 0; i < N; i++)
            {
                StringBuilder emptyString = new StringBuilder(new string(' ', N));
                int offset;
                if (i <= center)
                {
                    offset = i;
                    emptyString[center - offset] = 'X';
                    emptyString[center + offset] = 'X';
                }
                if (i > center)
                {
                    offset = i - center;
                    emptyString[offset] = 'X';
                    emptyString[N - 1 - offset] = 'X';
                }
                Console.WriteLine(emptyString.ToString());
            }
        }
    }
}
