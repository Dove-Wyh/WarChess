using System;
using System.Collections.Generic;

namespace 战棋
{
    public class Level
    {
        public Action level;
        public List<Character> EnemyList;
        public List<Terrain> TerrainList;
        public List<Building> BuildingList;
        public List<Character> ProtagonistList;
        public int[,] buildingInts;
        public int[,] ProtagonistInts;
        public int[,] enemyInts;
        public int[,] terrainInts;

        public List<Action> levelList = new List<Action>();

        public Level()
        {
            levelList.Add(Level1);
        }

        public void Level1()
        {
            buildingInts = new int[15,15]
            {
                { 0,0,0,0,9,0,9,0,9,0,9,0,0,0,0},
                { 0,0,0,0,9,0,9,0,9,0,9,0,0,0,0},
                { 0,0,0,0,9,0,0,0,0,0,9,0,0,0,0},
                { 0,0,0,0,9,0,0,0,0,0,9,0,0,0,0},
                { 0,0,0,0,9,9,9,0,9,9,9,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
            BuildingList = new List<Building>();
            for (int i = 0; i < buildingInts.GetLength(0); i++)
            {
                for (int j = 0; j < buildingInts.GetLength(1); j++)
                {
                    switch (buildingInts[j, i])
                    {
                        case 0:
                            BuildingList.Add(null);
                            break;
                        case 9:
                            BuildingList.Add(new 城墙(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 8:
                            BuildingList.Add(new 医院(new Position((i + 1) * 2, j + 1)));
                            break;
                    }
                }
            }

            enemyInts = new int[15,15]
            {
                { 0,0,0,0,0,0,0,5,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,4,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,2,0,2,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,2,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,1,0,1,0,0,0,0,0,1,0,1,0,0},
                { 0,0,0,1,0,0,3,0,3,0,0,1,0,0,0},
                { 0,0,0,0,0,0,0,3,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
            EnemyList = new List<Character>();
            for (int i = 0; i < enemyInts.GetLength(0); i++)
            {
                for (int j = 0; j < enemyInts.GetLength(1); j++)
                {
                    switch (enemyInts[j, i])
                    {
                        case 0:
                            EnemyList.Add(null);
                            break;
                        case 1:
                            EnemyList.Add(new 步兵(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 2:
                            EnemyList.Add(new 弓兵(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 3:
                            EnemyList.Add(new 骑兵(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 4:
                            EnemyList.Add(new 法师(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 5:
                            EnemyList.Add(new 女皇(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 6:
                            EnemyList.Add(new 骑兵(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 7:
                            EnemyList.Add(new 骑兵(new Position((i + 1) * 2, j + 1)));
                            break;
                    }
                }
            }

            ProtagonistInts = new int[15, 15]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,6,0,0,0,0,0,0,0},
            };
            ProtagonistList = new List<Character>();
            for (int i = 0; i < ProtagonistInts.GetLength(0); i++)
            {
                for (int j = 0; j < ProtagonistInts.GetLength(1); j++)
                {
                    switch (ProtagonistInts[j, i])
                    {
                        case 0:
                            ProtagonistList.Add(null);
                            break;
                        case 6:
                            ProtagonistList.Add(new 勇士(new Position((i + 1) * 2, j + 1)));
                            break;
                        case 7:
                            ProtagonistList.Add(new 牧师(new Position((i + 1) * 2, j + 1)));
                            break;
                    }
                }
            }

            terrainInts = new int[15, 15]
            {
                { 4,5,4,2,1,1,1,1,1,1,1,2,3,3,3},
                { 4,4,3,2,1,1,1,1,1,1,1,2,4,4,4},
                { 4,4,3,2,1,1,1,1,1,1,1,2,3,4,3},
                { 5,4,3,2,1,1,1,1,1,1,1,2,3,3,3},
                { 5,4,3,2,1,1,1,1,1,1,1,2,3,3,3},
                { 5,5,5,2,2,2,2,1,2,2,2,2,3,3,3},
                { 5,4,3,3,3,3,3,3,3,3,3,3,4,4,3},
                { 5,5,4,3,3,3,3,3,3,4,4,4,3,3,4},
                { 5,5,4,3,3,3,3,3,3,3,3,3,3,3,3},
                { 5,4,3,3,3,3,4,3,3,3,4,3,3,3,3},
                { 5,4,3,3,3,4,4,3,3,3,3,3,3,3,3},
                { 5,5,4,3,3,3,3,4,3,3,3,3,3,4,4},
                { 5,4,3,3,3,3,3,4,4,3,3,4,3,4,3},
                { 4,4,3,3,4,4,3,3,3,3,4,3,4,3,3},
                { 3,3,3,3,4,3,3,3,3,3,3,3,3,3,3},
            };
            TerrainList = new List<Terrain>();
            for (int i = 0; i < terrainInts.GetLength(0); i++)
            {
                for (int j = 0; j < terrainInts.GetLength(1); j++)
                {
                    switch (terrainInts[j, i])
                    {
                        case 1:
                            TerrainList.Add(new 岩石(new Position((i + 1) * 2, j+1)));
                            break;
                        case 2:
                            TerrainList.Add(new 河流(new Position((i + 1) * 2, j+1)));
                            break;
                        case 3:
                            TerrainList.Add(new 平原(new Position((i + 1) * 2, j+1)));
                            break;
                        case 4:
                            TerrainList.Add(new 草原(new Position((i + 1) * 2, j+1)));
                            break;
                        case 5:
                            TerrainList.Add(new 沙漠(new Position((i + 1) * 2, j+1)));
                            break;
                    }
                }
            }
        }
    }
}