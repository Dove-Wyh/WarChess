using System;

namespace 战棋
{
    public enum 地形
    {
        城墙,
        河流,
        平原,
        草原,
        沼泽,
        森林,
        沙漠,
        山地,
        桥,
        门,
    }
    public class Terrain
    {
        private 地形 地形;
        private ConsoleColor 地形颜色;
        private int 体力消耗;
        private Position 位置;

        public Terrain(地形 地形, ConsoleColor 地形颜色, int 体力消耗, Position 位置)
        {
            this.地形 = 地形;
            this.地形颜色 = 地形颜色;
            this.体力消耗 = 体力消耗;
        }
    }

    public class 城墙 : Terrain
    {
        public 城墙(Position 位置) : base(地形.城墙, ConsoleColor.Gray, 99, 位置)
        { }
    }

    public class 河流 : Terrain
    {
        public 河流(Position 位置) : base(地形.河流, ConsoleColor.Cyan, 99, 位置)
        { }
    }
}