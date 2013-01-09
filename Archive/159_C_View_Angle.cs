// http://codeforces.ru/contest/257/problem/C
﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace CF {
    class Program {


        static void Main(string[] args) {

#if DEBUG
            TextReader reader = new StreamReader("../../input.txt");
            TextWriter writer = Console.Out;
#else
			TextReader reader = Console.In;
            TextWriter writer = Console.Out;
#endif

            int n = int.Parse(reader.ReadLine());

            var list = new List<double>();
            var antiList = new List<double>();

            for (int i = 0; i < n; i++) {
                var vals = reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int x = vals[0];
                int y = vals[1];
                list.Add(180 * Math.Atan2(x, y) / Math.PI);
            }
            var angle = list.OrderBy(s => s).ToArray();
            
            double best = 1e9;
		for (int i = 1; i < n; i++) {
			best = Math.Min (best, 360.0 - (angle[i] - angle[i - 1]));
		}
		best = Math.Min (best, 360.0 - (angle[0] + 360.0 - angle[n - 1]));
		Console.WriteLine("{0}".Replace(",","."), best);


#if DEBUG
            Console.ReadKey();
#endif
        }

    }
}
