using System;
using System.Collections.Generic;
using System.Threading;

namespace 战棋
{
    public class View
    {
        //public Position DefaultPosition;

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
            List<Character> EnemyList = Model.instance.EnemyList;
            List<Terrain> TerrainList = Model.instance.TerrainList;
            List<Building> BuildingList = Model.instance.BuildingList;
            List<Character> ProtagonistList = Model.instance.ProtagonistList;

            for (int i = 0; i < TerrainList.Count; i++)
            {
                if (EnemyList[i] == null && BuildingList[i] == null && ProtagonistList[i] == null)
                {
                    Console.SetCursorPosition(TerrainList[i].位置.x, TerrainList[i].位置.y);
                    Console.BackgroundColor = TerrainList[i].地形颜色;
                    Console.Write("　");
                }
                else if (EnemyList[i] == null && ProtagonistList[i] == null)
                {
                    Console.SetCursorPosition(BuildingList[i].位置.x, BuildingList[i].位置.y);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = TerrainList[i].地形颜色;
                    Console.Write(BuildingList[i].标志);
                }
                else if (BuildingList[i] == null && ProtagonistList[i] == null)
                {
                    Console.SetCursorPosition(EnemyList[i].位置.x, EnemyList[i].位置.y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = TerrainList[i].地形颜色;
                    Console.Write(EnemyList[i].名字);
                }
                else
                {
                    Console.SetCursorPosition(ProtagonistList[i].位置.x, ProtagonistList[i].位置.y);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = TerrainList[i].地形颜色;
                    Console.Write(ProtagonistList[i].名字);
                }
            }
        }

        public void ShowMonologue()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string 独白 = "    女皇被邪恶的巫师控制了，残害忠良，奴役百姓，英勇的勇士为了自己的国家，勇敢的站了出来，发誓要杀死巫师，拯救国家。";
            Console.SetCursorPosition(17*2, 1);
            for (int i = 0, j = 0; i < 独白.Length; i++, j++)
            {
                Console.Write(独白[i]);
                Thread.Sleep(100);
                if (j > 40)
                {
                    Console.SetCursorPosition(17*2, 2);
                    j = 0;
                }
            }
            Console.SetCursorPosition(1 * 2, 15);
        }

        public void ShowInformation()
        {
            int x = Control.instance.x;
            int y = Control.instance.y;
            int treeain = Model.instance.terrainInts[x - 1, y - 1];
            int up = Model.instance.UpInts[x - 1, y - 1];
            string treeainName;
            string treeainDescription;
            string upName;
            string upDescription;
            switch (treeain)
            {
                case 1:
                    treeainName = "地形：" + 地形.岩石.ToString();
                    treeainDescription = "地形信息：坚硬的岩石，上面可以建造城堡！";
                    break;
                case 2:
                    treeainName = "地形：" + 地形.河流.ToString();
                    treeainDescription = "地形信息：围绕城堡的河流，水流湍急，无法穿过";
                    break;
                case 3:
                    treeainName = "地形：" + 地形.平原.ToString();
                    treeainDescription = "地形信息：大平原，视野开阔，不适合搞袭击！";
                    break;
                case 4:
                    treeainName = "地形：" + 地形.草原.ToString();
                    treeainDescription = "地形信息：有及膝高的野草，小心伏地魔出没！";
                    break;
                case 5:
                    treeainName = "地形：" + 地形.沙漠.ToString();
                    treeainDescription = "地形信息：由于环境的破坏，沙漠延伸到了城市的边缘，小心蒙古死亡蠕虫！";
                    break;
                default:
                    treeainName = "";
                    treeainDescription = "";
                    break;
            }
            switch (up)
            {
                case 1:
                    upName = "步兵";
                    upDescription = "信息：拿刀的！";
                    break;
                case 2:
                    upName = "骑兵";
                    upDescription = "信息：骑着马拿刀的！";
                    break;
                case 3:
                    upName = "弓兵";
                    upDescription = "信息：拿弓箭的！";
                    break;
                case 4:
                    upName = "魔法师";
                    upDescription = "信息：感觉到生命的流逝了吗？";
                    break;
                case 5:
                    upName = "女皇";
                    upDescription = "信息：目前是一个傀儡，没有政权！";
                    break;
                case 6:
                    upName = "勇士";
                    upDescription = "信息：为了拯救国家独自前来的勇士！";
                    break;
                case 7:
                    upName = "牧师";
                    upDescription = "信息：移动泉水！";
                    break;
                case 8:
                    upName = "治疗之泉";
                    upDescription = "信息：站在这上面和按B键的效果一样！";
                    break;
                case 9:
                    upName = "城墙";
                    upDescription = "信息：保护城池的围墙，坚不可摧！";
                    break;
                default:
                    upName = "";
                    upDescription = "";
                    break;
            }
            Console.SetCursorPosition(17 * 2, 4);
            Console.Write(treeainName);
            Console.SetCursorPosition(17 * 2, 5);
            Console.Write(treeainDescription);
            Console.SetCursorPosition(17 * 2, 7);
            Console.Write(upName);
            Console.SetCursorPosition(17 * 2, 8);
            Console.Write(upDescription);
        }

        public void DisplayCursor()
        {
            //ConsoleColor terrainColor;
            //ConsoleColor fontColor;
            //string upName;
            //int Terrain = Model.instance.terrainInts[DefaultPosition.y - 1, DefaultPosition.x - 1];    //获取到指定地点的颜色代码
            //int item = Model.instance.UpInts[DefaultPosition.y - 1, DefaultPosition.x - 1];            //获取该地形上的信息 建筑是9，敌人是5，主角是1

            //switch (Terrain)
            //{
            //    case 1:
            //        terrainColor = ConsoleColor.Gray;
            //        break;
            //    case 2:
            //        terrainColor = ConsoleColor.Cyan;
            //        break;
            //    case 3:
            //        terrainColor = ConsoleColor.DarkCyan;
            //        break;
            //    case 4:
            //        terrainColor = ConsoleColor.DarkGreen;
            //        break;
            //    case 5:
            //        terrainColor = ConsoleColor.DarkYellow;
            //        break;
            //    default:
            //        terrainColor = ConsoleColor.Black;
            //        break;
            //}

            //switch (item)
            //{
            //    case 1:
            //        upName = "步";
            //        fontColor = ConsoleColor.Red;
            //        break;
            //    case 2:
            //        upName = "骑";
            //        fontColor = ConsoleColor.Red;
            //        break;
            //    case 3:
            //        upName = "弓";
            //        fontColor = ConsoleColor.Red;
            //        break;
            //    case 4:
            //        upName = "魔";
            //        fontColor = ConsoleColor.Red;
            //        break;
            //    case 5:
            //        upName = "皇";
            //        fontColor = ConsoleColor.Red;
            //        break;
            //    case 6:
            //        upName = "勇";
            //        fontColor = ConsoleColor.DarkMagenta;
            //        break;
            //    case 7:
            //        upName = "牧";
            //        fontColor = ConsoleColor.DarkMagenta;
            //        break;
            //    case 8:
            //        upName = "◇";
            //        fontColor = ConsoleColor.Black;
            //        break;
            //    case 9:
            //        upName = "█";
            //        fontColor = ConsoleColor.Black;
            //        break;
            //    default:
            //        upName = "";
            //        fontColor = ConsoleColor.White;
            //        break;
            //}

            //Console.SetCursorPosition(DefaultPosition.x, DefaultPosition.y);

            //Console.BackgroundColor = terrainColor;
            //Console.ForegroundColor = fontColor;
            //Console.Write(upName);
        }
    }
}