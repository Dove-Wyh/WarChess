using System;
using System.Collections.Generic;
using System.Threading;

namespace 战棋
{
    public class View
    {
        public static View instance;

        public View()
        {
            instance = this;
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

            for (int i = 0; i < 225; i++)
            {
                if (EnemyList[i] == null && BuildingList[i] == null && ProtagonistList[i] == null)//如果啥都没有
                {
                    Console.SetCursorPosition(TerrainList[i].位置.x, TerrainList[i].位置.y);
                    Console.BackgroundColor = TerrainList[i].地形颜色;
                    Console.Write("　");
                }
                else if (BuildingList[i] != null)//如果建筑不为空
                {
                    Console.SetCursorPosition(BuildingList[i].位置.x, BuildingList[i].位置.y);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = TerrainList[i].地形颜色;
                    Console.Write(BuildingList[i].标志);
                }
                else if (EnemyList[i] != null)//如果敌人不为空
                {
                    Console.SetCursorPosition(EnemyList[i].位置.x, EnemyList[i].位置.y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = TerrainList[i].地形颜色;
                    Console.Write(EnemyList[i].名字);
                }
                else//如果英雄不为空
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
                //Thread.Sleep(100);
                Thread.Sleep(10);
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
            Character upCharacter;
            upCharacter = Model.instance.UpList[x * 15 + y];
            int treeain = Model.instance.terrainInts[y, x];
            int up = Model.instance.UpInts[y, x];
            string treeainName;
            string treeainDescription;
            string upName;
            string upDescription;
            string upHP = "";
            string upMP = "";
            string upATK = "";
            string upDEF = "";
            string blank = "                                                                                    ";

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
                    upName = "弓兵";
                    upDescription = "信息：拿弓箭的！";
                    break;
                case 3:
                    upName = "骑兵";
                    upDescription = "信息：骑着马拿刀的！";
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

            if (upCharacter != null)
            {
                upHP = "当前生命值：" + upCharacter.当前生命值.ToString();
                upMP = "当前魔法值：" + upCharacter.当前魔法值.ToString();
                upATK = "攻击力：" + upCharacter.攻击力.ToString();
                upDEF = "防御力：" + upCharacter.防御力.ToString();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(17 * 2, 4);
            Console.Write(blank);
            Console.SetCursorPosition(17 * 2, 5);
            Console.Write(blank);
            Console.SetCursorPosition(17 * 2, 7);
            Console.Write(blank);
            Console.SetCursorPosition(17 * 2, 8);
            Console.Write(blank);
            Console.SetCursorPosition(17 * 2, 9);
            Console.Write(blank);
            Console.SetCursorPosition(17 * 2, 10);
            Console.Write(blank);
            Console.SetCursorPosition(17 * 2, 11);
            Console.Write(blank);
            Console.SetCursorPosition(17 * 2, 12);
            Console.Write(blank);

            Console.SetCursorPosition(17 * 2, 4);
            Console.Write(treeainName);
            Console.SetCursorPosition(17 * 2, 5);
            Console.Write(treeainDescription);
            Console.SetCursorPosition(17 * 2, 7);
            Console.Write(upName);
            Console.SetCursorPosition(17 * 2, 8);
            Console.Write(upDescription);
            Console.SetCursorPosition(17 * 2, 9);
            Console.Write(upHP);
            Console.SetCursorPosition(17 * 2, 10);
            Console.Write(upMP);
            Console.SetCursorPosition(17 * 2, 11);
            Console.Write(upATK);
            Console.SetCursorPosition(17 * 2, 12);
            Console.Write(upDEF);
        }
        
    }
}