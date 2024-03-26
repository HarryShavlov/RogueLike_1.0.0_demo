using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_objects
{
    public class GameObject(char sprite, string title, Position position, bool passable = false)
    {
        public Guid id { get; } = Guid.NewGuid();
        public string title { get; } = title;
        public char sprite { get; set; } = sprite;
        public Position position { get; set; } = position;
        public bool passable { get; set; } = passable;
    }
}
