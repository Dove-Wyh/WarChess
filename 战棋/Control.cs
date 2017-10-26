using System;

namespace 战棋
{
    public class Control
    {
        public static Control instance;
        public int x = 1;
        public int y = 15;

        public Position position;

        public Control()
        {
            instance = this;
            position = new Position(x * 2 + 1, y);
        }

        public void MoveCursor()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (x - 1 >= 1)
                        {
                            x--;
                            Console.SetCursorPosition(x * 2, y);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x + 1 <= 15)
                        {
                            x++;
                            Console.SetCursorPosition(x * 2, y);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (y - 1 >= 1)
                        {
                            y--;
                            Console.SetCursorPosition(x * 2, y);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y + 1 <= 15)
                        {
                            y++;
                            Console.SetCursorPosition(x * 2, y);
                        }
                        break;
                }
            }
        }
    }
}