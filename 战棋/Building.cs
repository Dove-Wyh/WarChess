namespace 战棋
{
    public class Building
    {
        public Position 位置;
        public char 标志;

        public Building(Position 位置, char 标志)
        {
            this.位置 = 位置;
            this.标志 = 标志;
        }
    }

    public class 城墙 : Building
    {
        public 城墙(Position 位置) : base(位置, '█')
        { }
    }

    public class 医院 : Building
    {
        public 医院(Position 位置) : base(位置, '◇')
        { }
    }
}