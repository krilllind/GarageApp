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
            try
            {
                if (input.Trim().Length <= 0)
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
                        if (caseSensitive)
                            return input;
                        else
                            return input.ToLower();
                    case "int":
                        return int.Parse(input);
                    case "char":
                        if (caseSensitive)
                            return input[0];
                        else
                            return input.ToLower()[0];
                    default:
                        return input.ToLower();
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
