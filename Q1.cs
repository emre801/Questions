using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Q1
    {
        public static bool DecompressRLE(byte[] input, out byte[] output)
        {
            try
            {
                List<byte> decompress = new List<byte>();
                int counter = 0;
                while (true)
                {
                    byte a = input[counter];
                    int value = a & 0x80;
                    if ((a & 0x80) == 128)// repeat 
                    {
                        int numRepeats = a & 0x7f;
                        byte repeat = input[counter+1];
                        for (int i = 0; i < numRepeats; i++)
                        {
                            decompress.Add(repeat);
                        }
                        counter += 2;
                    }
                    else if ((a & 0x80) == 0) // non repeating
                    {
                        int nonRepeat = a & 0x7f;
                        //not really sure about repeating, if it's the immediate one before or if it repeats at all. So I did if it repeats at all
                        HashSet<byte> checkNonRepeat = new HashSet<byte>();
                        for (int i = counter + 1; i < counter + 1 + nonRepeat;i++ )
                        {
                            if (!checkNonRepeat.Contains(input[i]))
                            {
                                decompress.Add(input[i]);
                                checkNonRepeat.Add(input[i]);
                            }
                            else
                            {
                                output = null;
                                return false;
                            }
                        }
                        counter += nonRepeat+1;
                    }
                    if (input[counter] == 0x00)
                    {
                        output = decompress.ToArray();
                        return true;
                    }
                }
            }
            catch
            {
                output=null;
                return false;
            }

            
        }
    }
}
