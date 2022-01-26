using System;
using System.IO;

namespace SimplestMathProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES
            int x;
            int startValue;
            bool save;

            // INTRODUCTION
            Console.WriteLine("This machine will calculate the \"simplest math problem\" with the entered value.");
            Console.WriteLine("-----------------------------------------------------------------------------------");


            // Checks if  is valid
            while (true)
            {
                try
                {
                    Console.Write("Enter a value to use: ");
                    startValue = x = Convert.ToInt32(Console.ReadLine());

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter an integer.");
                }
            }

            // Checks if user wants to save the caculated values
            // Sets the bool accordingly
            while (true)
            {
                try
                {
                    Console.Write("Would you like to to save the calculated values to a .csv-file? [y|n]  ");
                    string decision = Console.ReadLine();
                    switch (decision)
                    {
                        case "y":
                            save = true;
                            break;
                        case "n":
                            save = false;
                            break;
                        default:
                            throw new Exception();
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Unrecognised input.");
                }
            }

            // FUNCTION CALL
            Formula(startValue, x, save);

            Console.ReadKey();
        }


        // x * 3 + 1 until it hits a number dividable by 2 again
        public static void Formula(int startValue, int x, bool save)
        {
            string path = "";
            if (save)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter the file name (including extension):");
                        path = @"..\..\" + Console.ReadLine();
                        if (File.Exists(path))
                        {
                            throw new Exception();
                        }
                        File.AppendAllText(path, startValue.ToString() + Environment.NewLine);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("A file with this name already exists. Pick another one.");
                    }
                }
            }

            Console.WriteLine(x);

            bool run = true;
            while (run)
            {
                while (x % 2 == 0)
                {
                    x = x / 2;
                    Console.WriteLine(x);

                    if (save)
                    {
                        File.AppendAllText(path, x.ToString() + Environment.NewLine);
                    }

                    if (x == 1)
                    {
                        run = false;
                    }
                }

                if (run == true)
                {
                    while (x % 2 != 0)
                    {
                        x = x * 3 + 1;
                        Console.WriteLine(x);

                        if (save)
                        {
                            File.AppendAllText(path, x.ToString() + Environment.NewLine);
                        }
                    }
                }
            }

            Console.WriteLine("Calculated all the values.");
            Console.WriteLine("After this there is an endless loop.");
        }
    }
}
