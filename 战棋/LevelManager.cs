namespace 战棋
{
    public class LevelManager
    {
        public static LevelManager instance;
        private Level level;

        public LevelManager()
        {
            instance = this;
            this.level = new Level();
        }
        
    }
}