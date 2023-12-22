using System.ComponentModel.DataAnnotations;

namespace MyProgram
{
    public struct Map
    {
        public Int32 Width;
        public Int32 Length;

        public override readonly string ToString()
        {
            return $"Length: {Length}, Width: {Width}";
        }
    };

    public class Position
    {
        // Attribute
        private static Map bombMap;
        private static readonly Int16 maxBombAround = 9;
        private readonly Int32 x;
        private readonly Int32 y;

        public Position(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }

        public static Map BombMap
        {
            get { return Position.bombMap; }
            set { Position.bombMap = value; }
        }

        private static void IncrementChar(ref char character)
        {
            // Check if character is an ASCII digit or '.'
            if ((character >= '0' && character <= '9') || character == '.')
            {
                // Convert the character to an integer
                int currentNumber = character == '.' ? 0 : (int)char.GetNumericValue(character);

                // Increment the number if it's less than the maxBombAround
                if (currentNumber < maxBombAround)
                {
                    currentNumber++;
                    character = (char)(currentNumber + '0');
                }
                // If the number is equal to or greater than maxBombAround, set it to '*'
                else
                {
                    character = '?';
                }
            }
            // If character is '*', do nothing
            else if (character == '*')
            {
                // Do nothing
            }
        }

        public void UpdateNorth(List<char[]> chars)
        {
            if (this.y - 1 >= 0)
            {
                IncrementChar(ref chars[this.y - 1][this.x]);
            }
        }
        public void UpdateNorth_West(List<char[]> chars)
        {
            if ((this.y - 1 >= 0) && (this.x - 1 >= 0))
            {
                IncrementChar(ref chars[this.y - 1][this.x - 1]);
            }
        }
        public void UpdateWest(List<char[]> chars)
        {
            if (this.x - 1 >= 0)
            {
                IncrementChar(ref chars[this.y][this.x - 1]);
            }
        }
        public void UpdateSouth_West(List<char[]> chars)
        {
            if ((this.y + 1 < Position.bombMap.Width) && (this.x - 1 >= 0))
            {
                IncrementChar(ref chars[this.y + 1][this.x - 1]);
            }
        }
        public void UpdateSouth(List<char[]> chars)
        {
            if (this.y + 1 < Position.bombMap.Width)
            {
                IncrementChar(ref chars[this.y + 1][this.x]);
            }
        }
        public void UpdateSouth_East(List<char[]> chars)
        {
            if ((this.y + 1 < Position.bombMap.Width) && (this.x + 1 < Position.bombMap.Length))
            {
                IncrementChar(ref chars[this.y + 1][this.x + 1]);
            }
        }
        public void UpdateEast(List<char[]> chars)
        {
            if (this.x + 1 < Position.bombMap.Length)
            {
                IncrementChar(ref chars[this.y][this.x + 1]);
            }
        }
        public void UpdateNorth_East(List<char[]> chars)
        {
            if ((this.y - 1 >= 0) && (this.x + 1 < Position.bombMap.Width))
            {
                IncrementChar(ref chars[this.y - 1][this.x + 1]);
            }
        }

        public override string ToString()
        {
            return $"X: {this.x}, Y: {this.y}";
        }
    }
}