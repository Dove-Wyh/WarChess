namespace 战棋
{
    public enum 兵种
    {
        步兵,   //步兵
        弓兵,     //弓兵
        骑兵, //骑兵
        弩兵,  //弩兵
        法师,       //法师
        牧师,     //牧师
        平民    //平民
    }

    public class Character
    {
        public bool canMove = false;
        private 兵种 兵种;
        public string 名字;
        public int 总生命值;
        public int 总魔法值;
        public int 攻击力;
        public int 防御力;
        public int 体力;             //一次最多可以走几个格子
        public int 普通攻击范围;
        public Position 位置;

        public Character(兵种 兵种, string 名字, int 总生命值, int 总魔法值, int 攻击力, int 防御力, int 体力, int 普通攻击范围, Position 位置)
        {
            this.兵种 = 兵种;
            this.名字 = 名字;
            this.总生命值 = 总生命值;
            this.总魔法值 = 总魔法值;
            this.攻击力 = 攻击力;
            this.防御力 = 防御力;
            this.体力 = 体力;
            this.普通攻击范围 = 普通攻击范围;
            this.位置 = 位置;
        }

        public void AutoMove()
        {
            if (canMove)
            {

            }
        }
    }

    public class 步兵 : Character
    {
        public int 当前生命值 = 30;
        public int 当前魔法值 = 0;

        public Position 位置;
        public 步兵(Position 位置) : base(兵种.步兵, "步", 30, 0, 10, 10, 3, 1, 位置)
        { }
    }

    public class 骑兵 : Character
    {
        public int 当前生命值 = 30;
        public int 当前魔法值 = 0;

        public Position 位置;
        public 骑兵(Position 位置) : base(兵种.步兵, "骑", 30, 0, 10, 10, 5, 1, 位置)
        { }
    }
}