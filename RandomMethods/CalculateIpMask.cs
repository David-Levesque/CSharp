using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMethods
{
    public class CalculateIpMask
    {
        //getsetmissing
        public Dictionary<string, int> map;

        public CalculateIpMask()
        {
            map = new Dictionary<string, int>
            {
                {"11111111",255},{"11111110", 254},{"11111100",252},
                {"11111000",248},{"11110000",240},{"1110000",224},
                {"11000000",192},{"10000000",128},{"00000000",0},
                {"00000001",1},{"00000011" ,3},{"00000111",7},
                { "00001111",15},{ "00011111",31},{ "00111111",63},
                { "01111111",127 }
            };
        }
        public void Display(string ip)
        {
            var FullIpThenMask = ip.Split('/');
            var mask = Int16.Parse(FullIpThenMask[1]);
            var ipArrayInt = IntMaker(FullIpThenMask[0].Split('.'));
            var maskArrayIntNetwork = IntMaker(MaskMaker(mask, false));
            var invertedMask = IntMaker(MaskMaker(mask, true));
            var networkAd = NetworkMaker(maskArrayIntNetwork, ipArrayInt);
            var broadCastAd = BroadcastMaker(invertedMask, ipArrayInt);

            Console.WriteLine($"Ip: {FullIpThenMask[0]}\n");
            Console.WriteLine($"Mask: {FullIpThenMask[1]}\n");
            Console.WriteLine($"Network Address: {networkAd}");
            Console.WriteLine($"Broadcast Address: {broadCastAd}");
        }

        //note i could have made broadcast and network maker one method but i thought this might be easier
        //to see whats going on this way
        private string BroadcastMaker(int[] invertedMask, int[] ipArrayInt)
        {
            var str = "";
            for (int i = 0; i < 4; i++)
            {
                var number = invertedMask[i] | ipArrayInt[i];
                str += number.ToString();
                if (i < 3)
                {
                    str += ".";
                }
            }
            return str;
        }

        private string NetworkMaker(int[] maskArrayInt, int[] ipArrayInt)
        {
            var str = "";
            for (int i = 0; i < 4; i++)
            {
                var number = maskArrayInt[i] & ipArrayInt[i];
                str += number.ToString();
                if (i < 3)
                {
                    str += ".";
                }
            }
            return str;
        }

        //i know my code insures my array is filled in the order i want but the que makes for a double redundency 
        private int[] IntMaker(string[] stringArray)
        {
            Queue<int> que = new Queue<int>();
            foreach (var item in stringArray)
            {
                if (map.ContainsKey(item))
                {
                    que.Enqueue(map[item]);
                }
                else
                {
                    que.Enqueue(Int16.Parse(item));
                }
            }
            return que.ToArray();
        }

        private string[] MaskMaker(int mask, bool inverted)
        {
            Queue<string> que = new Queue<string>();
            var str = new string[4];
            var counter = 0;
            for (int i = 0; i < 32; i++)
            {
                if (counter != mask)
                {
                    if (inverted)
                        que.Enqueue("0");
                    else
                        que.Enqueue("1");
                    counter += 1;
                }
                else
                {
                    if (inverted)
                        que.Enqueue("1");
                    else
                        que.Enqueue("0");
                }

            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    str[i] += que.Dequeue();
                }
            }
            return str;
        }



    }
}
