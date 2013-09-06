using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Q2: StringAuditQuestion
    {
        public override Pair[] auditString(String input)
        {
            Dictionary<char, Pair> pairCollections = new Dictionary<char, Pair>();
            
            char[] inputChar = input.ToCharArray();
            for (int i = 0; i < inputChar.Length; i++)
            {
                char c = inputChar[i];
                if (pairCollections.ContainsKey(c))
                {
                    pairCollections[c]._occurances++;
                }
                else
                {
                    Pair newPair = new Pair(c);
                    newPair._occurances = 1;
                    pairCollections.Add(c,newPair);
                }

            }

            PriorityQueue<int, Pair> heap = new PriorityQueue<int, Pair>();
            
            foreach (Pair p in pairCollections.Values)
            {
                heap.Enqueue(-p._occurances, p);
            }
            Pair[] result = new Pair[heap.Count];
            int counter = 0;
            while (heap.Count != 0)
            {
                result[counter] = heap.Dequeue().Value;
                counter++;
            }
            return result;
        }
    }
}
