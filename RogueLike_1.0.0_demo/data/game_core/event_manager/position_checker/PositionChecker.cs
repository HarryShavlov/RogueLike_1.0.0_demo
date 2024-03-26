using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public struct Position(int x, int y)
    {
        public int x { get; set; } = x;
        public int y { get; set; } = y;

        public readonly Position new_position(Direction direction)
       => direction switch
       {
           Direction.Up => new Position(x, y - 1),
           Direction.Down => new Position(x, y + 1),
           Direction.Left => new Position(x - 1, y),
           Direction.Right => new Position(x + 1, y),
           _ => this,
       };


        public static Position operator +(Position a, Position b) => new(a.x + b.x, a.y + b.y);

        public static Position operator -(Position a, Position b) => new(a.x - b.x, a.y - b.y);

        public static Position operator /(Position a, int divisor) => new(a.x / divisor, a.y / divisor);

        public static bool operator ==(Position a, Position b) => a.x == b.x && a.y == b.y;

        public static bool operator !=(Position a, Position b) => !(a == b);

    }

}
