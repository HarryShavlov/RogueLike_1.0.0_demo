using RogueLike_1._0._0_demo.data.game_core.event_manager.position_checker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_1._0._0_demo.data.game_core.collision_manager
{
    public interface ICollisionManager
    {
        bool can_move(Position position);
        bool check_collision(Guid object1Id, Guid object2Id);
    }
}
