using System;
using System.Collections.Generic;

namespace 战棋
{
    public class Level
    {
        public Action level;

        public List<Action> levelList = new List<Action>();
        
        public Level()
        {
            levelList.Add(Level1);
        }

        public void Level1()
        {
            List<Character> EnemyList = new List<Character>();
            EnemyList.Add(new 步兵(new Position(8,9)));
            EnemyList.Add(new 步兵(new Position(7,8)));
            EnemyList.Add(new 步兵(new Position(7,10)));
            List<Terrain> TerrainList = new List<Terrain>();
            TerrainList.Add(new 城墙(new Position(5,1)));
        }
    }
}