using System.Collections;
using System.Data;
using System.Diagnostics;

namespace MyProgram
{
    public class MyProgram
    {
        private static void Print2DArray(List<char[]> array2D)
        {
            Console.WriteLine("Array: ");

            Int32 col_size = array2D.Count;
            for (int col_index = 0; col_index < col_size; col_index++)
            {
                char[] chars = array2D[col_index];
                for (int row_index = 0; row_index < chars.Length; row_index++)
                {
                    Console.Write(chars[row_index] + "\t");
                }

                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            /*
                Input:
                *...
                ....
                .*..
                ....
            */

            /*
                Output:
                *100
                2210
                1*10
                1110
            */
            Map map;
            List<char[]> charArray2D = new();

            try
            {
                // Make A StreamReader to read The File
                StreamReader sr = new("maze.txt");

                // Read Every Line And Put into the array2D
                string? line;
                int iter = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    // Appen to the Array
                    charArray2D.Add(line.ToCharArray());
                    iter++;
                }
                // Append The Map Width
                map.Length = charArray2D[0].Length;
                map.Width = iter;

                // CLose The File
                sr.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return;
            }

            // Add The Map
            Position.BombMap = map;

            // Print The Map
            Print2DArray(charArray2D);

            // Loop the Array
            // Find All the * Position
            /*
                O(M * N) Algorithm: 
                    + M is the col_size
                    + N is the row_size
            */

            Int32 col_size = charArray2D.Count;
            for (int col_index = 0; col_index < col_size; col_index++)
            {
                char[] chars = charArray2D[col_index];
                for (int row_index = 0; row_index < chars.Length; row_index++)
                {
                    // Check If that is the * -> Create A Object
                    if (chars[row_index] == '*')
                    {
                        Position star = new Position(x: row_index, y: col_index);

                        // Update the Number Next to The Bomb 
                        star.UpdateNorth(charArray2D);
                        star.UpdateNorth_West(charArray2D);
                        star.UpdateWest(charArray2D);
                        star.UpdateSouth_West(charArray2D);
                        star.UpdateSouth(charArray2D);
                        star.UpdateSouth_East(charArray2D);
                        star.UpdateEast(charArray2D);
                        star.UpdateNorth_East(charArray2D);
                    }

                    // Check If That is the . -> Change to 0
                    if (chars[row_index] == '.')
                    {
                        chars[row_index] = '0';
                    }
                }
            }

            // Print The Map
            Print2DArray(charArray2D);
        }
    }
}