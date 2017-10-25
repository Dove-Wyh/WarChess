namespace 战棋
{
    public class LevelManager
    {
        public static LevelManager instance;
        public Level level;
        public int presentLevel = 0;
        public LevelManager()
        {
            instance = this;
            this.level = new Level();
        }
    }
}