using System;

namespace 战棋
{
    class Program
    {
        public Program()
        {
            
        }

        static void Main(string[] args)
        {
            LevelManager levelManager = new LevelManager();
            View map = new View();
            map.LoadScenes();
            Console.Read();
        }
    }
}
