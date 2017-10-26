using System;
using System.Collections.Generic;

namespace 战棋
{
    public enum 地形
    {
        岩石,//gray
        河流,//Cyan
        平原,//
        草原,//green
        沙漠,//
    }
    public class Terrain
    {
        public 地形 地形;
        public ConsoleColor 地形颜色;
        public int 体力消耗;
        public Position 位置;

        public Terrain(地形 地形, ConsoleColor 地形颜色, int 体力消耗, Position 位置)
        {
            this.地形 = 地形;
            this.地形颜色 = 地形颜色;
            this.体力消耗 = 体力消耗;
            this.位置 = 位置;
        }
    }

    public class 岩石 : Terrain
    {
        public 岩石(Position 位置) : base(地形.岩石, ConsoleColor.Gray, 1, 位置)
        { }
    }

    public class 河流 : Terrain
    {
        public 河流(Position 位置) : base(地形.河流, ConsoleColor.Cyan, 99, 位置)
        { }
    }

    public class 草原 : Terrain
    {
        public 草原(Position 位置) : base(地形.草原, ConsoleColor.DarkGreen, 1, 位置)
        { }
    }

    public class 沙漠 : Terrain
    {
        public 沙漠(Position 位置) : base(地形.沙漠, ConsoleColor.DarkYellow, 1, 位置)
        { }
    }

    public class 平原 : Terrain
    {
        public 平原(Position 位置) : base(地形.平原, ConsoleColor.DarkCyan, 1, 位置)
        { }
    }
}