using System;
using System.Collections.Generic;

namespace 战棋
{
    public class Level
    {
        public Action level;
        public List<Character> EnemyList;
        public List<Terrain> TerrainList;
        public List<Action> levelList = new List<Action>();

        public Level()
        {
            levelList.Add(Level1);
        }

        public void Level1()
        {
            EnemyList = new List<Character>();
            EnemyList.Add(new 骑兵(new Position(7 * 2, 8)));//先横后竖，横*2
            EnemyList.Add(new 骑兵(new Position(9 * 2, 8)));
            EnemyList.Add(new 骑兵(new Position(8 * 2, 9)));
            EnemyList.Add(new 步兵(new Position(3 * 2, 7)));
            EnemyList.Add(new 步兵(new Position(5 * 2, 7)));
            EnemyList.Add(new 步兵(new Position(11 * 2, 7)));
            EnemyList.Add(new 步兵(new Position(13 * 2, 7)));
            EnemyList.Add(new 步兵(new Position(4 * 2, 8)));
            EnemyList.Add(new 步兵(new Position(12 * 2, 8)));
            TerrainList = new List<Terrain>();
            TerrainList.Add(new 河流(new Position(3 * 2, 1)));
        }
    }
}