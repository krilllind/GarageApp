using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    public static class BaseLogic
    {
        public static dynamic CheckInput(string input, string type = "string", bool caseSensitive = false, List<string> acceptable = null)
        {
            if (!caseSensitive)
                input = input.ToLower();

            input.Trim();

            try
            {
                if (input.Length <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter in right information.");
                    return CheckInput(Console.ReadLine(), type, caseSensitive, acceptable);
                }
                else if (acceptable != null && !acceptable.Contains(input))
                {
                    Console.WriteLine("Invalid input! Please enter in right information.");
                    return CheckInput(Console.ReadLine(), type, caseSensitive, acceptable);
                }

                switch (type.ToLower())
                {
                    case "string":
                        return input;
                    case "int":
                        return int.Parse(input);
                    case "char":
                        return input[0];
                    default:
                        return input;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid format, please enter in right information!\n");
                return CheckInput(Console.ReadLine(), type, caseSensitive, acceptable);
            }
        }
    }
}
