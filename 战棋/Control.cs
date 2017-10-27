using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace 战棋
{
    public class Control
    {
        public static Control instance;
        public int x;
        public int y;
        private ConsoleKeyInfo consoleKeyInfo;
        private bool isMoving = false;
        private bool isAttack = false;
        private List<可以的格子> 可以走的格子集合;
        private List<可以的格子> 可以攻击的格子集合;
        private 勇士 勇士;

        public Position position;//初始化时候的光标坐标

        public Control()
        {
            x = 0;
            y = 14;
            instance = this;
            //position = new Position(x * 2 + 1, y);
        }

        public void MoveCursor()
        {
            if (Console.KeyAvailable)
            {
                consoleKeyInfo = Console.ReadKey(true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (x - 1 >= 0)
                        {
                            x--;
                            View.instance.ShowInformation();
                            Console.SetCursorPosition((x + 1) * 2, y + 1);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x + 1 <= 14)
                        {
                            x++;
                            View.instance.ShowInformation();
                            Console.SetCursorPosition((x + 1) * 2, y + 1);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (y - 1 >= 0)
                        {
                            y--;
                            View.instance.ShowInformation();
                            Console.SetCursorPosition((x + 1) * 2, y + 1);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y + 1 <= 14)
                        {
                            y++;
                            View.instance.ShowInformation();
                            Console.SetCursorPosition((x + 1) * 2, y + 1);
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        if (Model.instance.UpInts[y, x] == 6 && isMoving == false)
                        {
                            isMoving = true;
                            ShowMoveArea();
                        }
                        else if (isMoving)
                        {
                            Move();
                        }
                        else if (isAttack)
                        {
                            ATK();
                        }
                        break;
                }
            }
        }

        public void ShowMoveArea()
        {
            可以走的格子集合 = new List<可以的格子>();
            int 体力 = Model.instance.ProtagonistList[x * 15 + y].体力;

            //计算可以走的格子的坐标并存储起来
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (Math.Abs(i - y) + Math.Abs(j - x) <= 体力)
                    {
                        可以走的格子集合.Add(new 可以的格子(i, j, Model.instance.UpInts[i, j]));
                    }
                }
            }
            //高亮可以走的格子
            foreach (var 可以走的格子 in 可以走的格子集合)
            {
                int type = 可以走的格子.type;
                string upName;
                ConsoleColor color;
                switch (type)
                {
                    case 1:
                        upName = "步";
                        color = ConsoleColor.Red;
                        break;
                    case 2:
                        upName = "弓";
                        color = ConsoleColor.Red;
                        break;
                    case 3:
                        upName = "骑";
                        color = ConsoleColor.Red;
                        break;
                    case 4:
                        upName = "魔";
                        color = ConsoleColor.Red;
                        break;
                    case 5:
                        upName = "女";
                        color = ConsoleColor.Red;
                        break;
                    case 6:
                        upName = "勇";
                        color = ConsoleColor.DarkMagenta;
                        break;
                    case 7:
                        upName = "牧";
                        color = ConsoleColor.DarkMagenta;
                        break;
                    case 8:
                        upName = "◇";
                        color = ConsoleColor.Black;
                        break;
                    case 9:
                        upName = "█";
                        color = ConsoleColor.Black;
                        break;
                    default:
                        upName = "　";
                        color = ConsoleColor.White;
                        break;
                }
                Console.SetCursorPosition((可以走的格子.y + 1) * 2, 可以走的格子.x + 1);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = color;
                Console.Write(upName);
            }
            Console.SetCursorPosition((x + 1) * 2, y + 1);
            Model.instance.ProtagonistInts[y, x] = 0;
            勇士 = Model.instance.ProtagonistList[x * 15 + y] as 勇士;

            //不能这么写
            //Model.instance.ProtagonistList.RemoveAt((x - 1) * 15 + (y - 1));

            Model.instance.ProtagonistList[x * 15 + y] = null;
            Model.instance.UpInts[y, x] = 0;
            Model.instance.UpList[x * 15 + y] = null;
            
        }

        public void ShowATKArea()
        {
            可以攻击的格子集合 = new List<可以的格子>();
            int 普通攻击范围 = Model.instance.ProtagonistList[x * 15 + y].普通攻击范围;

            //计算可以攻击的格子的坐标并存储起来
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (Math.Abs(i - y) + Math.Abs(j - x) <= 普通攻击范围)
                    {
                        可以攻击的格子集合.Add(new 可以的格子(i, j, Model.instance.UpInts[i, j]));
                    }
                }
            }

            //查看攻击范围内有没有敌人
            bool haveEnemy = false;
            foreach (var 可以攻击的格子 in 可以攻击的格子集合)
            {
                if (可以攻击的格子.type == 1 || 可以攻击的格子.type == 2 || 可以攻击的格子.type == 3 || 可以攻击的格子.type == 4 || 可以攻击的格子.type == 5)
                {
                    haveEnemy = true;
                    isAttack = false;
                }
            }

            //高亮可以攻击的格子
            if (haveEnemy)
            {
                foreach (var 可以攻击的格子 in 可以攻击的格子集合)
                {
                    int type = 可以攻击的格子.type;
                    string upName;
                    ConsoleColor color;
                    switch (type)
                    {
                        case 1:
                            upName = "步";
                            color = ConsoleColor.Red;
                            break;
                        case 2:
                            upName = "弓";
                            color = ConsoleColor.Red;
                            break;
                        case 3:
                            upName = "骑";
                            color = ConsoleColor.Red;
                            break;
                        case 4:
                            upName = "魔";
                            color = ConsoleColor.Red;
                            break;
                        case 5:
                            upName = "女";
                            color = ConsoleColor.Red;
                            break;
                        case 6:
                            upName = "勇";
                            color = ConsoleColor.DarkMagenta;
                            break;
                        case 7:
                            upName = "牧";
                            color = ConsoleColor.DarkMagenta;
                            break;
                        case 8:
                            upName = "◇";
                            color = ConsoleColor.Black;
                            break;
                        case 9:
                            upName = "█";
                            color = ConsoleColor.Black;
                            break;
                        default:
                            upName = "　";
                            color = ConsoleColor.White;
                            break;
                    }
                    Console.SetCursorPosition((可以攻击的格子.y + 1) * 2, 可以攻击的格子.x + 1);
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = color;
                    Console.Write(upName);
                }
            }
            else
            {
                可以攻击的格子集合 = null;
            }
            Console.SetCursorPosition((x + 1) * 2, y + 1);
        }

        public void Move()
        {
            foreach (var 可以走的格子 in 可以走的格子集合)
            {
                if (y == 可以走的格子.x && x == 可以走的格子.y)
                {
                    Model.instance.ProtagonistInts[y, x] = 6;
                    勇士.位置 = new Position((x + 1) * 2, y + 1);
                    Model.instance.ProtagonistList[x * 15 + y] = 勇士;
                    Model.instance.UpInts[y, x] = 6;
                    Model.instance.UpList[x * 15 + y] = 勇士;
                    View.instance.LoadScenes();
                    可以走的格子集合 = null;
                    isAttack = true;
                    ShowATKArea();
                    isMoving = false;
                }
            }
        }

        public void ATK()
        {
            //先判断光标是否在攻击范围内
            foreach (var 可以攻击的格子 in 可以攻击的格子集合)
            {
                if (y == 可以攻击的格子.x && x == 可以攻击的格子.y)
                {
                    //再判断是否有敌人
                    if (可以攻击的格子.type == 1 || 可以攻击的格子.type == 2 || 可以攻击的格子.type == 3 || 可以攻击的格子.type == 4 || 可以攻击的格子.type == 5)
                    {
                        Character enmey = Model.instance.EnemyList[x * 15 + y];
                        enmey.当前生命值 -= 勇士.攻击力 - enmey.防御力;
                        勇士.当前生命值 -= enmey.攻击力 - 勇士.防御力;
                    }
                }
            }
            
        }
    }

    public class 可以的格子
    {
        public int x;
        public int y;
        public int type;

        public 可以的格子(int x, int y, int type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }
    }
}