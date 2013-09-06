using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    public abstract class StringAuditQuestion
    {
        public class Pair
        {
            public char _char;
            public int _occurances;

            public Pair(char c)
            {
                _char = c;
                _occurances = 0;

            }
        }

            public abstract Pair[] auditString(String input);

            public void reportAudit(String input)
            {

                Pair[] pairs = auditString(input);
                for (int i = 0; i < pairs.Length; i++)
                {
                    Console.WriteLine(pairs[i]._char + "\t" + pairs[i]._occurances);
                }
            }
        }
    }

