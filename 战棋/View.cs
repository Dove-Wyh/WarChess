using System;
using System.Collections.Generic;

namespace 战棋
{
    public class View
    {
        public View()
        {
            Console.WriteLine("┌───────────────┐");//中间有15个特殊符号 等于30个空格，但是在IDE中显示的和15个空格的长度相等
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│                              │");
            Console.WriteLine("└───────────────┘");
        }

        public void LoadScenes()
        {
            LevelManager.instance.level.levelList[LevelManager.instance.presentLevel]();
            List<Character> EnemyList = LevelManager.instance.level.EnemyList;
            List<Terrain> TerrainList = LevelManager.instance.level.TerrainList;
            foreach (Terrain terrain in TerrainList)
            {
                Console.SetCursorPosition(terrain.位置.x, terrain.位置.y);
                Console.BackgroundColor = terrain.地形颜色;
                Console.Write("  ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (Character enemy in EnemyList)
            {
                Console.SetCursorPosition(enemy.位置.x, enemy.位置.y);
                Console.Write(enemy.名字);
            }
            
            Console.SetCursorPosition(50, 0);
        }
    }
}