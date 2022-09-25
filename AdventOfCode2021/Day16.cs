using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day16
    {
        //TODO
        // example 2 and 3 
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day16/Input.txt";
        private static int total = 0;
        public static void One()
        {
            Dictionary<char, string> dic = new Dictionary<char, string>
            {
    { '0', "0000" },
    { '1', "0001" },
    { '2', "0010" },
    { '3', "0011" },
    { '4', "0100" },
    { '5', "0101" },
    { '6', "0110" },
    { '7', "0111" },
    { '8', "1000" },
    { '9', "1001" },
    { 'A', "1010" },
    { 'B', "1011" },
    { 'C', "1100" },
    { 'D', "1101" },
    { 'E', "1110" },
    { 'F', "1111" }
             };
            var input = File.ReadAllLines(path)[0].ToCharArray();
            var binary = string.Join("",input.Select(x => Convert.ToString(Convert.ToInt64(x.ToString(), 16), 2).PadLeft(4,'0')));
            Packet(binary);
            Console.WriteLine(total);
 
        }
    
        static void Packet(string binary, int limit = int.MaxValue) {
            var version = Convert.ToInt32(binary[..3],2);
            var id = Convert.ToInt32(binary.Substring(3, 3), 2);
            total += version;
            var rest = binary[6..];
            if (id == 4) { 
                Literal(rest, limit);       
                }
            else
                Operator(rest);
            
        }
        
        static void Operator(string rest)
        {
            var lengthTypeID = rest[0];
            var amount = Convert.ToInt32(rest.Substring(1, 11), 2);

            if (lengthTypeID == '0' && rest.Contains('1'))
            {
                int subPacketsLength = Convert.ToInt32(rest.Substring(1, 15), 2);
                Packet(rest.Substring(16, subPacketsLength));
            }
            else if(lengthTypeID == '1')
                    Packet(rest[(1 + 11)..], amount);                                                                                     
        }
        
        static string Literal(string rest, int limit = int.MaxValue)
        {
            var literal = "";
            for (int i = 0; i < rest.Length; i += 5)
            {
                literal += rest.Substring(i + 1, 4);
                if (rest[i] == '0')
                {
                    if (rest[(i+5)..].Length > 10 && limit > 1)
                        Packet(rest[(i + 5)..]);
                    break;
                }                    
            }       
            return literal;
        }      
    }
}

