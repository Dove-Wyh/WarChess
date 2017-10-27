using System;
using System.Threading;

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
            Model model = new Model();
            Control control = new Control();
            View map = new View();
            //加载游戏
            map.LoadScenes();

            map.ShowMonologue();
            
            while (true)
            {
                control.MoveCursor();
                
            }

            //Console.Read();
        }
    }
}
