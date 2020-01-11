using System;
using System.Drawing;

namespace MIS3013Demo
{
    class Program
    {
        const string exitString = "n";
        const int HEIGHT = 24*4;
        const int WIDTH = (int)(80 * 2.5) * 4;

        static void Main(string[] args)
        {
            int[][] pixelValues = null;
            while(true)
            {
                Console.WriteLine($"Enter a path to an image (or \"{exitString}\" to cancel):");
                var file = Console.ReadLine();
                if(file.ToLower() == exitString)
                {
                    break;
                }

                try
                {
                    pixelValues = ImageHelper.LoadPixelValuesFromPath(file, HEIGHT, WIDTH);
                    Console.WriteLine("Loaded image");

                    //Output to Console
                    for (var y = 0; y < pixelValues[0].Length; y++)
                    {
                        for (var x = 0; x < pixelValues.Length; x++)
                        {
                            Console.Write(GetCharacterForValue(pixelValues[x][y]));
                        }
                        Console.Write("\n");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine($"Could not find image at: {file}");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static char GetCharacterForValue(int value)
        {
            if(value < 25)
            {
                return ' ';
            }
            else if (value < 50)
            {
                return '.';
            }
            else if (value < 75)
            {
                return ':';
            }
            else if (value < 100)
            {
                return '-';
            }
            else if (value < 125)
            {
                return '=';
            }
            else if (value < 150)
            {
                return '+';
            }
            else if (value < 175)
            {
                return '*';
            }
            else if (value < 200)
            {
                return '#';
            }
            else if (value < 225)
            {
                return '%';
            }
            else
            {
                return '@';
            }
        }
    }
}
