using System.Collections.Generic;

namespace 战棋
{
    public class Model
    {
        public static Model instance;
        public List<Character> EnemyList;
        public List<Terrain> TerrainList;
        public List<Building> BuildingList;
        public List<Character> ProtagonistList;
        public List<Character> UpList = new List<Character>(225);
        public int[,] buildingInts;
        public int[,] enemyInts;
        public int[,] terrainInts;
        public int[,] ProtagonistInts;
        public int[,] UpInts = new int[15, 15];


        public Model()
        {
            instance = this;
            LikeModel();
        }

        public void LikeModel()
        {
            LevelManager.instance.level.levelList[LevelManager.instance.presentLevel]();

            this.EnemyList = LevelManager.instance.level.EnemyList;
            this.TerrainList = LevelManager.instance.level.TerrainList;
            this.BuildingList = LevelManager.instance.level.BuildingList;
            this.ProtagonistList = LevelManager.instance.level.ProtagonistList;

            this.buildingInts = LevelManager.instance.level.buildingInts;
            this.enemyInts = LevelManager.instance.level.enemyInts;
            this.terrainInts = LevelManager.instance.level.terrainInts;
            this.ProtagonistInts = LevelManager.instance.level.ProtagonistInts;
            for (int i = 0; i < UpInts.GetLength(0); i++)
            {
                for (int j = 0; j < UpInts.GetLength(1); j++)
                {
                    if (enemyInts[i, j] != 0)
                    {
                        UpInts[i, j] = enemyInts[i, j];
                        continue;
                    }
                    if (buildingInts[i, j] != 0)
                    {
                        UpInts[i, j] = buildingInts[i, j];
                        continue;
                    }
                    if (ProtagonistInts[i, j] != 0)
                    {
                        UpInts[i, j] = ProtagonistInts[i, j];
                    }
                }
            }
            for (int i = 0; i < 225; i++)
            {
                if (EnemyList[i] != null)
                {
                    UpList.Add(EnemyList[i]);
                    continue;
                }
                else if (ProtagonistList[i] != null)
                {
                    UpList.Add(ProtagonistList[i]);
                    continue;
                }
                else
                {
                    UpList.Add(null);
                }
            }
        }
    }
}