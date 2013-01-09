// http://codeforces.ru/contest/257/problem/A
﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
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

            var vals = reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = vals[0];
            var m = vals[1];
            var k = vals[2];

            var forks = reader.ReadLine().Split(' ').Select(int.Parse).Where(s => s > 1).OrderByDescending(s => s).ToArray();

            int forksCount = 0;
            for (int i = 0; i < forks.Length && k > 0; i++) {
                if (m <= 0) break;
                if (m <= k) { m = 0; break; }
                k += forks[i] - 1;
                forksCount++;
            }

            m -= k;

            if (m > 0) {
                Console.WriteLine("-1");
                return;
            }

            Console.WriteLine(forksCount);


#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
