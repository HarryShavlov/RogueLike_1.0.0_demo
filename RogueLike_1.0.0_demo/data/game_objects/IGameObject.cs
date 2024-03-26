using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_objects
{
    public interface IGameObject
    {
        Guid id { get; }
        string title { get; }
        char sprite { get; }
        Position position { get; }
        bool passable { get; }
        IGameObject add_with_new_position( Position new_position);
    }
}
